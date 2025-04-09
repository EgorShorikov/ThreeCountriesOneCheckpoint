using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCountriesOneCheckpoint.Models
{
    public class Pirate : Person
    {
        public Pirate()
        {
            Name = "Эль Капитан";
            Country = "Парагвай";
            HasContraband = true;
            SecretMotivation = "Проносит оружие для банды";
            PhotoPath = "C:\\Users\\user\\source\\repos" +
                "\\ThreeCountriesOneCheckpoint\\Pictures\\PiratePNG.png";
        }

        public override string Interact()
        {
            return "";
        }
    }
}
