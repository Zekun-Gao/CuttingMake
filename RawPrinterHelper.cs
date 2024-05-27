using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;

namespace CuttingMake
{
    class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        /// <summary>  
        /// 日志保存目录，WEB应用注意不能放在BIN目录下。  
        /// </summary>  
        public static string LogsDirectory { get; set; }

        private static byte[] GraphBuffer { get; set; }
        private static int GraphWidth { get; set; }
        private static int GraphHeight { get; set; }

        private static int RowSize
        {
            get
            {
                return (((GraphWidth) + 31) >> 5) << 2;
            }
        }

        private static int RowRealBytesCount
        {
            get
            {
                if ((GraphWidth % 8) > 0)
                {
                    return GraphWidth / 8 + 1;
                }
                else
                {
                    return GraphWidth / 8;
                }
            }
        }

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }
        #region 生成ZPL图像打印指令
        private static byte[] getBitmapData()
        {
            MemoryStream srcStream = new MemoryStream();
            MemoryStream dstStream = new MemoryStream();
            Bitmap srcBmp = null;
            Bitmap dstBmp = null;
            byte[] srcBuffer = null;
            byte[] dstBuffer = null;
            byte[] result = null;
            try
            {
                srcStream = new MemoryStream(GraphBuffer);
                srcBmp = Bitmap.FromStream(srcStream) as Bitmap;
                srcBuffer = srcStream.ToArray();
                GraphWidth = srcBmp.Width;
                GraphHeight = srcBmp.Height;
                dstBmp = srcBmp.Clone(new Rectangle(0, 0, srcBmp.Width, srcBmp.Height), PixelFormat.Format1bppIndexed);
                dstBmp.Save(dstStream, ImageFormat.Bmp);
                dstBuffer = dstStream.ToArray();

                int bfSize = BitConverter.ToInt32(dstBuffer, 2);
                int bfOffBits = BitConverter.ToInt32(dstBuffer, 10);
                int bitmapDataLength = bfSize - bfOffBits;
                result = new byte[GraphHeight * RowRealBytesCount];

                //读取时需要反向读取每行字节实现上下翻转的效果，打印机打印顺序需要这样读取。  
                for (int i = 0; i < GraphHeight; i++)
                {
                    Array.Copy(dstBuffer, bfOffBits + (GraphHeight - 1 - i) * RowSize, result, i * RowRealBytesCount, RowRealBytesCount);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (srcStream != null)
                {
                    srcStream.Dispose();
                    srcStream = null;
                }
                if (dstStream != null)
                {
                    dstStream.Dispose();
                    dstStream = null;
                }
                if (srcBmp != null)
                {
                    srcBmp.Dispose();
                    srcBmp = null;
                }
                if (dstBmp != null)
                {
                    dstBmp.Dispose();
                    dstBmp = null;
                }
            }
            return result;
        }
        #endregion

        #region 生成ZPL图像打印指令
        private static byte[] getZPLBytes()
        {
            byte[] result = new byte[0];
            byte[] bmpData = getBitmapData();
            string textBitmap = string.Empty;
            string textHex = BitConverter.ToString(bmpData).Replace("-", string.Empty);
            for (int i = 0; i < GraphHeight; i++)
            {
                textBitmap += textHex.Substring(i * RowRealBytesCount * 2, RowRealBytesCount * 2) + "\r\n";
            }
            string text = string.Format("~DGR:IMAGE.GRF,{0},{1},\r\n{2}^XGR:IMAGE.GRF,1,1^FS\r\n^IDR:IMAGE.GRF\r\n",
                GraphHeight * RowRealBytesCount,
                RowRealBytesCount,
                textBitmap);
            result = Encoding.Default.GetBytes(text);
            return result;
        }
        #endregion

        public bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString); //源程序字符转换
            //pBytes = Marshal.StringToCoTaskMemUTF8(szString);
            //pBytes = Marshal.StringToCoTaskMemAuto(szString);
            //pBytes = Marshal.StringToCoTaskMemUni(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
}
