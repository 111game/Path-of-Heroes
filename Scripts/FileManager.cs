using Godot;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace MySpace
{
    public partial class FileManager 
    {
        private FileManager()
        {
            //初始化
            //UserPath=;//
            string projectRoot = ProjectSettings.GlobalizePath("res://");
            GD.Print("projectRoot " + projectRoot);
            // 组合成目标文件路径
            UserPath = Path.Combine(path1: projectRoot,"User/");

            GD.Print("User Path: " + UserPath);

            loadFile();
        }
        static FileManager instance = null;
        public static FileManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance=new FileManager();
                }
                return instance;
            }
        }
        void loadFile()
        {
            string filePath=Path.Combine(path1: UserPath,"111.txt");
            if (File.Exists(filePath))
            {
                using (StreamWriter t_StreamReader = new StreamWriter(UserPath+ "111exist.txt"))
                {

                }
            }
            else
            {
                using (StreamWriter t_StreamReader = new StreamWriter(UserPath+ "111noexist.txt"))
                {

                }
            }
        }
        [Export]
        public string UserPath="";




        private void ReadValidLine(StreamReader x_StreamReader,ref string x_Str)
        {
            while ((x_Str = x_StreamReader.ReadLine()) != null)
            {
                if (x_Str.Length != 0)
                {
                    break;
                }
            }
        }
        private string[] ReadOneLineNum(StreamReader x_StreamReader ,int x_Num)
        {
            if(x_Num==0)
                return null;
            string t_StrLine = null;
            ReadValidLine(x_StreamReader,ref t_StrLine);
            string[]t_Str= Regex.Split(t_StrLine, "\\s+", RegexOptions.IgnoreCase);
            //根据Num裁剪掉多余的数据 （注释）
            Array.Resize(ref t_Str, x_Num);
            return t_Str;
        }

        private string[] ReadMoreLineNum(StreamReader x_StreamReader,int t_NumPerLine,int t_AllNum)
        {
            int t_OrderLine = t_AllNum / t_NumPerLine;
            int t_LeftNum = t_AllNum % t_NumPerLine;
            List<string> t_AllStr = new List<string>();
            //List<string> t_Str = new List<string>();
            //string[] t_AllStr = { };
            //string[] t_Str = { };//= Regex.Split(t_StrLine, "\\s+", RegexOptions.IgnoreCase);
            string[] t_Str = null;
            for (int i=0;i<t_OrderLine;i++)
            {
                t_Str = ReadOneLineNum(x_StreamReader, t_NumPerLine);
                t_AllStr.AddRange(t_Str);

            }
            if(t_LeftNum!=0)
            {
                t_Str = ReadOneLineNum(x_StreamReader, t_LeftNum);
                t_AllStr.AddRange(t_Str);
            }


            return t_AllStr.ToArray();

        }

        //读取数据的规范函数 x_Length获取一行的个数
        private void ReadData(StreamReader x_StreamReader,ref int[,] x_Data)
        {
            string t_StrLine =null;
            ReadValidLine(x_StreamReader,ref t_StrLine);
            string[] t_Str = Regex.Split(t_StrLine, "\\s+", RegexOptions.IgnoreCase);
            int t_Width = int.Parse(t_Str[1]);
            //循环次数
            int t_Height= int.Parse(t_Str[0]);
            x_Data = new int[t_Height, t_Width];
            for (int i = 0; i < t_Height; i++)
            {
                ReadValidLine(x_StreamReader, ref t_StrLine);
                t_Str = Regex.Split(t_StrLine, "\\s+", RegexOptions.IgnoreCase);
                for(int j=0;j < t_Width;j++) 
                { 
                    x_Data[i,j] = int.Parse(t_Str[j]);
                }

            }
        }
        //读取数据的规范函数 x_Length获取一行的个数
        private void ReadData(StreamReader x_StreamReader,ref int[] x_Data)
        {
            string t_StrLine=null;
            ReadValidLine(x_StreamReader, ref t_StrLine);
            string[] t_Str = Regex.Split(t_StrLine, "\\s+", RegexOptions.IgnoreCase);
            int t_Length = int.Parse(t_Str[1]);
            //循环次数 应为1
            //int t_Height = int.Parse(t_Str[0]);
            x_Data=new int[t_Length];
            ReadValidLine(x_StreamReader, ref t_StrLine);
            t_Str = Regex.Split(t_StrLine, "\\s+", RegexOptions.IgnoreCase);
            for (int j = 0; j < t_Length; j++)
            {
                x_Data[j] = int.Parse(t_Str[j]);
            }

        }
        //INfo为注释
        private void WriteDataWithInfo(StreamWriter x_StreamReader, in int[] x_Data,string x_Info)
        {
            string t_StrLine = null;
            int t_Length = x_Data.GetLength(0);

            for (int i = 0; i < t_Length; i++)
            {
                t_StrLine += x_Data[i];
                if (x_Data[i] / 10 <= 0)
                    t_StrLine += "    ";
                else if (x_Data[i] / 100 <= 0)
                    t_StrLine += "   ";
                else if (x_Data[i] / 1000 <= 0)
                    t_StrLine += "  ";
                else
                    t_StrLine += " ";
            }
            t_StrLine += x_Info;
            x_StreamReader.WriteLine(t_StrLine);
            //t_StrLine = "";
            //x_StreamReader.WriteLine(t_StrLine);
        }
        private void WriteDataWithInfo(StreamWriter x_StreamReader,List<int>x_Data,string x_Info)
        {
            string t_StrLine = null;

            for (int i = 0; i < x_Data.Count; i++)
            {
                t_StrLine += x_Data[i];
                if (x_Data[i] / 10 <= 0)
                    t_StrLine += "    ";
                else if (x_Data[i] / 100 <= 0)
                    t_StrLine += "   ";
                else if (x_Data[i] / 1000 <= 0)
                    t_StrLine += "  ";
                else
                    t_StrLine += " ";
            }
            t_StrLine += x_Info;
            x_StreamReader.WriteLine(t_StrLine);
            //t_StrLine = "";
            //x_StreamReader.WriteLine(t_StrLine);
        }
        private void WriteData(StreamWriter x_StreamReader, in int[] x_Data)
        {
            string t_StrLine = null;
            int t_Length = x_Data.GetLength(0);
            t_StrLine += "1   " + t_Length;
            x_StreamReader.WriteLine(t_StrLine);
            t_StrLine = null;
            for (int i = 0; i < t_Length; i++)
            {
                t_StrLine += x_Data[i];
                if (x_Data[i] / 10 <= 0)
                    t_StrLine += "    ";
                else if (x_Data[i] / 100 <= 0)
                    t_StrLine += "   ";
                else if (x_Data[i] / 1000 <= 0)
                    t_StrLine += "  ";
                else
                    t_StrLine += " ";
            }
            x_StreamReader.WriteLine(t_StrLine);
            t_StrLine = "";
            x_StreamReader.WriteLine(t_StrLine);
        }
        private void WriteData(StreamWriter x_StreamReader, in int[,] x_Data)
        {//rank
            string t_StrLine = null;
            int t_Width = x_Data.GetLength(1);
            int t_Height = x_Data.GetLength(0);
            t_StrLine += t_Height +"   "+ t_Width;
            x_StreamReader.WriteLine(t_StrLine);
            t_StrLine = null;
            for (int i=0;i< t_Height;i++)
            {
                for (int j = 0; j < t_Width; j++)
                {
                    t_StrLine += x_Data[i,j];
                    if (x_Data[i,j] / 10 <= 0)
                        t_StrLine += "   ";
                    else if (x_Data[i,j] / 100 <= 0)
                        t_StrLine += "  ";
                    else
                        t_StrLine += " ";
                }
                x_StreamReader.WriteLine(t_StrLine);
                t_StrLine = null;
            }
            t_StrLine = "";
            x_StreamReader.WriteLine(t_StrLine);
        }
  
    }
    
}

