using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCountriesOneCheckpoint.Models
{
    public class PoorWoman : Person
    {
        public PoorWoman()
        {
            Name = "Мария";
            Country = "Аргентина";
            HasContraband = false;
            SecretMotivation = "Везит украденные деньги под одеждой";
        }

        public override string Interact()
        {
            return "";
        }
    }
}
