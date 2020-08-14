using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RemoveTxtLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            const string filePath = @"E:\ASP.NET.Core_EasyFilePrint.txt";
            var filebakPath = filePath.Replace(".txt", DateTime.Today.ToString("yyyyMMdd") + ".txt");

            //先將檔案備份
            var f = new FileInfo(filebakPath);
            if (f.Exists)
                f.Delete();
            File.Copy(filePath, filebakPath);

            var lines = new List<string>(File.ReadAllLines(filePath));
            //使用新的變數存要寫入的資料
            var newLine = new List<string>();

            foreach (var line in lines)
            {
                //不加入特定文字的行
                if (!line.Contains("Properties"))
                {
                    newLine.Add(line);
                }
            }

            //將修改後的資料回寫
            File.WriteAllLines(filePath, newLine.ToArray());
        }
    }
}
