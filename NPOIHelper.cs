﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;//导出xls格式用HSSF
using NPOI.XSSF.UserModel;//导出xlsx格式用XSSF
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using NPOI.SS.Util;
using Microsoft.Office.Interop.Excel;
using IFont = NPOI.SS.UserModel.IFont;
using System.Data;
using System.Threading;
using System.Collections;


namespace CuttingMake
{
    public class NPOIHelper
    {
        Thread th;  //声明公共变量
        public void GetExcelxlsx()
                             {
                                 //因为要遍历Excel中的数据，我们这里用线程执行
                                  // 需引入命名空间
                                  //using System.Threading;
                                  //using System.Data.SqlClient;
                                  //using NPOI.HSSF.UserModel;
                                  //using NPOI.SS.UserModel;
                                 //using System.IO;
                                 //创建文件
                                 object filePath = ""; // 文件路径
            
                                 OpenFileDialog ofd = new OpenFileDialog(); //创建文件
                                 ofd.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
                                 ofd.ShowDialog();
                                 filePath = ofd.FileName;
                                 th = new Thread(inportData);
                                 th.IsBackground = true; //将线程设置为后台进程
                                 th.Start(filePath);
                                 ofd.Dispose();
                             }
    public void inportData(object filePath)
         {
            FileStream fsRead = new FileStream(filePath.ToString(), FileMode.Open);
            //一、创建工作簿
            IWorkbook workbook;
            string insert_sql = "";
            string insert_module = "INSERT INTO tb_UpData (嵩阳卷号,长度) VALUES (";
            StringBuilder sb = new StringBuilder();

            //*** 根据扩展名xls和xlsx来创建对象
            string fileExt = Path.GetExtension(filePath.ToString()).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook(fsRead);
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook(fsRead);
            }
            else
            {
                workbook = null;
            }


            // 创建表副本 SELECT TOP 0 * INSERT INTO newTable FROM oldTable
            //1、从Excel中读取数据
            if (filePath.ToString() != "")
            {

                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    //获取工作表
                    ISheet sheet = workbook.GetSheetAt(i);
                    for (int r = 0; r <= sheet.LastRowNum; r++) //遍历当前工作表中的所有行
                    {
                        IRow currentRow = sheet.GetRow(r); //获取每一行
                        for (int c = 0; c < currentRow.LastCellNum; c++) //遍历当前行中的所有列
                        {
                            //获取每个单元格
                            ICell cell = currentRow.GetCell(c);
                            //listCells.Add(cell);
                            sb.Append("'").Append(cell.ToString()).Append("',");
                        }
                        //拼接SQL语句
                        insert_sql = insert_module + sb.ToString().Substring(0, sb.ToString().Length - 1) + ")";

                        //2、把读取到的数据插入到数据库
                        //执行SQL语句
                        int ret = clsSQL.intExecuteQuery(insert_sql);
                        if (ret > 0)
                        {
                            clsLoad.WriteLog("导入数据：" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "成功！");
                           // MessageBox.Show("导入数据："+ sb.ToString().Substring(0, sb.ToString().Length - 1) + "成功！");
                        }
                        else
                        {
                            MessageBox.Show("导入失败！");
                        }

                        sb.Clear();
                        //listCells.Clear();
                    }
                    //2、把读取到的数据插入到数据库
                    //执行SQL语句
                    //int ret = clsSQL.intExecuteQuery(insert_sql);
                    ////int ret = sqlHelper.ExecuteNonQuery(insert_sql, CommandType.Text);
                    //if (ret > 0)
                    //{
                    //    MessageBox.Show("导入成功！");
                    //    return;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("导入失败！");
                    //    return;
                    //}
                    fsRead.Close();
                    fsRead.Dispose();
                }
            }
            else
            {
                MessageBox.Show("文件打开失败！");
                return;
            }
         }

    #region  NPOI DataGridView 导出 EXCEL
    /// <summary>
    ///  NPOI DataGridView 导出 EXCEL
    ///  03版Excel-xls最大行数是65536行,最大列数是256列
    ///  07版Excel-xlsx最大行数是1048576行,最大列数是16384列
    /// </summary>
    /// <param name="fileName">默认保存文件名</param>
    /// <param name="dgv">DataGridView</param>
    /// <param name="fontname">字体名称</param>
    /// <param name="fontsize">字体大小</param> 

    public void ExportExcel(string fileName, DataGridView dgv, string fontname, short fontsize)
        {
            IWorkbook workbook;
            ISheet sheet;
            Stopwatch sw = null;

            //判断datagridview中内容是否为空
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("DataGridView中内容为空,请先导入数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //保存文件
            string saveFileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Excel文件保存路径";
           // saveFileDialog.Title = System.Windows.Forms.Application.StartupPath + "\\excel";
            saveFileDialog.FileName = fileName;
            MemoryStream ms = new MemoryStream(); //MemoryStream
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //**程序开始计时**//
                sw = new Stopwatch();
                sw.Start();

                saveFileName = saveFileDialog.FileName;

                //检测文件是否被占用
                if (!CheckFiles(saveFileName))
                {
                    MessageBox.Show("文件被占用,请关闭文件" + saveFileName);
                    workbook = null;
                    ms.Close();
                    ms.Dispose();
                    return;
                }
            }
            else
            {
                workbook = null;
                ms.Close();
                ms.Dispose();
            }

            //*** 根据扩展名xls和xlsx来创建对象
            string fileExt = Path.GetExtension(saveFileName).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                workbook = null;
            }
            //***

            //创建Sheet
            if (workbook != null)
            {
                sheet = workbook.CreateSheet("Sheet1");//Sheet的名称  
            }
            else
            {
                return;
            }

            //设置单元格样式
            ICellStyle cellStyle = workbook.CreateCellStyle();
            //水平居中对齐和垂直居中对齐
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            //设置字体
            IFont font = workbook.CreateFont();
            font.FontName = fontname;//字体名称
            font.FontHeightInPoints = fontsize;//字号
            font.Color = NPOI.HSSF.Util.HSSFColor.Black.Index;//字体颜色
            cellStyle.SetFont(font);

            //添加列名
            IRow headRow = sheet.CreateRow(0);
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                //隐藏行列不导出
                if (dgv.Columns[i].Visible == true)
                {
                    headRow.CreateCell(i).SetCellValue(dgv.Columns[i].HeaderText);
                    headRow.GetCell(i).CellStyle = cellStyle;
                }
            }

            //根据类型写入内容
            for (int rowNum = 0; rowNum < dgv.Rows.Count; rowNum++)
            {
                ///跳过第一行,第一行为列名
                IRow dataRow = sheet.CreateRow(rowNum + 1);
                for (int columnNum = 0; columnNum < dgv.Columns.Count; columnNum++)
                {
                    int columnWidth = sheet.GetColumnWidth(columnNum) / 256; //列宽

                    //隐藏行列不导出
                    if (dgv.Rows[rowNum].Visible == true && dgv.Columns[columnNum].Visible == true)
                    {
                        //防止行列超出Excel限制
                        if (fileExt == ".xls")
                        {
                            //03版Excel最大行数是65536行,最大列数是256列
                            if (rowNum > 65536)
                            {
                                MessageBox.Show("行数超过Excel限制!");
                                return;
                            }
                            if (columnNum > 256)
                            {
                                MessageBox.Show("列数超过Excel限制!");
                                return;
                            }
                        }
                        else if (fileExt == ".xlsx")
                        {
                            //07版Excel最大行数是1048576行,最大列数是16384列
                            if (rowNum > 1048576)
                            {
                                MessageBox.Show("行数超过Excel限制!");
                                return;
                            }
                            if (columnNum > 16384)
                            {
                                MessageBox.Show("列数超过Excel限制!");
                                return;
                            }
                        }

                        ICell cell = dataRow.CreateCell(columnNum);
                        if (dgv.Rows[rowNum].Cells[columnNum].Value == null)
                        {
                            cell.SetCellType(CellType.Blank);
                        }
                        else
                        {
                            if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Int32"))
                            {
                                cell.SetCellValue(Convert.ToInt32(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.String"))
                            {
                                cell.SetCellValue(dgv.Rows[rowNum].Cells[columnNum].Value.ToString());
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Single"))
                            {
                                cell.SetCellValue(Convert.ToSingle(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Double"))
                            {
                                cell.SetCellValue(Convert.ToDouble(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Decimal"))
                            {
                                cell.SetCellValue(Convert.ToDouble(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.DateTime"))
                            {
                                cell.SetCellValue(Convert.ToDateTime(dgv.Rows[rowNum].Cells[columnNum].Value).ToString("yyyy-MM-dd"));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.DBNull"))
                            {
                                cell.SetCellValue("");
                            }
                        }

                        //设置列宽
                        IRow currentRow;
                        if (sheet.GetRow(rowNum) == null)
                        {
                            currentRow = sheet.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = sheet.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;

                            if (columnWidth < length)
                            {
                                columnWidth = length + 10; //设置列宽数值
                            }
                        }
                        sheet.SetColumnWidth(columnNum, columnWidth * 256);

                        //单元格样式
                        dataRow.GetCell(columnNum).CellStyle = cellStyle;
                    }
                }
            }

            //保存为Excel文件                  
            workbook.Write(ms);
            FileStream file = new FileStream(saveFileName, FileMode.Create);
            workbook.Write(file);
            file.Close();
            workbook = null;
            ms.Close();
            ms.Dispose();

            //**程序结束计时**//
            sw.Stop();
            double totalTime = sw.ElapsedMilliseconds / 1000.0;

            MessageBox.Show(fileName + " 导出成功\n耗时" + totalTime + "s", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion


        #region 检测文件是否被占用 
        /// <summary>
        /// 判定文件是否打开
        /// </summary>   
        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public readonly IntPtr HFILE_ERROR = new IntPtr(-1);

        /// <summary>
        /// 检测文件被占用 
        /// </summary>
        /// <param name="FileNames">要检测的文件路径</param>
        /// <returns></returns>
        public bool CheckFiles(string FileNames)
        {
            if (!File.Exists(FileNames))
            {
                //文件不存在
                return true;
            }
            IntPtr vHandle = _lopen(FileNames, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (vHandle == HFILE_ERROR)
            {
                //文件被占用
                return false;
            }
            //文件没被占用
            CloseHandle(vHandle);
            return true;
        }
        #endregion                            
    }
}