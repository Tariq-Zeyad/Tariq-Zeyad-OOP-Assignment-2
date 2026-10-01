using System;
using System.Collections.Generic;
using System.Text;

namespace SRP__Patterns.DesignPatterns.src.PatternsLab.SingletonDesign
{

    public class UiService
    {
        public AppConfig Config { get; } = AppConfig.Instance;

        public void Render()
        {
            Console.WriteLine($"UI is using theme: {Config.Theme}");
        }
    }
}
