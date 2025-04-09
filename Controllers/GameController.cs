using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeCountriesOneCheckpoint.Models;


namespace ThreeCountriesOneCheckpoint.Controler
{
    public class GameController
    {
        private List<Person> peopleQueue = new List<Person>();
        private int currentPersonIndex = 0;

        public GameController()
        {
            peopleQueue.Add(new Fisherman());
            peopleQueue.Add(new Pirate());
        }

        public Person GetCurrentPerson()
        {
            return peopleQueue[currentPersonIndex];
        }

        public void IteratePerson()
        {
            currentPersonIndex = (currentPersonIndex + 1) % peopleQueue.Count;
        }

        public bool CheckContraband(Person person)
        {
            return person.HasContraband;
        }
    }
}
