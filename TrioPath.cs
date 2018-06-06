using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TrioMobil
{
    public class TrioPath
    {
        public String directory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TrioMobil\\";
        public String project_directory;
        public String config_file_name = "Config.conf";
        public String project_name;
        public Dictionary<String, String> Config;

        public  TrioPath(String project)
        {
            Config = new Dictionary<String, String>();
            project_name = project;
            project_directory = directory + "\\" + project+"\\";
            if (!File.Exists(project_directory))
                Directory.CreateDirectory(project_directory);
        }

        public String config_read(String key)
        {
            config_file_init();
            if (Config.ContainsKey(key))
                return Config[key];
            else
                return "";
        }

        public void config_write(String key,String value)
        {
            config_file_init();
            if (Config.ContainsKey(key))
                Config[key] = value;
            else
                Config.Add(key,value);

            config_file_save();
        }
     
        public void config_file_init()
        {
            Config.Clear();
                String file = project_directory + config_file_name;
                if (File.Exists(file))
                {

                    StreamReader f = File.OpenText(file);
                      while (!f.EndOfStream)
                      {
                           String d = f.ReadLine();
                           Config.Add(d.Split('|')[0], d.Split('|')[1]);
                      }
                     f.Close();
                }
            
        }

        public void config_file_save()
        {
            String file = project_directory + config_file_name;
            StreamWriter f = File.CreateText(file);
            foreach (KeyValuePair<String, String> pair in Config)
                     f.WriteLine(pair.Key + "|" + pair.Value);
            f.Close();

        }

    }
}
