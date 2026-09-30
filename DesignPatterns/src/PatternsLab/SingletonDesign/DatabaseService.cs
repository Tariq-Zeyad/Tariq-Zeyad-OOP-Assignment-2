using System;
using System.Collections.Generic;
using System.Text;

namespace SRP__Patterns.DesignPatterns.src.PatternsLab.SingletonDesign
{

    public class DatabaseService
    {
        public AppConfig Config { get; } = AppConfig.Instance;

        public void Connect()
        {
            Console.WriteLine($"Connecting to {Config.DbConnection}");
        }
    }
}
