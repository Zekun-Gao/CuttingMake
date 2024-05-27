using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;
using Xceed.Words.NET;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.Office.Interop.Word;


namespace CuttingMake
{
    class clsWord
    {

        public static bool Print(string fileName)
        {
            try
            {
                var word = new Microsoft.Office.Interop.Word.Application { Visible = false }; // 启动Word进程
                var doc = word.Documents.Open(fileName, ReadOnly: true, Visible: System.Reflection.Missing.Value); // 打开待打印的文档
                doc.PrintOut(); // 打印
                clsLoad.Delay(1000);
                doc.Close(SaveChanges: false); // 关闭文档
                word.Quit(SaveChanges: false); // 退出Word进程
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }

        //System.Diagnostics.Process p = new System.Diagnostics.Process();
        ////不现实调用程序窗口,但是对于某些应用无效
        //p.StartInfo.CreateNoWindow = true;
        //p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

        ////采用操作系统自动识别的模式
        //p.StartInfo.UseShellExecute = true;

        ////要打印的文件路径
        //p.StartInfo.FileName = @"d:\a.doc";

        ////指定执行的动作，是打印，即print，打开是 open
        //p.StartInfo.Verb = "print";

        ////获取当前默认打印机

        //string defaultPrinter = GetDefaultPrinter();

        ////将指定的打印机设为默认打印机
        //SetDefaultPrinter("指定的打印机");

        ////开始打印
        //p.Start();

        ////等待十秒
        //p.WaitForExit(10000);

        ////将默认打印机还原
        //SetDefaultPrinter(defaultPrinter);





        ///文档替换文字
        /// <param name="tempPath">Word 文件 模板路径</param>
        /// <param name="newWordPath">生成的新 Word 文件的路径</param>
        //public static bool WordtxtTotxt(string tempPath, string newWordPath)
        //{
        //    var doc = DocX.Load(tempPath);  // 加载 Word 模板文件


        //}


        /// <summary>
        /// Word 模板 替换
        /// <para>当前适用的字段模板形如：[=Name]，其中 Name 就是字段名</para>
        /// <para>返回 true 表示成功</para>
        /// </summary>
        /// <param name="tempPath">Word 文件 模板路径</param>
        /// <param name="newWordPath">生成的新 Word 文件的路径</param>
        /// <param name="textDic">文字字典集合</param>
        /// <param name="imgDic">图片字典集合</param>
        /// <returns></returns>
        public static bool WordTemplateReplace(string tempPath, string newWordPath,
            Dictionary<string, string> textDic,
            Dictionary<string, WordImg> imgDic = null)
        {
#pragma warning disable CS0168 // 声明了变量，但从未使用过
            try
            {
                var doc = DocX.Load(tempPath);  // 加载 Word 模板文件

                #region 字段替换文字

                if (textDic != null && textDic.Count > 0)
                {
                    foreach (var paragraph in doc.Paragraphs)   // 遍历当前 Word 文件中的所有（段落）段
                    {
                        foreach (var texts in textDic)
                        {
#pragma warning disable CS0168 // 声明了变量，但从未使用过
                            try
                            {
#pragma warning disable CS0618 // 类型或成员已过时
                                paragraph.ReplaceText($"[={texts.Key}]", texts.Value);  // 替换段落中的文字
#pragma warning restore CS0618 // 类型或成员已过时
                            }
                            catch (Exception ex)
                            {
                                // 不处理
                                continue;
                            }
#pragma warning restore CS0168 // 声明了变量，但从未使用过
                        }
                    }

                    foreach (var table in doc.Tables)   // 遍历当前 Word 文件中的所有表格
                    {
                        foreach (var row in table.Rows) // 遍历表格中的每一行
                        {
                            foreach (var cell in row.Cells)     //遍历每一行中的每一列
                            {
                                foreach (var paragraph in cell.Paragraphs)  // 遍历当前表格里的所有（段落）段
                                {
                                    foreach (var texts in textDic)
                                    {
#pragma warning disable CS0168 // 声明了变量，但从未使用过
                                        try
                                        {
#pragma warning disable CS0618 // 类型或成员已过时
                                            paragraph.ReplaceText($"[={texts.Key}]", texts.Value);  // 替换段落中的文字
#pragma warning restore CS0618 // 类型或成员已过时
                                        }
                                        catch (Exception ex)
                                        {
                                            // 不处理
                                            continue;
                                        }
#pragma warning restore CS0168 // 声明了变量，但从未使用过
                                    }
                                }
                            }
                        }
                    }
                }

                #endregion
                #region 字段替换图片

                if (imgDic != null && imgDic.Count > 0)
                {
                    foreach (var paragraph in doc.Paragraphs)
                    {
                        foreach (var imgItem in imgDic)
                        {
#pragma warning disable CS0168 // 声明了变量，但从未使用过
                            try
                            {
                                var list = paragraph.FindAll($"[={imgItem.Key}]");
                                if (list != null && list.Count > 0)
                                {
                                    Image img = doc.AddImage(imgItem.Value.Path);
                                    Picture pic = img.CreatePicture();
                                    pic.Width = imgItem.Value.Width;
                                    pic.Height = imgItem.Value.Height;
                                    var p = paragraph.InsertPicture(pic, list[0]);
#pragma warning disable CS0618 // 类型或成员已过时
                                    p.ReplaceText($"[={imgItem.Key}]", string.Empty);
#pragma warning restore CS0618 // 类型或成员已过时
                                }
                            }
                            catch (Exception ex)
                            {
                                // 不处理
                                continue;
                            }
#pragma warning restore CS0168 // 声明了变量，但从未使用过
                        }
                    }

                    foreach (var table in doc.Tables)
                    {
                        foreach (var row in table.Rows)
                        {
                            foreach (var cell in row.Cells)
                            {
                                foreach (var paragraph in cell.Paragraphs)
                                {
                                    foreach (var imgItem in imgDic)
                                    {
#pragma warning disable CS0168 // 声明了变量，但从未使用过
                                        try
                                        {
                                            var list = paragraph.FindAll($"[={imgItem.Key}]");
                                            if (list != null && list.Count > 0)
                                            {
                                                Image img = doc.AddImage(imgItem.Value.Path);
                                                Picture pic = img.CreatePicture();
                                                pic.Width = imgItem.Value.Width;
                                                pic.Height = imgItem.Value.Height;
                                                var p = paragraph.InsertPicture(pic, list[0]);
#pragma warning disable CS0618 // 类型或成员已过时
                                                p.ReplaceText($"[={imgItem.Key}]", string.Empty);
#pragma warning restore CS0618 // 类型或成员已过时
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            // 不处理
                                            continue;
                                        }
#pragma warning restore CS0168 // 声明了变量，但从未使用过
                                    }
                                }
                            }
                        }
                    }
                }

                #endregion

                doc.SaveAs(newWordPath);

                return true;
            }
            catch (Exception ex)
            {
                // 不处理
                return false;
            }
#pragma warning restore CS0168 // 声明了变量，但从未使用过
        }


        /// <summary>
        /// 向 Word 文件中插入图片所需的结构体
        /// </summary>
        public struct WordImg
        {
            /// <summary>
            /// WordImg 构造函数
            /// </summary>
            /// <param name="path">目标图片的路径</param>
            /// <param name="width">图片在 Word 文件中所显示的宽度</param>
            /// <param name="height">图片在 Word 文件中所显示的高度</param>
            public WordImg(string path, int width, int height)
            {
                Path = path;
                Width = width;
                Height = height;
            }

            /// <summary>
            /// 目标图片的路径
            /// </summary>
            public string Path { get; set; }

            /// <summary>
            /// 图片在 Word 文件中所显示的宽度
            /// </summary>
            public int Width { get; set; }

            /// <summary>
            /// 图片在 Word 文件中所显示的高度
            /// </summary>
            public int Height { get; set; }
        }



        



    }
}
