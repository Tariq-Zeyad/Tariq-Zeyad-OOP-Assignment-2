using System;
using System.Collections.Generic;
using System.Text;

namespace SRP__Patterns.DesignPatterns.src.PatternsLab.SingletonDesign
{

    public class AppConfig
    {
        private static AppConfig? _instance;

        public static int LoadCount;

        public string DbConnection { get; set; }
        public string Theme { get; set; }

        private AppConfig()
        {
            LoadCount++;

            Console.WriteLine(
                $"[AppConfig] Loading settings from disk... (load #{LoadCount})");

            Thread.Sleep(300);

            DbConnection = "Server=localhost;Db=School";
            Theme = "Light";
        }

        public static AppConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppConfig();
                }

                return _instance;
            }
        }
    }
}
