using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeCountriesOneCheckpoint.Models;

namespace ThreeCountriesOneCheckpoint.Models
{
    public class Fisherman : Person
    {
        public Fisherman()
        {
            Name = "Карлос";
            Country = "Бразилия";
            HasContraband = true;
            SecretMotivation = "Перевозит кокаин в рыбе";
            PhotoPath = "C:\\Users\\user\\source" +
                "\\repos\\ThreeCountriesOneCheckpoint\\Pictures\\FishermanPNG.png";
        }

        public override string Interact()
        {
            return "";
        }


    }
}
