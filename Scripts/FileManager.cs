using Godot;
using System;
using System.IO;
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
            UserPath = Path.Combine(path1: projectRoot,"User");

            GD.Print("User Path: " + UserPath);
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
        [Export]
        public string UserPath="";


    }
    
}

