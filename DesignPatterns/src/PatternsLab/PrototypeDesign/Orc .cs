using System;
using System.Collections.Generic;
using System.Text;

namespace SRP__Patterns.DesignPatterns.src.PatternsLab.PrototypeDesign
{
    public class Orc : Enemy
    {
        public Orc()
        {
            Name = "Orc";
            Health = 100;

            Weapon = new Weapon
            {
                Name = "Axe",
                Damage = 25
            };

            Abilities.Add("Rage");
        }

        private Orc(Orc source)
        {
            Name = source.Name;
            Health = source.Health;

            Weapon = new Weapon
            {
                Name = source.Weapon.Name,
                Damage = source.Weapon.Damage
            };

            Abilities = new List<string>(source.Abilities);
        }

        public override Enemy Clone()
        {
            return new Orc(this);
        }
    }
}
