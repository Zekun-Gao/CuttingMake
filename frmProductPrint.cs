using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using ZPLPrintDLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static CuttingMake.clsLoad;
using System.Formats.Asn1;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using NPOI.SS.Formula.Functions;

namespace CuttingMake
{
    public partial class frmProductPrint : Form
    {
        int i = 0;
        string[] b;
        string strSQL = "", str = "", strTemp = "";
        Regex myregex;
        string datatime = DateTime.Now.ToString("yyyyMMdd");
        private OleDbConnection Conn = new OleDbConnection(clsSQL.strConn);
        CommonHelper CommonH = new CommonHelper();
        PrintHelper PrintH = new PrintHelper();
        private RawPrinterHelper zplp = new RawPrinterHelper();
        NPOIHelper NPOIHelper = new NPOIHelper();
        string FilePath = string.Empty;
#pragma warning disable CS0414 // 字段“frmProductPrint.MPBarCodeNumber”已被赋值，但从未使用过它的值
        string PrintTime = "";
#pragma warning restore CS0414 // 字段“frmProductPrint.MPBarCodeNumber”已被赋值，但从未使用过它的值
#pragma warning disable CS0414 // 字段“frmProductPrint.BatchNum”已被赋值，但从未使用过它的值
        int BatchNum = 0;
#pragma warning restore CS0414 // 字段“frmProductPrint.BatchNum”已被赋值，但从未使用过它的值
#pragma warning disable CS0414 // 字段“frmProductPrint.cmbCount”已被赋值，但从未使用过它的值
        int cmbCount = 0;
#pragma warning restore CS0414 // 字段“frmProductPrint.cmbCount”已被赋值，但从未使用过它的值
#pragma warning disable CS0414 // 字段“frmProductPrint.intcmbSCSupplier”已被赋值，但从未使用过它的值
        int intcmbSCSupplier = 0;//默认值为可以触发事件
#pragma warning restore CS0414 // 字段“frmProductPrint.intcmbSCSupplier”已被赋值，但从未使用过它的值
        clsLoad.CuttingPart MyPart;
        clsLoad.UpExcel MyExcel;

        int[] intCycDataOk = new int[2];
        int[] intCycTarget = new int[2];
        int[] intCycQRCode = new int[2];
        int[] intCycWordes = new int[2];
        int[] intCycPrint = new int[2];
        int[] intCycServe = new int[2];

        public frmProductPrint()
        {
            InitializeComponent();
        }

        private void frmProductPrint_Load(object sender, EventArgs e)
        {
            //设置启动状态   groupBox1
            picScan.BackColor = Color.Lime;

            //数据栏状态
            DataStatetr(null, null);
            tScan.Enabled = false;
            btnDataOK.Enabled = true;
            btnDataOK.BackColor = groupBox7.BackColor;

            sysStatus.Text = "系统初始化中...！";
            clsLoad.WriteLog(sysStatus.Text);
            clsSQL.strConn = "";
            clsLoad.strMarkMode = "M";

            fillcmbSCSupplier();
            fillcmbSCITODate();
            fillcmbOrderNumber();
            fillcmbZHPartType();

            PrintTime = clsLoad.ReadIniStr("PrintCount", "PrintTime", "", Application.StartupPath + "\\land.ini");

            strTemp = clsLoad.ReadIniStr("DebugIf", "IfUse", "", Application.StartupPath + "\\land.ini");
            if (strTemp == "1")
            {
                setMb();  //提取现有标签打印机
                GetPrintList();  //提取打印模板
            }
            else
            {
                label17.Visible = false;
                label18.Visible = false;
                comboBox1.Visible = false;
                cmbTemplate.Visible = false;
                btnPrinter.Visible = false;
            }
            txtPrintCount.Enabled = false;
            txtPrintCount.Text = strTemp = clsLoad.ReadIniStr("PrintCount", "Count", "", Application.StartupPath + "\\land.ini");

            //检查数据库连接

            //是否启用打印机
            strTemp = clsLoad.ReadIniStr("ConnectPrint", "IfUse", "", Application.StartupPath + "\\land.ini");
            if (strTemp == "1")
            {
                sysStatus.Text = "程序初始化：连接打印设备！";
                clsLoad.WriteLog(sysStatus.Text);

                // clsLoad.strErr = clsWord.strConnect;
                if (clsLoad.strErr != "")
                {
                    clsLoad.strErr = "系统启动失败：" + clsLoad.strErr;
                    MessageBox.Show(clsLoad.strErr);
                    sysStatus.Text = clsLoad.strErr;
                    clsLoad.strErr = "";
                    return;
                }
            }

            if (sysReset() != "")
            {
                sysStatus.Text = "系统启动失败:" + clsLoad.strErr;
                MessageBox.Show(sysStatus.Text);
                return;
            }


            sysStatus.Text = "初始化成功！";
            clsLoad.WriteLog(sysStatus.Text);

        }

        //复位界面状态
        private string sysReset()
        {

            clsLoad.strErr = "";
            clsLoad.tAlarm.Enabled = false;
            txtSCDate.Text = datatime;

            //清空进度状态指示
            //ClearRunStatus();

            pictureBox2.Image = null;

            btnManual_Click(null, null);

            btnDataOK.Enabled = true;
            btnDataOK.BackColor = groupBox7.BackColor;
            btnUpPrintData.BackColor = groupBox5.BackColor;
            //数据栏状态
            DataStatetr(null, null);
            txtCuttingSN.Enabled = true;
            txtPartLength.Enabled = true;
            if (ckSerialUp.Checked == false)
            {
                txtZHReelSN.Enabled = true;
            }

            //txtPartCount.Enabled = true;
            btnDataOK.BackColor = groupBox4.BackColor;
            btnLoadTemplate.BackColor = groupBox5.BackColor;
            btnSwitchTemplate.BackColor = groupBox5.BackColor;
            btnPrintPreview.BackColor = groupBox5.BackColor;
            btnPrintZPL.BackColor = groupBox5.BackColor;
            btnSaveData.BackColor = groupBox5.BackColor;
            btnUpdateData.BackColor = groupBox5.BackColor;

            //更新列表信息
            MarkedRecode();

            // tScan.Enabled = true;

            tScan.Stop();
            tScan.Interval = 500;
            tScan.Start();

            sysStatus.Text = "系统复位完成";
            return "";

        }
        private void btnManual_Click(object sender, EventArgs e)
        {
            btnManual.BackColor = Color.Lime;
            btnAuto.BackColor = groupBox2.BackColor;

            clsLoad.strMarkMode = "M";
            btnAuto.Enabled = true;
            btnManual.Enabled = false;
            btnUpPrintData.Enabled = false;

            sysStatus.Text = "设备进入手动模式";
            clsLoad.WriteLog(sysStatus.Text);

        }
        private void btnAuto_Click(object sender, EventArgs e)
        {

            btnManual.BackColor = groupBox2.BackColor;
            btnAuto.BackColor = Color.Lime;

            for (int i = 0; i < 2; i++)
            {
                intCycDataOk[i] = 0;
                intCycTarget[i] = 0;
                intCycQRCode[i] = 0;
                intCycWordes[i] = 0;
                intCycPrint[i] = 0;
                intCycServe[i] = 0;
            }

            DataStatefa(null, null);

            btnAuto.Enabled = false;
            btnManual.Enabled = true;
            clsLoad.strMarkMode = "A";
            btnUpPrintData.Enabled = true;
            sysStatus.Text = "设备进入自动模式";
            clsLoad.WriteLog(sysStatus.Text);
        }

        private void tVoidScan()
        {

            #region  判断是否确认数据
            if (btnDataOK.Enabled == false && txtSYReelNumber.Text != "" && clsLoad.strMarkMode == "A")
            {
                btnLoadTemplate.Enabled = false;
                btnLoadTemplate.BackColor = Color.Lime;
            }
            #endregion
            #region  加载模版
            if (btnLoadTemplate.Enabled == false && MyPart.MarkPath != "" && clsLoad.strMarkMode == "A")
            {
                btnSwitchTemplate_Click(null, null);
            }
            #endregion
            #region  打印预览
            if (btnSwitchTemplate.Enabled == false && MyPart.ZPLPrinter != "" && clsLoad.strMarkMode == "A")
            {
                strTemp = clsLoad.ReadIniStr("DebugIf", "Image", "", Application.StartupPath + "\\land.ini");
                if (strTemp == "1")
                {
                    btnPrintPreview_Click(null, null);
                }
                else
                {
                    btnPrintPreview.Enabled = false;
                    btnPrintPreview.BackColor = Color.Lime;
                }
            }
            #endregion
            #region  打印标签
            if (btnPrintPreview.Enabled == false && clsLoad.strMarkMode == "A")
            {
                btnPrintZPL_Click(null, null);
            }
            #endregion
            #region  保存数据
            if (btnPrintZPL.Enabled == false && clsLoad.strMarkMode == "A")
            {
                btnSaveData_Click(null, null);
            }
            #endregion 
            #region  更新数据
            if (btnSaveData.Enabled == false && clsLoad.strMarkMode == "A")
            {
                btnUpdateData.BackColor = Color.Lime;
                UpdatecmbZHPartType_Selected();
            }
            #endregion
            #region  数据库读取保存标识
            if (btnUpPrintData.Enabled == false && clsLoad.strMarkMode == "A")
            {
                if (UpDataExcelData() != "")
                {
                    goto AA;
                }
            }
        #endregion

        #region  清空状态
        AA:
            txtCuttingSN.Enabled = true;
            txtPartLength.Enabled = true;
            //txtPartCount.Enabled = true;
            if (ckSerialUp.Checked == false)
            {
                txtZHReelSN.Enabled = true;
            }

            btnDataOK.Enabled = true;
            btnLoadTemplate.Enabled = true;
            btnSwitchTemplate.Enabled = true;
            btnPrintPreview.Enabled = true;
            btnPrintZPL.Enabled = true;
            btnSaveData.Enabled = true;
            btnUpdateData.Enabled = true;

            btnDataOK.BackColor = groupBox5.BackColor;
            btnLoadTemplate.BackColor = groupBox5.BackColor;
            btnSwitchTemplate.BackColor = groupBox5.BackColor;
            btnPrintPreview.BackColor = groupBox5.BackColor;
            btnPrintZPL.BackColor = groupBox5.BackColor;
            btnSaveData.BackColor = groupBox5.BackColor;
            btnUpdateData.BackColor = groupBox5.BackColor;
            #endregion
        }

        //更新Excel数据库表
        private string UpDataExcelData()
        {
            //检查数据库中是否存在此数据
            strSQL = "select * from tb_UpData where 嵩阳卷号='" + MyPart.CuttingSN + "'";
            string tempCuttingSN = clsSQL.strGetfield(strSQL);
            if (tempCuttingSN != "")
            {

                strSQL = "update tb_UpData set IfPrint=1 where 嵩阳卷号='" + MyPart.CuttingSN + "'";
                i = clsSQL.intExecuteQuery(strSQL);
                if (i == 1)
                {
                    sysStatus.Text = "更EXCEL打印卷号：" + MyPart.CuttingSN + " 嵩阳卷号为：" + txtSYReelNumber.Text + " 完成！";
                    clsLoad.WriteLog(sysStatus.Text);
                }
                else
                {
                    clsLoad.strErr = "更EXCEL打印卷号：" + MyPart.CuttingSN + " 嵩阳卷号为：" + txtSYReelNumber.Text + " 失败，请检查数据是否重复！";
                    return clsLoad.strErr;
                }
            }
            else
            {
                sysStatus.Text = "更EXCEL打印卷号错误，请查询数据是否存在！";
                clsLoad.strErr = sysStatus.Text;
                return clsLoad.strErr;
            }
            return "";

        }


        private void btnUpPrintData_Click(object sender, EventArgs e)
        {
            sysStatus.Text = "数据库提取打印中，请勿非法中断操作！";
            clsLoad.WriteLog(sysStatus.Text);
            btnUpPrintData.Enabled = false;
            btnUpPrintData.BackColor = Color.Lime;
            int count = 1;

            if (ckSerialUp.Checked == false)
            {
                sysStatus.Text = "未使用厂家序列号列号累加打标，禁止使用此功能！";
                clsLoad.WriteLog(sysStatus.Text);
                //MessageBox.Show(sysStatus.Text);
                goto AA;
            }


            OleDbDataReader thisReader;
            strSQL = string.Format(" select  * from tb_UpData where IfPrint=0");
            thisReader = clsSQL.GetDataReader(strSQL);
            while (thisReader.Read())
            {
                if (clsLoad.strErr != "")
                {
                    return;
                }
                MyExcel.CuttingSN = Convert.ToString(thisReader["嵩阳卷号"]);
                MyExcel.PartLength = Convert.ToString(thisReader["长度"]);

                txtPartLength.Text = MyExcel.PartLength;
                txtCuttingSN.Text = MyExcel.CuttingSN;

                btnDataOK_Click(null, null);

                lblSN.Text = count++.ToString();
                sysStatus.Text = "数据自动打印中：" + txtCuttingSN.Text + "，第" + lblSN.Text + "位";
                clsLoad.WriteLog(sysStatus.Text);
                if (clsLoad.strErr != "")
                {
                    return;
                }
            }
            if (count == 0)
            {
                sysStatus.Text = "未在数据库找到任何数据！";
                clsLoad.WriteLog(sysStatus.Text);
            }
            else
            {
                sysStatus.Text = "数据库提取打印结束，共打印 " + (count - 1) + " 个标签！";
                clsLoad.WriteLog(sysStatus.Text);
            }
        AA:
            if (clsLoad.strMarkMode == "A")
            {
                btnUpPrintData.Enabled = true;
                btnUpPrintData.BackColor = groupBox5.BackColor;
            }

        }

        //确认数据入库
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            sysStatus.Text = "保存数据中！" + txtSYReelNumber.Text;
            clsLoad.WriteLog(sysStatus.Text);
            btnSaveData.Enabled = false;
            btnSaveData.BackColor = Color.Lime;

            #region  检查数据完整性
            if (btnDataOK.BackColor != Color.Lime)
            {
                sysStatus.Text = "请先确认数据！";
                clsLoad.WriteLog(sysStatus.Text);
                MessageBox.Show(sysStatus.Text);
                goto AA;
            }
            #endregion

            if (SaveData() != "")
            {
                goto AA;
            }
            sysStatus.Text = "保存数据完成！";
            clsLoad.WriteLog(sysStatus.Text);
        AA:
            clsLoad.Delay(500);
            if (clsLoad.strMarkMode == "M")
            {
                btnSaveData.Enabled = true;
                btnSaveData.BackColor = groupBox5.BackColor;
            }

        }
        private string SaveData()
        {
            //检查数据库中是否存在此数据
            strSQL = "select * from tb_CuttingLog where SYReelNumber='" + txtSYReelNumber.Text + "'";
            string tempBatchNumber = clsSQL.strGetfield(strSQL);
            if (tempBatchNumber != "" && ckRepeat.Checked == true)
            {
                sysStatus.Text = "保存卷号标签时检查，卷号" + txtSYReelNumber.Text + "已存在，请查询数据库！";
                clsLoad.strErr = sysStatus.Text;
                return clsLoad.strErr;
            }
            if (txtTarget1.Text == "")
            {
                sysStatus.Text = "备注列表为空！";
                clsLoad.WriteLog(sysStatus.Text);
                strSQL = "insert into tb_CuttingLog(SYReelNumber,ZHPartType,ZHOrderNumber,PartLength,PartCount,ZHPartNumber,ZHPartDate,ZHReelNumber,txtTarget1,PrintDate,Operator,PrintMode) values ('" + txtSYReelNumber.Text + "','" + cmbZHPartType.Text + "','" + cmbOrderNumber.Text + "','" + txtPartLength.Text + "','" + txtPartCount.Text + "','" + txtZHPartNumber.Text + "','" + txtSCDate.Text + "','" + txtZHReelNumber.Text + "','无','" + DateTime.Now + "','" + clsLoad.MarkUser + "','" + clsLoad.strMarkMode + "')";
            }
            if (txtTarget1.Text != "")
            {
                sysStatus.Text = "备注列表为：" + txtTarget1.Text;
                clsLoad.WriteLog(sysStatus.Text);
                strSQL = "insert into tb_CuttingLog(SYReelNumber,ZHPartType,ZHOrderNumber,PartLength,PartCount,ZHPartNumber,ZHPartDate,ZHReelNumber,txtTarget1,PrintDate,Operator,PrintMode) values ('" + txtSYReelNumber.Text + "','" + cmbZHPartType.Text + "','" + cmbOrderNumber.Text + "','" + txtPartLength.Text + "','" + txtPartCount.Text + "','" + txtZHPartNumber.Text + "','" + txtSCDate.Text + "','" + txtZHReelNumber.Text + "','" + txtTarget1.Text + "','" + DateTime.Now + "','" + clsLoad.MarkUser + "','" + clsLoad.strMarkMode + "')";
            }

            if (clsSQL.intExecuteQuery(strSQL) <= 0)
            {
                sysStatus.Text = "数据入库，数据库添加记录失败！";
                clsLoad.strErr = sysStatus.Text;
                return clsLoad.strErr;
            }
            else
            {
                sysStatus.Text = "数据入库，数据库添加记录成功！";
                clsLoad.WriteLog(sysStatus.Text);

                //更新列表信息
                MarkedRecode();
                if (ckSerialUp.Checked == true)
                {
                    //批次编号更新
                    strSQL = "update tb_PartType set SN='" + txtZHReelSN.Text + "' where ZHPartType='" + cmbZHPartType.Text + "'";
                    i = clsSQL.intExecuteQuery(strSQL);
                    if (i == 1)
                    {
                        sysStatus.Text = "更新产品：" + cmbZHPartType.Text + " 系列号为：" + txtZHReelSN.Text + " 完成";
                        clsLoad.WriteLog(sysStatus.Text);
                    }
                    else
                    {
                        clsLoad.strErr = "更新产品：" + cmbZHPartType.Text + " 系列号为：" + txtZHReelSN.Text + " 失败，请检查数据库";
                        return clsLoad.strErr;
                    }
                }
            }

            return "";

        }

        private string UpdateSN()
        {
            string strSysDate = "";
            try
            {
                if (cmbZHPartType.Text == "")
                {
                    clsLoad.strErr = "未选择有产品型号，无法更新系列号";
                    clsLoad.WriteLog(clsLoad.strErr);
                    return clsLoad.strErr;
                }
                //strSysDate = DateTime.Now.ToString("yyyy-MM-dd");
                str = clsSQL.strGetfield("select SN_Week from tb_PartType where ZHPartType='" + cmbZHPartType.Text + "'");

                string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
                strSysDate = week;

                if (str == strSysDate)
                {
                    str = clsSQL.strGetfield("select SN_Date from tb_PartType where ZHPartType='" + cmbZHPartType.Text + "'");
                    strSysDate = DateTime.Now.ToString("yyyy-MM-dd");
                    if (str != strSysDate)
                    {
                        strSQL = "Update tb_PartType set SN_Date='" + strSysDate + "',SN='0' where ZHPartType='" + cmbZHPartType.Text + "'";

                        i = clsSQL.intExecuteQuery(strSQL);
                        if (i < 1)
                        {
                            clsLoad.strErr = "更新产品型号：" + cmbZHPartType.Text + " 系列号失败，更新完成" + i.ToString() + "条记录";
                            clsLoad.WriteLog(clsLoad.strErr);
                            return clsLoad.strErr;
                        }
                        else
                        {
                            sysStatus.Text = "更新产品型号：" + cmbZHPartType.Text + " 完成，系列号设定为0，时间：" + strSysDate;
                            clsLoad.WriteLog(sysStatus.Text);
                        }
                    }
                }

                strSQL = "select SN from tb_PartType where ZHPartType='" + cmbZHPartType.Text + "'";
                MyPart.SN = clsSQL.strGetfield(strSQL);

                Regex myregex = new Regex("[^0-9]");
                if ((myregex.IsMatch(MyPart.SN) == true) || (MyPart.SN.Length == 0))
                {
                    clsLoad.strErr = "获取系列号错误，非法字符;" + MyPart.SN;
                    clsLoad.WriteLog(clsLoad.strErr);
                    return clsLoad.strErr;
                }


                MyPart.SN = (Convert.ToInt32(MyPart.SN) + 1).ToString();

                MyPart.SN = MyPart.SN.PadLeft(MyPart.BarCode.Length, '0');

                return "";
            }
            catch (Exception ex)
            {
                clsLoad.strErr = "UpdateSN，异常;" + ex.ToString();
                clsLoad.WriteLog(clsLoad.strErr);
                return clsLoad.strErr;
                //throw ex;
            }

        }

        //系统时钟
        private void tScan_Tick(object sender, EventArgs e)
        {
            tScan.Stop();
            if (clsLoad.strErr != "")
            {
                ErrShow(clsLoad.strErr);
                return;
            }

            if (clsLoad.strMarkMode == "A")
            {
                if (picScan.BackColor == Color.Red)
                {
                    picScan.BackColor = groupBox2.BackColor;

                }
                else
                {
                    picScan.BackColor = Color.Red;
                }
            }
            else
            {
                if (picScan.BackColor == Color.Lime)
                {
                    picScan.BackColor = groupBox2.BackColor;

                }
                else
                {
                    picScan.BackColor = Color.Lime;
                }
            }

            //if (clsLoad.strMarkMode == "A"  && PrintModeExcel == "HM")
            //{
            //    tVoidScan();
            //}
            tScan.Start();

        }
        private void ErrShow(string str)
        {
            if (clsLoad.IsExit) return;

            frmErr myfrmErr = new frmErr();
            clsLoad.strErr = str;

            myfrmErr.ShowDialog();

            //manual();
            //lblTip.Visible = true;

            sysStatus.Text = str + ",请复位!";

        }

        //加载模版
        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            sysStatus.Text = "加载模板中...！";
            clsLoad.WriteLog(sysStatus.Text);
            btnLoadTemplate.Enabled = false;
            btnLoadTemplate.BackColor = Color.Lime;

            #region  检查数据完整性
            if (btnDataOK.BackColor != Color.Lime)
            {
                sysStatus.Text = "请先确认数据！";
                clsLoad.strErr = sysStatus.Text;
                goto AA;
            }
            #endregion

            strTemp = clsLoad.ReadIniStr("DebugIf", "IfUse", "", Application.StartupPath + "\\land.ini");
            if (strTemp == "1")
            {
                if (cmbTemplate.Text == "")
                {
                    sysStatus.Text = "请选择模板！";
                    clsLoad.strErr = sysStatus.Text;
                    return;
                }
                FilePath = Application.StartupPath + "\\template" + cmbTemplate.Text;
                MyPart.ZebraZPL = CommonH.getBoxFlie(FilePath);
                textBox1.Text = MyPart.ZebraZPL;
            }
            else
            {
                if (MyPart.MarkPath == "")
                {
                    sysStatus.Text = "请检查模板是否存在！";
                    clsLoad.strErr = sysStatus.Text;
                    return;
                }
                FilePath = Application.StartupPath + "\\template\\" + MyPart.MarkPath;
                cmbTemplate.Text = @"\" + MyPart.MarkPath;
                MyPart.ZebraZPL = CommonH.getBoxFlie(FilePath);
            }
            clsLoad.Delay(50);
            sysStatus.Text = "模板加载完成！";
            clsLoad.WriteLog(sysStatus.Text);
        AA:
            if (clsLoad.strMarkMode == "M")
            {
                btnLoadTemplate.Enabled = true;
                btnLoadTemplate.BackColor = groupBox5.BackColor;
            }

        }
        //数据加载
        private void btnSwitchTemplate_Click(object sender, EventArgs e)
        {
            sysStatus.Text = "加载数据中...！";
            clsLoad.WriteLog(sysStatus.Text);
            btnSwitchTemplate.Enabled = false;
            btnSwitchTemplate.BackColor = Color.Lime;

            #region  检查数据完整性
            if (btnDataOK.BackColor != Color.Lime)
            {
                sysStatus.Text = "请先确认数据！";
                clsLoad.strErr = sysStatus.Text;
                goto AA;
            }
            #endregion

            strTemp = clsLoad.ReadIniStr("DebugIf", "IfUse", "", Application.StartupPath + "\\land.ini");
            if (strTemp == "1")
            {
                if (MyPart.ZebraZPL == "")
                {
                    sysStatus.Text = "请先加载模板！";
                    clsLoad.strErr = sysStatus.Text;
                    return;
                }

                MyPart.PrintDate = MyPart.ZHPartType + "~" + MyPart.ZHPartNumber + "~" + MyPart.ZHPartDate + "~" + MyPart.ZHReelNumber + "~" + MyPart.PartLength
                    + "~" + MyPart.PartCount + "~" + MyPart.SYReelNumber + "~" + MyPart.ZHOrderNumber + "~" + MyPart.QRPartNumber;

                FilePath = Application.StartupPath + "\\template" + cmbTemplate.Text;
                //替换后字符串
                MyPart.SwitchZebraZPL = PrintH.GetPrintString(FilePath, MyPart.PrintDate);
                textBox2.Text = MyPart.SwitchZebraZPL;
            }
            else
            {
                if (MyPart.MarkPath == "")
                {
                    sysStatus.Text = "请检查模板是否存在！";
                    clsLoad.strErr = sysStatus.Text;
                }

                MyPart.PrintDate = MyPart.ZHPartType + "~" + MyPart.ZHPartNumber + "~" + MyPart.ZHPartDate + "~" + MyPart.ZHReelNumber + "~" + MyPart.PartLength
                    + "~" + MyPart.PartCount + "~" + MyPart.SYReelNumber + "~" + MyPart.ZHOrderNumber + "~" + MyPart.QRPartNumber;

                FilePath = Application.StartupPath + "\\template\\" + MyPart.MarkPath;
                //替换后字符串
                MyPart.SwitchZebraZPL = PrintH.GetPrintString(FilePath, MyPart.PrintDate);

            }
            clsLoad.Delay(50);
            sysStatus.Text = "模版加载完成！";
            clsLoad.WriteLog(sysStatus.Text);
        AA:
            if (clsLoad.strMarkMode == "M")
            {
                btnSwitchTemplate.Enabled = true;
                btnSwitchTemplate.BackColor = groupBox5.BackColor;
            }

        }

        //打印预览
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            sysStatus.Text = "预览数据加载中...！";
            clsLoad.WriteLog(sysStatus.Text);
            btnPrintPreview.Enabled = false;
            btnPrintPreview.BackColor = Color.Lime;
            #region  检查数据完整性
            if (btnDataOK.BackColor != Color.Lime)
            {
                sysStatus.Text = "请先确认数据！";
                clsLoad.strErr = sysStatus.Text;
                goto AA;
            }
            #endregion
#pragma warning disable CS0168 // 声明了变量，但从未使用过
            try
            {
                strTemp = clsLoad.ReadIniStr("DebugIf", "IfUse", "", Application.StartupPath + "\\land.ini");
                if (strTemp == "1")
                {
                    if (MyPart.SwitchZebraZPL == "")
                    {
                        sysStatus.Text = "模板内容为空，请稍后重新操作！";
                        clsLoad.strErr = sysStatus.Text;
                        goto AA;
                    }
                    string ImageFilePath = Application.StartupPath + @"\image";

                    if (Directory.Exists(ImageFilePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(ImageFilePath);
                    }

                    byte[] zpl = Encoding.UTF8.GetBytes(MyPart.SwitchZebraZPL);

                    // adjust print density (8dpmm), label width (4 inches), label height (6 inches), and label index (0) as necessary
                    var request = (HttpWebRequest)WebRequest.Create("http://api.labelary.com/v1/printers/8dpmm/labels/4x3/0/");
                    request.Method = "POST";
                    //request.Accept = "application/pdf"; // omit this line to get PNG images back
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = zpl.Length;

                    var requestStream = request.GetRequestStream();
                    requestStream.Write(zpl, 0, zpl.Length);
                    requestStream.Close();

                    var response = (HttpWebResponse)request.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var fileStream = File.Create(ImageFilePath + @"\label.PNG"); // change file name for PNG images
                    responseStream.CopyTo(fileStream);
                    responseStream.Close();
                    fileStream.Close();

                    FileStream fileStreamImg = new FileStream(ImageFilePath + @"\label.PNG", FileMode.Open, FileAccess.Read);
                    pictureBox2.Image = Image.FromStream(fileStreamImg);
                    pictureBox2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    fileStreamImg.Close();
                    fileStreamImg.Dispose();

                }
                else
                {
                    if (MyPart.SwitchZebraZPL == "")
                    {
                        sysStatus.Text = "模板内容为空，请稍后重新操作！";
                        clsLoad.strErr = sysStatus.Text;
                        goto AA;
                    }
                    string ImageFilePath = Application.StartupPath + @"\image";

                    if (Directory.Exists(ImageFilePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(ImageFilePath);
                    }

                    byte[] zpl = Encoding.UTF8.GetBytes(MyPart.SwitchZebraZPL);
                    //byte[] zpl = Encoding.Unicode.GetBytes(MyPart.SwitchZebraZPL);

                    // adjust print density (8dpmm), label width (4 inches), label height (6 inches), and label index (0) as necessary
                    //var request = (HttpWebRequest)WebRequest.Create("http://api.labelary.com/v1/printers/8dpmm/labels/4x6/0/");
                    var request = (HttpWebRequest)WebRequest.Create("http://api.labelary.com/v1/printers/8dpmm/labels/4x3/0/");
                    request.Method = "POST";
                    //request.Accept = "application/pdf"; // omit this line to get PNG images back
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = zpl.Length;

                    var requestStream = request.GetRequestStream();
                    requestStream.Write(zpl, 0, zpl.Length);
                    requestStream.Close();

                    var response = (HttpWebResponse)request.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var fileStream = File.Create(ImageFilePath + @"\" + txtCuttingSN.Text + ".PNG"); // change file name for PNG images
                    responseStream.CopyTo(fileStream);
                    responseStream.Close();
                    fileStream.Close();

                    FileStream fileStreamImg = new FileStream(ImageFilePath + @"\" + txtCuttingSN.Text + ".PNG", FileMode.Open, FileAccess.Read);
                    pictureBox2.Image = Image.FromStream(fileStreamImg);
                    pictureBox2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    Bitmap bmp = (Bitmap)pictureBox2.Image;

                    fileStreamImg.Close();
                    fileStreamImg.Dispose();

                }

            }
            catch (Exception ex)
            {
                sysStatus.Text = "图片加载函数错误，重新启动设备！";
                clsLoad.strErr = sysStatus.Text;
                return;
            }
#pragma warning restore CS0168 // 声明了变量，但从未使用过
            sysStatus.Text = "预览数据加载完成！";
            clsLoad.WriteLog(sysStatus.Text);
        AA:
            if (clsLoad.strMarkMode == "M")
            {
                btnPrintPreview.Enabled = true;
                btnPrintPreview.BackColor = groupBox5.BackColor;
            }

        }
        private Image ByteToImage(byte[] bImage)
        {
            if (bImage.Length == 0)
                return null;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bImage);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        //打印数据
        private void btnPrintZPL_Click(object sender, EventArgs e)
        {
            //2、填写数据 3、确认数据    4、加载模板 5、模板转换 6、 打印预览  7、打印标签 8、保存数据  1、更新数据 
            sysStatus.Text = "标签打印中...！";
            clsLoad.WriteLog(sysStatus.Text);
            btnPrintZPL.Enabled = false;
            btnPrintZPL.BackColor = Color.Lime;

            #region  检查数据完整性
            if (btnDataOK.BackColor != Color.Lime)
            {
                sysStatus.Text = "请先确认数据！";
                clsLoad.strErr = sysStatus.Text;
                goto AA;
            }
            #endregion
            strTemp = clsLoad.ReadIniStr("DebugIf", "ImagePrint", "", Application.StartupPath + "\\land.ini");
            if (strTemp == "1")
            {
                clsLoad.Delay(int.Parse(PrintTime));
                if (PrintImage() != "")
                {
                    goto AA;
                }
            }
            else
            {
                clsLoad.Delay(int.Parse(PrintTime));
                if (PrintZPL() != "")
                {
                    goto AA;
                }
            }
             
            
            sysStatus.Text = "标签打印完成！";
            clsLoad.WriteLog(sysStatus.Text);
        AA:

            if (clsLoad.strMarkMode == "M")
            {
                btnPrintZPL.Enabled = true;
                btnPrintZPL.BackColor = groupBox5.BackColor;
            }
        }

        private string CheckCode()
        {
            try
            {
#pragma warning disable CS0219 // 变量已被赋值，但从未使用过它的值
                string str = "";
#pragma warning restore CS0219 // 变量已被赋值，但从未使用过它的值
                //int i = 0, j = 0;
#pragma warning disable CS0168 // 声明了变量，但从未使用过
                DialogResult Res;
#pragma warning restore CS0168 // 声明了变量，但从未使用过
                string strTemp = "";

                if (cmbZHPartType.Text == "")
                {
                    sysStatus.Text = "产品型号内容为空，提取数据中断";
                    clsLoad.strErr = sysStatus.Text;
                    return clsLoad.strErr;
                }

                strTemp = txtPrintCount.Text;
                myregex = new Regex("[^0-9]");
                if ((myregex.IsMatch(strTemp) == true) || (strTemp.Length == 0))
                {
                    sysStatus.Text = "打印次数信息错误，" + strTemp + "不在合法字符[^0-9]内，检查配置文件";
                    clsLoad.strErr = sysStatus.Text;
                    return clsLoad.strErr;
                }

                if (ckSerialUp.Checked == true)
                {

                }

                strTemp = txtSCDate.Text;
                myregex = new Regex("[^0-9]");
                if ((myregex.IsMatch(strTemp) == true) || (strTemp.Length == 0) || (strTemp.Length != 8))
                {
                    sysStatus.Text = "生产日期号信息错误，" + strTemp + "不在合法字符[^0-9]内，检查生产日期号！";
                    clsLoad.strErr = sysStatus.Text;
                    return clsLoad.strErr;
                }

                strTemp = txtZHReelSN.Text;
                myregex = new Regex("[^0-9]");
                if ((myregex.IsMatch(strTemp) == true) || (strTemp.Length == 0) || (strTemp.Length != 3))
                {
                    sysStatus.Text = "厂家序列号信息错误，" + strTemp + "不在合法字符[^0-9]内，检查厂家序列号！";
                    clsLoad.strErr = sysStatus.Text;
                    return clsLoad.strErr;
                }

                strTemp = txtCuttingSN.Text;
                if (strTemp.Length < 6)
                {
                    sysStatus.Text = "分切卷号信息错误，" + strTemp + "小于6位数字符，检查分切卷号！";
                    clsLoad.strErr = sysStatus.Text;
                    return clsLoad.strErr;
                }
                strTemp = txtCuttingSN.Text.Substring(0, 1);
                myregex = new Regex("[^A-Z]");
                if ((myregex.IsMatch(strTemp) == true) || (strTemp.Length == 0))
                {
                    sysStatus.Text = "分切卷号信息错误，" + txtCuttingSN.Text + "第一位字符不在合法字符[^A-Z]内，检查分切卷号！";
                    clsLoad.strErr = sysStatus.Text;
                    return clsLoad.strErr;
                }
                strTemp = txtCuttingSN.Text.Substring(1, txtCuttingSN.Text.Length - 2);
                myregex = new Regex("[^0-9],[^-]");
                if ((myregex.IsMatch(strTemp) == true) || (strTemp.Length == 0))
                {
                    sysStatus.Text = "分切卷号信息错误，" + txtCuttingSN.Text + "中间字符不在合法字符[^0-9]，[^-]内，检查分切卷号！";
                    clsLoad.strErr = sysStatus.Text;
                    return clsLoad.strErr;
                }
                strTemp = txtCuttingSN.Text.Substring(txtCuttingSN.Text.Length - 1, 1);
                //myregex = new Regex("[^R],[^L]");
                if (strTemp != "R" && strTemp != "L")
                {
                    sysStatus.Text = "分切卷号信息错误，" + txtCuttingSN.Text + "第六位字符不是合法字符[^R],[^L]，检查分切卷号！";
                    clsLoad.strErr = sysStatus.Text;
                    return clsLoad.strErr;
                }
                strTemp = txtPartLength.Text;
                myregex = new Regex("[^0-9],[^.]");
                if ((myregex.IsMatch(strTemp) == true) || (strTemp.Length < 1) || (strTemp.Length > 5))
                {
                    sysStatus.Text = "<长度（m）>信息错误，" + strTemp + "不在合法字符[^0-9]内，检查长度信息！";
                    clsLoad.strErr = sysStatus.Text;
                    return clsLoad.strErr;
                }
                //strTemp = txtPartCount.Text;
                //myregex = new Regex("[^0-9],[^.]");
                //if ((myregex.IsMatch(strTemp) == true) || (strTemp.Length < 1) || (strTemp.Length > 6))
                //{
                //    sysStatus.Text = "<平方米（㎡）>信息错误，" + strTemp + "不在合法字符[^0-9],[^.]内，检查平方米信息！";
                //    clsLoad.WriteLog(sysStatus.Text);
                //    MessageBox.Show(sysStatus.Text);
                //    return sysStatus.Text;
                //}

                if (ckRepeat.Checked == true)
                {
                    //检查数据库中是否存在此数据
                    strSQL = "select * from tb_CuttingLog where SYReelNumber='" + txtSYReelNumber.Text + "'";
                    string tempBatchNumber = clsSQL.strGetfield(strSQL);
                    if (tempBatchNumber != "")
                    {
                        sysStatus.Text = "卷号标签" + txtSYReelNumber.Text + "已打印，请查询数据库！";
                        clsLoad.strErr = sysStatus.Text;
                        return clsLoad.strErr;
                    }
                }
                return clsLoad.strErr;
            }
            catch (Exception ex)
            {
                clsLoad.strErr = "CheckCode函数异常" + ex.ToString();
                return clsLoad.strErr;
            }

        }
        private string PrintZPL()
        {
            StringBuilder szStr = new StringBuilder();
            bool tmpPD = false;

            strTemp = clsLoad.ReadIniStr("DebugIf", "IfUse", "", Application.StartupPath + "\\land.ini");
            if (strTemp == "1")
            {
                FilePath = Application.StartupPath + "\\template" + cmbTemplate.Text;
            }
            else
            {
                FilePath = Application.StartupPath + "\\template\\" + MyPart.MarkPath; ;
                comboBox1.Text = MyPart.ZPLPrinter;
            }
            if (txtPrintCount.Text != "" && ckSelePrint.Checked == true)
            {

                int PrintCount = Convert.ToUInt16(txtPrintCount.Text);
                try
                {
                    for (int i = 0; i < PrintCount; i++)
                    {
                        string Print = PrintH.GetPrintString(FilePath, MyPart.PrintDate);//替换后字符串
                        if (i != 0)
                        {
                            Print = Print.Replace("^XA~TA000", "~TA000");//去掉开始命令^XA
                        }
                        Print = Print.Replace("锘?", "");//去除有影响的特殊字符
                        szStr.Append(Print);
                    }
                }
                catch (Exception)
                {
                    sysStatus.Text = "打印函数错误，重新启动设备！";
                    clsLoad.strErr = sysStatus.Text;
                    return clsLoad.strErr;
                }

                tmpPD = zplp.SendStringToPrinter(comboBox1.Text, szStr.ToString());
            }
            else
            {
                sysStatus.Text = "触发打印函数，单张打印！";
                clsLoad.WriteLog(sysStatus.Text);
                tmpPD = zplp.SendStringToPrinter(comboBox1.Text, MyPart.SwitchZebraZPL);
            }

            if (tmpPD == false)
            {
                sysStatus.Text = "打印错误，检查后请重新操作！";
                clsLoad.strErr = sysStatus.Text;
                return clsLoad.strErr;
            }
            return "";

        }

        //提取数据
        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            UpdatecmbZHPartType_Selected();
            //clsLoad.Delay(100);
        }
        private void btnDataOK_Click(object sender, EventArgs e)
        {
            if (btnDataOK.BackColor == Color.Lime && clsLoad.strMarkMode == "M")
            {
                sysStatus.Text = "取消数据确认！";
                clsLoad.WriteLog(sysStatus.Text);
                btnDataOK.Enabled = true;
                btnDataOK.BackColor = groupBox5.BackColor;

                DataStatetr(null, null);
                txtCuttingSN.Enabled = true;
                txtPartLength.Enabled = true;
                // txtPartCount.Enabled = true;
                return;
            }

            sysStatus.Text = "确认数据中...！";
            clsLoad.WriteLog(sysStatus.Text);
            if (clsLoad.strMarkMode == "A")
            {
                btnDataOK.Enabled = false;
            }


            if (txtZHReelSN.Text == "" || txtCuttingSN.Text == "" || txtPartLength.Text == "")
            {
                sysStatus.Text = "数据不完正，请检查数据！";
                clsLoad.strErr = sysStatus.Text;
                return;
            }

            btnDataOK.BackColor = Color.Lime;

            MyPart.CuttingSN = txtCuttingSN.Text;
            MyPart.ZHReelSN = txtZHReelSN.Text;
            MyPart.PartLength = txtPartLength.Text;   
            int indexOfSpace = MyPart.ZHPartModel.IndexOf('m');
            //MyPart.ZHPartModel.Substring(0, indexOfSpace);

            txtPartCount.Text = (float.Parse(txtPartLength.Text) * float.Parse(MyPart.ZHPartModel.Substring(0, indexOfSpace)) / 1000).ToString(); ;
            MyPart.PartCount = txtPartCount.Text ;
            MyPart.ZHPartDate = txtSCDate.Text;
            MyPart.ITODate = cmbSCITODate.Text.Trim();

            //嵩阳批号
            MyPart.SYReelNumber = MyPart.ZHPartSO1CC + "-" + cmbSCITODate.Text.Trim() + "-" + MyPart.CuttingSN;
            txtSYReelNumber.Text = MyPart.SYReelNumber;

            //厂家卷号
            MyPart.ZHReelNumber = MyPart.ZHPartDate + MyPart.ZHReelSN;
            txtZHReelNumber.Text = MyPart.ZHReelNumber;

            //二维码数据
            //MyPart.QRPartNumber = "id:" + MyPart.ZHPartNumber + "&&gk:" + MyPart.ZHPartModel
            //    + "&&qty:" + txtPartCount.Text + @"\E3\8E\A1" + "&&ord:" + MyPart.ZHOrderNumber
            //    + "&&prod:" + MyPart.ZHPartDate + "&&lot:" + MyPart.ZHReelNumber
            //    + "&&supply:" + MyPart.SYSupplierNO + "&&box:" + MyPart.SYReelNumber + "&&mc:" + MyPart.ZHMakePart;

            MyPart.QRPartNumber = "id:" + MyPart.ZHPartNumber + "&&spec:" + MyPart.ZHPartType
                 + "&&lot:" + MyPart.ZHPartDate + "&&qty:" + txtPartCount.Text + "&&box:" + MyPart.ZHReelNumber
                 + "&&ord:" + MyPart.ZHOrderNumber + "&&gys:" + MyPart.SYReelNumber;

            txtQRPartNumber.Text = MyPart.QRPartNumber;


            sysStatus.Text = "确认数据完成...！";
            clsLoad.WriteLog(sysStatus.Text);

            DataStatefa(null, null);
            txtCuttingSN.Enabled = false;
            txtPartLength.Enabled = false;
            //txtPartCount.Enabled = false;

            if (CheckCode() != "")
            {
                return;
            }

            if (clsLoad.strMarkMode == "A")
            {
                tVoidScan();
            }

        }


        /// <summary>
        /// 设置标签模板
        /// </summary>
        private void setMb()
        {
            FilePath = Application.StartupPath + @"\template";

            if (Directory.Exists(FilePath) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(FilePath);
            }
            //遍历路径设置列表
            try
            {
                List<string> list = CommonH.GetFileNameListByPath(FilePath, ".prn");
                cmbTemplate.DataSource = list;
            }
            catch (Exception)
            {
                sysStatus.Text = "设置标签模版函数错误，重新启动设备！";
                clsLoad.strErr = sysStatus.Text;
                return;
            }
        }

        //输入数据栏状态
        private void DataStatefa(object sender, EventArgs e)
        {
            cmbSCSupplier.Enabled = false;
            cmbSCITODate.Enabled = false;
            cmbOrderNumber.Enabled = false;
            cmbZHPartType.Enabled = false;
            if (ckSerialUp.Checked == true)
            {
                txtZHReelSN.Enabled = false;
            }
            txtSCDate.Enabled = false;
            MyDateTime.Enabled = false;
        }
        private void DataStatetr(object sender, EventArgs e)
        {
            cmbSCSupplier.Enabled = true;
            cmbSCITODate.Enabled = true;
            cmbOrderNumber.Enabled = true;
            cmbZHPartType.Enabled = true;
            if (ckSerialUp.Checked == true)
            {
                txtZHReelSN.Enabled = true;
            }
            txtSCDate.Enabled = true;
            MyDateTime.Enabled = true;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            btnReset.BackColor = Color.Lime;
            if (sysReset() != "")
            {
                sysStatus.Text = "系统启动失败:" + clsLoad.strErr;
                MessageBox.Show(sysStatus.Text);
                return;
            }

            btnReset.Enabled = true;
            btnReset.BackColor = groupBox7.BackColor;
        }

        private void cmbZHPartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatecmbZHPartType_Selected();
        }
        private void UpdatecmbZHPartType_Selected()
        {
            if ((cmbZHPartType.Items.Count > 0) && (cmbZHPartType.Text != ""))
            {
                OleDbDataReader thisReader;
                strSQL = string.Format("SELECT top 1 ID,ZHPartS01,ZHMakePart,ZHPartSO1CC,ZHPartModel,BarCode,SN,MarkPath,ZPLPrinter from tb_PartType where ZHPartType='" + cmbZHPartType.Text + "'");
                thisReader = clsSQL.GetDataReader(strSQL);
                if (thisReader.Read())
                {
                    MyPart.ZHMakePart = Convert.ToString(thisReader["ZHMakePart"]);
                    MyPart.ZHPartS01 = Convert.ToString(thisReader["ZHPartS01"]);
                    MyPart.ZHPartSO1CC = Convert.ToString(thisReader["ZHPartSO1CC"]);
                    MyPart.ZHPartModel = Convert.ToString(thisReader["ZHPartModel"]);
                    MyPart.BarCode = Convert.ToString(thisReader["BarCode"]);
                    MyPart.SN = Convert.ToString(thisReader["SN"]);
                    MyPart.MarkPath = Convert.ToString(thisReader["MarkPath"]);
                    MyPart.ZPLPrinter = Convert.ToString(thisReader["ZPLPrinter"]);
                }
                else
                {
                    clsLoad.strErr = "数据库未找供应商" + cmbSCSupplier.Text + "对应的参数信息，请确认添加";
                    return;
                }
                MyPart.ZHPartType = cmbZHPartType.Text;


                txtSYReelNumber.Text = "";
                txtZHReelNumber.Text = "";
                txtTarget1.Text = "";
                txtCuttingSN.Text = "";
                txtPartLength.Text = "";
                txtPartCount.Text = "";
                txtQRPartNumber.Text = "";
                txtZHReelSN.Text = "";

                if (ckSerialUp.Checked == true)
                {
                    if (UpdateSN() != "")
                    {
                        return;
                    }
                    txtZHReelSN.Text = MyPart.SN;
                }

            }
        }

        private void cmbOrderNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatecmbOrderNumber_Selected();
        }
        private void UpdatecmbOrderNumber_Selected()
        {
            if ((cmbOrderNumber.Items.Count > 0) && (cmbOrderNumber.Text != ""))
            {
                OleDbDataReader thisReader;
                strSQL = string.Format("SELECT top 1 ID,ZHPartNumber from tb_OrderNumber where OrderNumber='" + cmbOrderNumber.Text + "'");

                thisReader = clsSQL.GetDataReader(strSQL);
                if (thisReader.Read())
                {
                    MyPart.ZHPartNumber = Convert.ToString(thisReader["ZHPartNumber"]);
                }
                else
                {
                    clsLoad.strErr = "数据库未找供应商" + cmbSCSupplier.Text + "对应的参数信息，请确认添加";
                    return;
                }
                MyPart.ZHOrderNumber = cmbOrderNumber.Text;
                txtZHPartNumber.Text = MyPart.ZHPartNumber;

            }
        }

        private void cmbSCSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbCount++;
            //if ((intcmbSCSupplier == cmbSCSupplier.SelectedIndex) || (intcmbSCSupplier == -1))
            //{
            UpdatecmbPartName_Selected();
            //}
            //else
            //{
            //    MessageBox.Show("操作错误，无法更改选择", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cmbSCSupplier.SelectedIndex = intcmbSCSupplier;
            //}
        }
        private void UpdatecmbPartName_Selected()
        {
            if ((cmbSCSupplier.Items.Count > 0) && (cmbSCSupplier.Text != ""))
            {
                OleDbDataReader thisReader;
                strSQL = string.Format("SELECT top 1 ID,SCSupplierNO,ROHS from tb_SYSupplier where SCSupplier='" + cmbSCSupplier.Text + "'");

                thisReader = clsSQL.GetDataReader(strSQL);
                if (thisReader.Read())
                {
                    MyPart.SYSupplierNO = Convert.ToString(thisReader["SCSupplierNO"]);
                    MyPart.SYROHS = Convert.ToString(thisReader["ROHS"]);
                }
                else
                {
                    clsLoad.strErr = "数据库未找供应商" + cmbSCSupplier.Text + "对应的参数信息，请确认添加";
                    return;
                }

                MyPart.SYSupplier = cmbSCSupplier.Text;

            }
        }
        private void MarkedRecode()
        {

            string strsql = "select top 100 * from tb_CuttingLog  order by ID desc";

            OleDbDataAdapter mark_da = new OleDbDataAdapter();
            DataSet mark_ds = new DataSet();
            OleDbCommand thisCommand = new OleDbCommand(strsql);
            thisCommand.Connection = Conn;
            mark_da.SelectCommand = thisCommand;
            mark_da.Fill(mark_ds, "tb_mark");
            dataGridView1.DataSource = mark_ds.Tables[0];



            //SqlConnection thisconnection = new SqlConnection(clsSQL.strConnect());
            //SqlDataAdapter da = new SqlDataAdapter(strsql, thisconnection);
            //SqlCommandBuilder sb = new SqlCommandBuilder(da);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
            ////dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ////dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ////dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ////dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ////dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ////dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns[0].Width = 22;
            ////dataGridView1.Columns[1].Width = 150;
            ////dataGridView1.Columns[2].Width = 250;

        }
        private void GetPrintList()
        {
            List<string> lt = new List<string>();
            var printers = PrinterSettings.InstalledPrinters;
            foreach (var item in printers)
            {
                lt.Add(item.ToString());
            }
            comboBox1.DataSource = lt;
        }
        private void fillcmbSCSupplier()
        {
            strSQL = "select SCSupplier from tb_SYSupplier order by ID asc ";
            str = clsSQL.strGetfields(strSQL);
            cmbSCSupplier.Items.Clear();
            b = str.Split(new char[] { '@' });
            foreach (object s in b)
            {
                if (s.ToString().Length > 0)
                    cmbSCSupplier.Items.Add(s);
            }
            cmbSCSupplier.Items.Add("");

            if (cmbSCSupplier.Items.Count > 0)
            {
                cmbSCSupplier.SelectedIndex = 0;
            }

        }
        private void fillcmbSCITODate()
        {
            strSQL = "select SCITODate from tb_ITODate order by ID asc ";
            str = clsSQL.strGetfields(strSQL);
            cmbSCITODate.Items.Clear();
            b = str.Split(new char[] { '@' });
            foreach (object s in b)
            {
                if (s.ToString().Length > 0)
                    cmbSCITODate.Items.Add(s);
            }
            cmbSCITODate.Items.Add("");

            if (cmbSCITODate.Items.Count > 0)
            {
                cmbSCITODate.SelectedIndex = 0;
            }
        }
        private void fillcmbOrderNumber()
        {
            strSQL = "select OrderNumber from tb_OrderNumber order by ID asc ";
            str = clsSQL.strGetfields(strSQL);
            cmbOrderNumber.Items.Clear();
            b = str.Split(new char[] { '@' });
            foreach (object s in b)
            {
                if (s.ToString().Length > 0)
                    cmbOrderNumber.Items.Add(s);
            }
            cmbOrderNumber.Items.Add("");

            if (cmbOrderNumber.Items.Count > 0)
            {
                cmbOrderNumber.SelectedIndex = 0;
            }
        }
        private void fillcmbZHPartType()
        {
            strSQL = "select ZHPartType from tb_PartType order by ID asc ";
            str = clsSQL.strGetfields(strSQL);
            cmbZHPartType.Items.Clear();
            b = str.Split(new char[] { '@' });
            foreach (object s in b)
            {
                if (s.ToString().Length > 0)
                    cmbZHPartType.Items.Add(s);
            }
            cmbZHPartType.Items.Add("");

            if (cmbZHPartType.Items.Count > 0)
            {
                cmbZHPartType.SelectedIndex = 0;
            }
        }
        private void cmbSCITODate_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyPart.ITODate = cmbSCITODate.Text;
        }

        //生成二维码
        private void btnQRCode_Click(object sender, EventArgs e)
        {
            sysStatus.Text = "生成二维码中...！";
            clsLoad.WriteLog(sysStatus.Text);
            btnQRCode.Enabled = false;
            btnQRCode.BackColor = Color.Lime;

            sysStatus.Text = "二维码生产完成...！";
            clsLoad.WriteLog(sysStatus.Text);
            if (clsLoad.strMarkMode == "M")
            {
                btnQRCode.Enabled = true;
                btnQRCode.BackColor = groupBox5.BackColor;
            }

            //txtDimerNumber.Text = datatime + "-" + txtDimerBatchNum.Text + "-" + txtBatchNumber.Text + "/" + txtBatchSum.Text;

            ////检查数据库中是否存在此数据
            //strSQL = "select * from tb_Warehouse where DimerNumber='" + txtDimerNumber.Text + "'";
            //string tempBatchNumber = clsSQL.strGetfield(strSQL);
            //if (tempBatchNumber != "")
            //{
            //    sysStatus.Text = "原膜批号已存在数据库，请查询数据库！";
            //    MessageBox.Show(sysStatus.Text);
            //    clsLoad.strErr = sysStatus.Text;
            //    return;
            //}

            //if (txtDimerNumber.Text.Length < 12)
            //{
            //    sysStatus.Text = "原膜批号字符长度小于12位，请检查数据！";
            //    MessageBox.Show(sysStatus.Text);
            //    clsLoad.strErr = sysStatus.Text;
            //    return;
            //}

            //MPBarCodeNumber = datatime + txtDimerBatchNum.Text + txtBatchNumber.Text + txtBatchSum.Text;
            //// Application.StartupPath + "\\BarCode-" + datatime + ".jpg";
            //strTemp = Application.StartupPath + "\\QRCodelog" + "\\QRCode-" + MPBarCodeNumber + ".png";

            ////生成图片并保存
            //clsLoad.QR_CODEContent(strTemp, txtDimerNumber.Text);

            sysStatus.Text = "二维码生产完成...！";
            clsLoad.WriteLog(sysStatus.Text);
            if (clsLoad.strMarkMode == "M")
            {
                btnQRCode.Enabled = true;
                btnQRCode.BackColor = groupBox5.BackColor;
            }

        }

        //检查二维码数据
        private void btnCKQRCode_Click(object sender, EventArgs e)
        {
            sysStatus.Text = "检查生成二维码数据是否正确！";
            clsLoad.WriteLog(sysStatus.Text);
            btnCKQRCode.Enabled = false;
            btnCKQRCode.BackColor = Color.Lime;

            //txtDimerNumber.Text = datatime + "-" + txtDimerBatchNum.Text + "-" + txtBatchNumber.Text + "/" + txtBatchSum.Text;
            //MPBarCodeNumber = datatime + txtDimerBatchNum.Text + txtBatchNumber.Text + txtBatchSum.Text;
            //// Application.StartupPath + "\\BarCode-" + datatime + ".jpg";
            //strTemp = Application.StartupPath + "\\QRCodelog" + "\\QRCode-" + MPBarCodeNumber + ".png";

            ////读取条码数据
            //strTemp = clsLoad.ReadQR_CODE(strTemp);
            //if (txtDimerNumber.Text != strTemp)
            //{
            //    sysStatus.Text = "二维码生成错误，请复位后重新生成或联系技术员处理！";
            //    clsLoad.WriteLog(sysStatus.Text);

            //    clsLoad.strErr = "二维码生成错误，请复位后重新生成或联系技术员处理！";
            //    return;
            //}
            sysStatus.Text = "二维码检验完成：" + strTemp;
            clsLoad.WriteLog(sysStatus.Text);
            if (clsLoad.strMarkMode == "M")
            {
                btnCKQRCode.Enabled = true;
                btnCKQRCode.BackColor = groupBox5.BackColor;
            }

        }

        private void ckSelePrint_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSelePrint.Checked == true)
            {
                if (txtPrintCount.Text == "")
                {
                    sysStatus.Text = "打印次数信息错误，不在合法字符[^0-9]内，请填写正确数字后选择";
                    clsLoad.WriteLog(sysStatus.Text);
                    ckSelePrint.Checked = false;
                }
                else
                {
                    strTemp = txtPrintCount.Text;
                    myregex = new Regex("[^0-9]");
                    if ((myregex.IsMatch(strTemp) == true) || (strTemp.Length == 0))
                    {
                        sysStatus.Text = "打印次数信息错误，" + strTemp + "不在合法字符[^0-9]内，请填写正确数字后选择";
                        clsLoad.WriteLog(sysStatus.Text);
                        ckSelePrint.Checked = false;
                    }
                    else
                    { txtPrintCount.Enabled = false; }
                }

            }
            else
            { txtPrintCount.Enabled = true; }
        }

        private void ckSerialUp_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSerialUp.Checked == true)
            {
                if (txtZHReelSN.Text == "")
                {
                    sysStatus.Text = "厂家序列号信息错误，不在合法字符[^0-9]内，请填写正确数字后选择";
                    clsLoad.WriteLog(sysStatus.Text);
                    ckSerialUp.Checked = false;
                }
                else
                {
                    strTemp = txtZHReelSN.Text;
                    myregex = new Regex("[^0-9]");
                    if ((myregex.IsMatch(strTemp) == true) || (strTemp.Length == 0))
                    {
                        sysStatus.Text = "厂家序列号信息错误，" + strTemp + "不在合法字符[^0-9]内，请填写正确数字后选择";
                        clsLoad.WriteLog(sysStatus.Text);
                        ckSerialUp.Checked = false;
                    }
                    else
                    { txtZHReelSN.Enabled = false; }
                }

            }
            else
            { txtZHReelSN.Enabled = true; }
        }

        private byte[] ImageToByte(Image image)
        {
            MemoryStream ms = new MemoryStream();
            if (image == null)
                return new byte[ms.Length];
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] BPicture = new byte[ms.Length];
            BPicture = ms.GetBuffer();
            return BPicture;
        }

        private string PrintImage()
        {
            sysStatus.Text = "使用图像指令打印中...！";
            clsLoad.WriteLog(sysStatus.Text);
            btnPrinter.Enabled = false;
            btnPrinter.BackColor = Color.Lime;

            strTemp = clsLoad.ReadIniStr("DebugIf", "IfUse", "", Application.StartupPath + "\\land.ini");
            if (strTemp == "1")
            {
                FilePath = Application.StartupPath + "\\template" + cmbTemplate.Text;
            }
            else
            {
                FilePath = Application.StartupPath + "\\template\\" + MyPart.MarkPath; ;
                comboBox1.Text = MyPart.ZPLPrinter;
            }

            Bitmap img = new Bitmap(Application.StartupPath + @"\image" + @"\" + txtCuttingSN.Text + ".PNG");
            strTemp = ZebraUnity.getZPLString(img);
            bool tmpPD = false;
            if (txtPrintCount.Text != "" && ckSelePrint.Checked == true)
            {
                int PrintCount = Convert.ToUInt16(txtPrintCount.Text);
                for (int i = 0; i < PrintCount; i++)
                {
                    tmpPD = zplp.SendStringToPrinter(comboBox1.Text, strTemp);
                }
            }
            else
            {
                tmpPD = zplp.SendStringToPrinter(MyPart.ZPLPrinter, strTemp);
            }

            if (tmpPD == false)
            {
                sysStatus.Text = "打印错误，检查后请重新操作！";
                clsLoad.strErr = sysStatus.Text;
                return clsLoad.strErr;
            }



            sysStatus.Text = "使用图像指令打印完成！";
            clsLoad.WriteLog(sysStatus.Text);
            btnPrinter.Enabled = true;
            btnPrinter.BackColor = groupBox1.BackColor;
            return "";
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            sysStatus.Text = "使用图像指令打印中...！";
            clsLoad.WriteLog(sysStatus.Text);
            btnPrinter.Enabled = false;
            btnPrinter.BackColor = Color.Lime;
            comboBox1.Text = MyPart.ZPLPrinter;

            string q = "";
            Bitmap img = new Bitmap(Application.StartupPath + @"\image" + @"\" + txtCuttingSN.Text + ".PNG");
            q = ZebraUnity.getZPLString(img);
            bool tmpPD = zplp.SendStringToPrinter(comboBox1.Text, q);

            //FileStream fileStreamImg = new FileStream(ImageFilePath + @"\" + txtCuttingSN.Text + ".PNG", FileMode.Open, FileAccess.Read);
            //pictureBox2.Image = Image.FromStream(fileStreamImg);
            //pictureBox2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            //Bitmap bmp = (Bitmap)pictureBox2.Image;
            //fileStreamImg.Close();
            //fileStreamImg.Dispose();

            #region ESC 热敏图像点阵像素点读取打印
            //Bitmap bitmap = new Bitmap(@"D:\450X100.bmp");
            //NetPOSPrinter netPOSPrinter = new NetPOSPrinter();
            //netPOSPrinter.PrintPic(bitmap);
            #endregion

            //#region EPL USB 打印
            //comboBox1.Text = MyPart.ZPLPrinter;
            //Bitmap img = new Bitmap(Application.StartupPath + @"\image" + @"\" + txtCuttingSN.Text + ".PNG");
            //ZebraPrintHelper.PrinterType = DeviceType.DRV;
            //ZebraPrintHelper.PrinterProgrammingLanguage = ProgrammingLanguage.EPL;
            //ZebraPrintHelper.PrinterName = comboBox1.Text;
            //byte[] imgByte = ImageToByte(img);
            //ZebraPrintHelper.PrintGraphics(imgByte);
            //#endregion

            #region ZPL II 打印指令
            //^XA^CFD
            //^POI
            //^LH330,10
            //^FO50,50
            //^FDSMARTDIGITAL^FS
            //^FO50,75
            //^FD021-51871630^FS
            //^XZ

            //StringBuilder sb = new StringBuilder();
            //sb.Append("^XA^CFD");
            //sb.Append("^POI");
            //sb.Append("^LH330,10");
            //sb.Append("^FO50,50");
            //sb.Append("^FDSMARTDIGITAL^FS");
            //sb.Append("^FO50,75");
            //sb.Append("^FD021-51871630^FS");
            //sb.Append("^XZ");

            //byte[] cmd = Encoding.Default.GetBytes(sb.ToString());

            #endregion

            #region EPL USB 指令打印
            //ZebraPrintHelper.PrinterProgrammingLanguage = ProgrammingLanguage.EPL;
            //ZebraPrintHelper.PrinterName = "ZDesigner GK888t (EPL)";
            //ZebraPrintHelper.PrinterType = DeviceType.DRV;

            //string cmd = "N" + "\r\n" +
            //    "Q400,025" + "\n\r" +
            //    "A140,45,0,8,1,1,N,\"古典黄芥沫调味酱\"" + "\r\n" +
            //    "A140,90,0,8,1,1,N,\"规格:\"" + "\r\n" +
            //    "A240,95,0,4,1,1,N,\"" + "100ML/瓶" + "\"" + "\r\n" +
            //    "A140,135,0,8,1,1,N,\"生产日期:\"" + "\r\n" +
            //    "A300,140,0,4,1,1,N,\"" + "2015-10-02" + "\"" + "\r\n" +
            //    "B140,180,0,1,3,2,100,B,\"" + "8957891234567895789588535" + "\"" + "\r\n" +
            //    "P1" + "\r\n";

            //ZebraPrintHelper.PrintCommand(cmd.ToString());
            #endregion

            sysStatus.Text = "使用图像指令打印完成！";
            clsLoad.WriteLog(sysStatus.Text);
            btnPrinter.Enabled = true;
            btnPrinter.BackColor = groupBox1.BackColor;

        }
    }
}
