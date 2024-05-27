using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using ZXing.Common;
using ZXing.QrCode;
using System.Drawing.Imaging;
using ZXing;
using System.Drawing;

namespace CuttingMake
{
    class clsLoad
    {
        //        虽然C#中没有,但是在"kernel32.dll"这个文件中有Win32的API函数--WritePrivateProfileString()和GetPrivateProfileString()
        //C#声明INI文件的写操作函数WritePrivateProfileString():
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        //参数说明：section：INI文件中的段落；key：INI文件中的关键字；val：INI文件中关键字的数值；filePath：INI文件的完整的路径和名称。
        //C＃申明INI文件的读操作函数GetPrivateProfileString(): 
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        //参数说明：section：INI文件中的段落名称；key：INI文件中的关键字；def：无法读取时候时候的缺省数值；retVal：读取数值；size：数值的大小；filePath：INI文件的完整路径和名称。
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool EndDialog(IntPtr hDlg, out IntPtr nResult);


        public static System.Timers.Timer tAlarm = new System.Timers.Timer(8000);  //实例化Timer类，设置间隔时间为10000毫秒；



        private static string userId = null;
        private static string userPwd = null;
        public static string strErr = null;//系统故障标志位
        public static string strErrStop = null;//打标急停标志位
        public static string strMarkPath = null;
        public static string strChannal = null;
        public static string strMarkMode = null;
        public static string fileName = null;
        public static int totalCount = 0;
        public static bool eStop = false;
        public static bool snAdd = false;

        public static bool NoCarInfo = false;

        public static bool IsExit = false;


        public static bool IsMarkCheckIstatus = false;

        public static int SV_count = 0;
        public static int PV_count = 0;

        public static int SV_Alarm = 0; //时钟只允许2次计数！


        public static int SV_RcvZeroDelay = 0;


        public static string MarkUser = null;//操作者
        public static string UserPassword = null;//操作者
        public static string LoadLevel = null;//操作者
        public static string LoadClass = null;//班次

        //public static string intCount = 0;//系统故障标志位，又不完全是

        public struct PartType
        {
#pragma warning disable CS0649 // 从未对字段“clsLoad.PartType.PartID”赋值，字段将一直保持其默认值 null
            public string PartID;
#pragma warning restore CS0649 // 从未对字段“clsLoad.PartType.PartID”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“clsLoad.PartType.PartNo”赋值，字段将一直保持其默认值 null
            public string PartNo;
#pragma warning restore CS0649 // 从未对字段“clsLoad.PartType.PartNo”赋值，字段将一直保持其默认值 null
            //public string PartName;
#pragma warning disable CS0649 // 从未对字段“clsLoad.PartType.Prefix”赋值，字段将一直保持其默认值 null
            public string Prefix;
#pragma warning restore CS0649 // 从未对字段“clsLoad.PartType.Prefix”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“clsLoad.PartType.Suffix”赋值，字段将一直保持其默认值 null
            public string Suffix;
#pragma warning restore CS0649 // 从未对字段“clsLoad.PartType.Suffix”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“clsLoad.PartType.BarCode”赋值，字段将一直保持其默认值 null
            public string BarCode;
#pragma warning restore CS0649 // 从未对字段“clsLoad.PartType.BarCode”赋值，字段将一直保持其默认值 null
            //public string SN;
            //public string SN_Date;
#pragma warning disable CS0649 // 从未对字段“clsLoad.PartType.MarkNum”赋值，字段将一直保持其默认值 0
            public int MarkNum;
#pragma warning restore CS0649 // 从未对字段“clsLoad.PartType.MarkNum”赋值，字段将一直保持其默认值 0
#pragma warning disable CS0649 // 从未对字段“clsLoad.PartType.MarkPath”赋值，字段将一直保持其默认值 null
            public string MarkPath;
#pragma warning restore CS0649 // 从未对字段“clsLoad.PartType.MarkPath”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“clsLoad.PartType.PLCIndex”赋值，字段将一直保持其默认值 null
            public string PLCIndex;
#pragma warning restore CS0649 // 从未对字段“clsLoad.PartType.PLCIndex”赋值，字段将一直保持其默认值 null
            //public string ServoStep;           
        }
        public struct UpExcel
        {
#pragma warning disable CS0649 // 从未对字段“clsLoad.UpExcel.SYReelNumber”赋值，字段将一直保持其默认值 null
            public string SYReelNumber;
#pragma warning restore CS0649 // 从未对字段“clsLoad.UpExcel.SYReelNumber”赋值，字段将一直保持其默认值 null
            public string CuttingSN;
            public string PartLength;
#pragma warning disable CS0649 // 从未对字段“clsLoad.UpExcel.ITODate”赋值，字段将一直保持其默认值 null
            public string ITODate;
#pragma warning restore CS0649 // 从未对字段“clsLoad.UpExcel.ITODate”赋值，字段将一直保持其默认值 null





        }

        public struct CuttingPart
        {
            public string ZebraZPL;
            public string SwitchZebraZPL;

            public string SYSupplier;
            public string SYSupplierNO;
            public string SYROHS;

            public string ZHPartNumber;
            public string ZHPartType;
            public string CuttingSN;
            public string PartLength;
            public string PartCount;
            public string ZHOrderNumber;
            public string ZHPartDate;
            public string ZHReelNumber;
            public string ZHReelSN;
            public string ZHPartModel;

            public string SYReelNumber;
            public string ITODate;

            public string ZHPartSO1CC;
            public string ZHPartS01;
            public string ZHMakePart;

            public string BarCode;
            public string SN;
            public string MarkPath;
            public string ZPLPrinter;

            public string QRPartNumber;
#pragma warning disable CS0649 // 从未对字段“clsLoad.CuttingPart.ifReadCheck”赋值，字段将一直保持其默认值 false
            public bool ifReadCheck;
#pragma warning restore CS0649 // 从未对字段“clsLoad.CuttingPart.ifReadCheck”赋值，字段将一直保持其默认值 false
            public string PrintDate;

        }


        public static string UserId
        {
            set
            {
                userId = value;
            }
            get
            {
                return userId;
            }
        }
        public static string UserPwd
        {
            set
            {
                userPwd = value;

            }
            get
            {
                return userPwd;
            }
        }
        //public static string ReadServer()
        //{
        //    return ReadString("Data", "Server", "", Application.StartupPath + "\\land.ini");
        //}

        //public static string ReadPwd()
        //{
        //    return ReadString("Data", "SaPwd", "", Application.StartupPath + "\\land.ini");
        //}
        public static string ReadIniStr(string section, string key, string def, string FileName)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, FileName);
            return temp.ToString();
        }


        /// <summary>
        /// 生成条形码
        ///</summary>
        /// <param name = "filePath”>生成条形码保存地址</param>
        /// < param name="barCodeContent”>条形码内容</param>
        public static void CreateBarCode(string filePath, string barCodeContent)
        {
            ZXing.Common.EncodingOptions options = new ZXing.Common.EncodingOptions()
            {
                Height = 129,//设置宽高
                Width = 200,
                    };
            //生成条形码的图片并保存
            ZXing.BarcodeWriter wr = new ZXing.BarcodeWriter()
            {
                Options = options,//进行指定规格
                Format = ZXing.BarcodeFormat.CODE_128,//条形码的规格
            };
            System.Drawing.Bitmap img = wr.Write(barCodeContent);//生成图片
            img.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            img.Dispose(); //释放资源
                           //System.Diagnostics.Process.Start(filePath); //打开照片

            clsLoad.WriteLog("保存图片，成功：" + barCodeContent);

        }

        /// <summary>
        /// 生成二维码,保存成图片
        /// </summary>
        public static void QR_CODEContent(string filePath, string QR_CODEContent)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.DisableECI = true;
            //设置内容编码
            options.CharacterSet = "UTF-8";
            //设置二维码的宽度和高度
            options.Width = 800;
            options.Height = 800;
            //设置二维码的边距,单位不是固定像素
            options.Margin = 1;
            writer.Options = options;

            Bitmap map = writer.Write(QR_CODEContent);
            //string filePath = @"H:\桌面\截图\generate1.png";
            map.Save(filePath, ImageFormat.Png);
            map.Dispose();

            //System.Diagnostics.Process.Start(filePath); //打开照片
            clsLoad.WriteLog("保存图片，成功：" + QR_CODEContent);
        }



        /// <summary>
        /// 读取条形码
        /// </summary>
        /// <param name="filePath”>读取的条形码地址</param>/// <returns></returns>
        public static string ReadBarCode(string filePath)
        {
            //设置读取规格
            ZXing.Common.DecodingOptions options = new ZXing.Common.DecodingOptions();
            options.PossibleFormats = new System.Collections.Generic.List<ZXing.BarcodeFormat>()
            {
                    ZXing.BarcodeFormat.CODE_128, //指定格式

             };

            //读取
            ZXing.BarcodeReader br = new ZXing.BarcodeReader()
            {
                Options = options
            };
            System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
            //读取条形码内容
            ZXing.Result result = br.Decode(image as System.Drawing.Bitmap);
            return result.Text;
        }

        /// <summary>
        /// 读取二维码
        /// 读取失败，返回空字符串
        /// </summary>
        /// <param name="filename">指定二维码图片位置</param>
        public static string ReadQR_CODE(string filePath)
        {

                BarcodeReader reader = new BarcodeReader();
                reader.Options.CharacterSet = "UTF-8";
                Bitmap map = new Bitmap(filePath);
                Result result = reader.Decode(map);
                return result == null ? "" : result.Text;
        }


        public static void WriteLog(string strErr)  //将错误写到文本文件
        {
            try
            {
                clsLoad.fileName = DateTime.Now.ToString("yyMMdd") + ".log";
                FileStream FS = new FileStream(Application.StartupPath + "\\log\\" + clsLoad.fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(FS, System.Text.Encoding.Default);
                sw.WriteLine(DateTime.Now.ToString() + "     " + strErr);

                sw.Flush();
                sw.Close();
                sw.Dispose();
                FS.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }
        public static void WriteOPCLog(string strErr)  //将错误写到文本文件
        {
            try
            {
                clsLoad.fileName = DateTime.Now.ToString("yyMMdd") + ".log";
                StreamWriter sw = File.AppendText(Application.StartupPath + "\\Opclog\\" + clsLoad.fileName);
                sw.WriteLine(DateTime.Now.ToString() + "     " + strErr);
                sw.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }
        public static string ReadLog(string strPath)
        {
            try
            {
                string strResult = "";
                StreamReader sR = File.OpenText(strPath);
                strResult = sR.ReadLine();
                sR.Close();
                return strResult;



            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return "";

            }


        }

        public static void Delay(int delayTime)  

         {  
             DateTime now = DateTime.Now; 
             double  s;  
             do 
             {  

                 TimeSpan spand = DateTime.Now - now;
                 s = spand.TotalMilliseconds;
                 Application.DoEvents();  
             }  
             while (s < delayTime);            

         }

        private static int[] PowerValue;
        private static int[] VinOfKey;
        private static int[] VinOfValue;

        private static void IntilVIn()
        {
            int i;
            PowerValue = new int[17];
            VinOfKey = new int[36];
            VinOfValue = new int[36];


            for (i = 0; i < 10;i++ )
            {
                 VinOfKey[i]=i+48;
                 VinOfValue[i]=i;
             }

            for (i = 10; i < 18;i++ )
            {
                 VinOfKey[i]=i+55;
                 VinOfValue[i]=i-9;
             }

              for (i = 19; i < 24;i++ )
            {
                 VinOfKey[i]=i+55;
                 VinOfValue[i]=i-18;
             }
            VinOfKey [25]=80;
            VinOfValue[25]=7;

            VinOfKey [27]=82;
            VinOfValue[27]=9;

           for (i = 28; i < 36;i++ )
            {
                 VinOfKey[i]=i+55;
                 VinOfValue[i]=i-26;
             }
             PowerValue[0]=8;
             PowerValue[1]=7;
             PowerValue[2]=6;
             PowerValue[3]=5;
             PowerValue[4]=4;
             PowerValue[5]=3;
             PowerValue[6]=2;
             PowerValue[7]=10;

             PowerValue[8]=32767;

             PowerValue[9]=9;
             PowerValue[10]=8;
             PowerValue[11]=7;
             PowerValue[12]=6;
             PowerValue[13]=5;
             PowerValue[14]=4;
             PowerValue[15]=3;
             PowerValue[16]=2;

        }
        public  static string UnDoPass(string UtempPass)
        {
            string tmp = "";
            int i, j, L, M, A;
            bool K;
            L = (int)(Convert.ToChar(UtempPass.Substring(0, 1))) - 32;
            K = true;
            M = 1;
            for (i = 1; i <= L; i++)
            {
                A = (int)(Convert.ToChar(UtempPass.Substring(M, 1)));
                if (K == true)
                {
                    K = false;
                    A = A - 5;
                }
                else
                {
                    K = true;
                    A = A - 3;
                }
                tmp = tmp + (char)A;
                for (j = 2; j <= Convert.ToInt16(20 / L); j++)
                {
                    M = M + 1;

                }

                M = M + 1;

            }
            return tmp;


        }

        public static string GetPass( string GTempPass)
        {
            

            string tmp  ;
    //Dim i As Byte, J As Byte, K As Boolean
    //Dim A As Integer
            Random Rad=new Random ();
            int tempRandom; 
            Byte i,J;
            bool K;
            int A;
            tmp = ((char)(GTempPass.Length  + 32)).ToString ();
            K =true ;
    //For i = 1 To Len(GTempPass)
    //    A = Asc(Mid(GTempPass, i, 1))
    //    If K Then
    //        K = False
    //        A = A + 5
    //    Else
    //        K = True
    //        A = A + 3
    //    End If
    //    tmp = tmp + Chr(A)
    //    For J = 2 To Int(20 / Len(GTempPass))
    //        tmp = tmp + Chr(Int(78 * Rnd()) + 48)
    //    Next J
    //Next i
            for(i=0;i<GTempPass .Length ;i++)
            {
                A=(int)(Convert .ToChar ( GTempPass .Substring (i,1)));
                if(K)
                {
                    K=false ;
                    A=A+5;
                }
                else
                {
                    K=true ;
                    A=A+3;
                }
                tmp =tmp +((char)(A)).ToString ();

                for (J=2;J<=(20/(GTempPass .Length ));J++)
                {
                    tempRandom =Rad.Next (0,78);
                    tmp =tmp +((char)(tempRandom +48)).ToString ();
                }


            }


    //For i = Len(tmp) + 1 To 21
    //        tmp = tmp + Chr(Int(78 * Rnd()) + 48)
    //Next i
    
    //GetPass = tmp
            for (i =Convert .ToByte(tmp.Length + 1); i <= 21; i++)
            {
                tempRandom = Rad.Next(0, 78);
                tmp = tmp + ((char)(tempRandom + 48)).ToString();
               
            }

            return tmp;
        }


        public static string VINCheck(string strVin)
        {
            int i;
            string Str1,Str2,Str3;
            char chTemp;
            IntilVIn();
            if (strVin.Length != 17)
            {
                return "VIN码位数不等于17位！";
            }
            if (strVin.Substring(0, 3) != "LSJ")
            {
                return "VIN码前3位错误,不是LSJ！";
            }
            //StringComparer strCom;

            //i = string.Compare(Str0, Str1);

            for (i = 0; i < 17;i++ )
            {
                chTemp =Convert.ToChar( strVin.Substring(i, 1));

                if (((chTemp >= '0') && (chTemp <= '9')) || ((chTemp >= 'A') && (chTemp <= 'Z')))
                {
                    if ((chTemp == 'O') || (chTemp == 'I') || (chTemp ==' '))
                    {
                        return "VIN码中有非法字符“" + chTemp + "”";
                    }
             
                }
                else
                {
                    return  "VIN码中有非法字符“" + chTemp + "”检查键盘CAPSLOCK健";
                }
            }

            for (i = 11; i < 17;i++ )
            {
                chTemp =Convert.ToChar( strVin.Substring(i, 1));
                if ((chTemp >= '0') && (chTemp <= '9'))
                {                    
                }
                else
                {
                    return  "VIN码中末5位不是数字字符“" + chTemp + "”";
                }
            }

            Str1 = strVin.Substring(0, 8);
            Str2 = strVin.Substring(9, 8);
            Str1 = Str1 + " " + Str2;
            Str3 = GetValueofCheckCode(Str1);

            return Str3.Trim();
            //if (Str3.Trim()=="")
            //{
            //    return "" ;
            //}
            //else if (Str3.CompareTo(strVin.Substring(8,1))!=0)
            //{
            //    return "校验码错误" + strVin.Substring(8, 1);
            //}
            //else 
            //{
            //    return "" ;
            //}
        }


    ////        If StrComp(Str3, Mid(strVin, 9, 1)) <> 0 Then
    ////            VINCheck = False
        private static string GetValueofCheckCode(string Tmpstring)
        {
            string TmpFtext,TmpLtext;
            int TmpValuebit, TmpTotal=0,i;
            if (Tmpstring.Length != 17)
            {
                return "";
            }
          TmpFtext =Tmpstring.Trim() .Substring(0,8);
          TmpLtext = Tmpstring.Trim().Substring(9, 8);
          for (i = 0; i < 8; i++)
          {
              TmpValuebit = GetValueofKey((int)Convert.ToChar(TmpFtext.Substring(i, 1)));
              if (TmpValuebit == 32767)
              {
                  return "";
              }
              TmpTotal = TmpTotal + TmpValuebit * PowerValue[i];
          }

          for (i = 9; i < 17; i++)
          {
              TmpValuebit = GetValueofKey((int)Convert.ToChar(TmpLtext.Substring(i - 9, 1)));
              if (TmpValuebit == 32767)
              {
                  return "";
              }
              TmpTotal = TmpTotal + TmpValuebit * PowerValue[i];
          }

          if ((TmpTotal % 11) == 10)
          {
              return "X";
          }
          else
          {
              TmpTotal = TmpTotal % 11;
              return TmpTotal.ToString();
          }
        }
     
        //Private Function GetValueofKey(Key As Integer) As Integer
        //    Dim i As Integer
        //    For i = 1 To 36
        //        If Key = VINNumberofKey(i).Key Then
        //            GetValueofKey = VINNumberofKey(i).value
        //            Exit Function
        //        End If
        //    Next i
        //    GetValueofKey = 32767
        //End Function
        private static int GetValueofKey(int Key)
        {
            int i;
            for (i = 0; i < 36; i++)
            {
                if (Key == VinOfKey[i])
                {
                    return VinOfValue[i];
                }
            }
            return 32767;
        }

        /// <summary>
        /// 故障显示函数
        /// </summary>
        /// <param name="Errcode"></param>
        /// <returns></returns>
        public static string SysError(int Errcode)
        {
            switch (Errcode)
            {
                case 1:
                    return "故障代码:" + Errcode.ToString() + ",急停按钮故障";
                case 2:
                    return "故障代码:" + Errcode.ToString() + ",PC运行故障，请故障复位";
                case 3:
                    return "故障代码:" + Errcode.ToString() + ",气缸伸出缩回故障";
                case 4:
                    return "故障代码:" + Errcode.ToString() + ",快换头锁定/松开故障";
                case 5:
                    return "故障代码:" + Errcode.ToString() + ",气压故障";
                case 6:
                    return "故障代码:" + Errcode.ToString() + ",PC手自动故障";
                case 7:
                    return "故障代码:" + Errcode.ToString() + ",PLC与PC匹配型号故障";
                case 8:
                    return "故障代码:" + Errcode.ToString() + ",与永乾PLC通信故障，请检查以太网线连接是否正常！";
                //case 8:
                //    return "故障代码:" + Errcode.ToString() + ",自动运行光栅故障";
                // case 9:
                //     return "故障代码:" + Errcode.ToString() + ",激光设备使能状态报警，请检查信号I2.2";
                // case 10:
                //     return "故障代码:" + Errcode.ToString() + ",设备未设定工件型号报警";
                // case 11:
                //     return "故障代码:" + Errcode.ToString() + ",设备设定型号和机械手不一致";
                // case 12:
                //     return "故障代码:" + Errcode.ToString() + ",打标软件未准备好报警";
                // case 13:
                //     return "故障代码:" + Errcode.ToString() + ",打标软件运行故障报警";
                // case 14:
                //     return "故障代码:" + Errcode.ToString() + ",到位工件与选择工件型号和工件检测不同【品1 EB02=I2.0\\I1.5】【品2 EG01T=I2.1\\I1.6】【品3-EG06B=I2.1\\I1.7】【品4-EB03=I2.0\\I1.5】";
                // case 15:
                //     return "故障代码:" + Errcode.ToString() + ",工件在打标位置检测位置故障，请检查信号I2.0、I2.1";       
                //case 16:
                //      return "故障代码:" + Errcode.ToString() + ",机器人急停或报警故障，无法启动循环";
                //case 17:
                //      return "故障代码:" + Errcode.ToString() + ",未定义";
                //case 18:
                //      return "故障代码:" + Errcode.ToString() + ",未定义";
                //case 19:
                //      return "故障代码:" + Errcode.ToString() + ",二维码校验失败超过3次报警";
                //case 20:
                //      return "故障代码:" + Errcode.ToString() + ",打标超时报警，检查VIS激光状态";
                //case 21:
                //      return "故障代码:" + Errcode.ToString() + ",未定义";
                //case 22:
                //      return "故障代码:" + Errcode.ToString() + ",未定义";
                //case 23:
                //      return "故障代码:" + Errcode.ToString() + ",举升气缸伸出缩回超时报警，请检查信号I1.0、I1.1";
                //case 24:
                //      return "故障代码:" + Errcode.ToString() + ",顶门气缸伸出缩回超时报警，请检查信号I1.2、I1.3";
                //case 25:
                //      return "故障代码:" + Errcode.ToString() + ",到位工件与选择工件型号和工件检测不同((警告)";
                //case 26:
                //      return "故障代码:" + Errcode.ToString() + ",阅读器解码失败((警告)";

                default:
                    return "未定义错误代码：" + Errcode.ToString();
            }
        }

        public static string SysError1(int Errcode1)
        {
            switch (Errcode1)
            {
                case 1:
                    return "故障代码:" + Errcode1.ToString() + ",永乾设备气压异常！";
                case 2:
                    return "故障代码:" + Errcode1.ToString() + ",永乾设备急停按钮触发！";
                case 3:
                    return "故障代码:" + Errcode1.ToString() + ",永乾设备变频器故障！";
                case 4:
                    return "故障代码:" + Errcode1.ToString() + ",永乾左侧热继跳闸！";
                case 5:
                    return "故障代码:" + Errcode1.ToString() + ",永乾右侧热继跳闸！";
                case 6:
                    return "故障代码:" + Errcode1.ToString() + ",永乾设备越位停线！";
                //case 7:
                //    return "故障代码:" + Errcode1.ToString() + ",PLC与PC匹配型号故障";
                //case 8:
                //    return "故障代码:" + Errcode1.ToString() + ",与永乾PLC通信故障，请检查以太网线连接是否正常！";
             

                default:
                    return "未定义错误代码：" + Errcode1.ToString();
            }
        }

        public static bool bolPingResult(string ip)
        {
            try
            {
                System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
                options.DontFragment = true;
                string data = "aa";
                byte[] buffer = Encoding.ASCII.GetBytes(data); //Wait seconds for a reply. 
                int timeout = 1000;
                System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout, buffer, options);
                p.Dispose();

                if (reply.Status.ToString() != "Success")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }



       

    }



}
