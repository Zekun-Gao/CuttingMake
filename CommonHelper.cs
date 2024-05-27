using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CuttingMake
{
    public class CommonHelper
    {
        /// <summary>
        /// 获取指定文件夹下所有指定后缀的文件名集合
        /// </summary>
        /// <param name="path">地址</param>
        /// <param name="postfix">后缀</param>
        /// <returns>指定后缀的文件名集合</returns>
        public List<string> GetFileNameListByPath(string path, string postfix)
        {
            List<string> list = new List<string>();
            string[] filenames = Directory.GetFiles(path);
            int postLen = postfix.Length; //后缀长度 ex:   .licence 9
            foreach (string files in filenames)
            {
                string tmpFileName = files.Replace(path, "");  //获取文件名
                if (tmpFileName.Length <= postLen)
                {
                    continue;
                }
                string tmpHZ = tmpFileName.Substring(tmpFileName.Length - postLen);    //获取后缀
                if (tmpHZ == postfix)
                {//如果后缀与规定后缀一致 则加入列表
                    list.Add(files.Replace(path, ""));
                }
            }
            return list;
        }
        public string getBoxFlie(string _path)
        {
            FileStream fs = new FileStream(_path, FileMode.Open);
            fs.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(fs, Encoding.Default);
            Byte[] b = new Byte[fs.Length];
            ASCIIEncoding temp = new ASCIIEncoding();
            string str = "";
            b = br.ReadBytes(b.Length);
            str = Encoding.Default.GetString(b);
            fs.Close();
            br.Close();
            return str;
        }
    }
}
