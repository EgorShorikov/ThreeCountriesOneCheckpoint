using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCountriesOneCheckpoint.Models
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string[] Documents { get; set; } // Документы (паспорт, разрешение)
        public bool HasContraband { get; set; } // Есть ли контрабанда
        public string SecretMotivation { get; set; } // Скрытый мотив (для сюжета)

        public string PhotoPath { get; set; }

        public abstract string Interact(); // Метод для взаимодействия
    }
}
