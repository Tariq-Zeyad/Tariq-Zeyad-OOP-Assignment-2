using System;
using System.Collections.Generic;
using System.Text;

namespace SRP__Patterns.DesignPatterns.src.PatternsLab.PrototypeDesign
{
    public abstract class Enemy
    {
        private string _modelData;

        public string Name { get; set; }
        public int Health { get; set; }
        public Weapon Weapon { get; set; }
        public List<string> Abilities { get; set; } = new();
        public string ModelId => _modelData;

        protected Enemy()
        {
            Console.WriteLine("   ...loading 3D model (slow)...");
            Thread.Sleep(500);  

            _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
        }

        public abstract Enemy Clone();
    }
}
