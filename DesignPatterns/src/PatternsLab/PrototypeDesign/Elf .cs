using System;
using System.Collections.Generic;
using System.Text;

namespace SRP__Patterns.DesignPatterns.src.PatternsLab.PrototypeDesign
{
    public class Elf : Enemy
    {
        public Elf()
        {
            Name = "Elf";
            Health = 70;

            Weapon = new Weapon
            {
                Name = "Bow",
                Damage = 18
            };

            Abilities.Add("Stealth");
        }

        private Elf(Elf source)
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
            return new Elf(this);
        }
    }
}
