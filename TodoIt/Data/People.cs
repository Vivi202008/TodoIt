using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class People
    {
        private static Person[] personArray = new Person[0];

        public int Size()
        {
            return personArray.Length;
        }

        public Person[] FindAll()
        {
            return personArray;
        }

        public Person FindById(int personId)
        {

            bool found = false;
            int i = 0;  // iterering igenom personArray
            while (!found && i < personArray.Length)
            {
                if (personArray[i].PersonId == personId)
                {
                    found = true;
                }
                else
                {
                    i++;
                }
            }
            return personArray[i];

        }
        public Person AddPerson(string firstName, string lastName)
        {
            Person addPerson = new Person(firstName, lastName, PersonSequencer.nextPersonId());
            int sizeofPersonArray = Size(); // Get incrementing size of Array.

            Array.Resize(ref personArray, sizeofPersonArray + 1); // Increase the size of Array when add new person object

            personArray[sizeofPersonArray] = addPerson; // Adding person object to Array.
            return addPerson;
        }

        public Person[] PersonAfterRemove(int personId)
        {
            Person[] personAfterRemove = new Person[0];

            for (int i = 0; i < personArray.Length - 1; i++)
            {
                personAfterRemove[i] = personArray[i];
                if (personArray[i].PersonId == personId)
                {
                    personAfterRemove[i] = personArray[i + 1];
                }
            }
            return personAfterRemove;
        }

        public void Clear()
        {
            Array.Clear(personArray, 0, personArray.Length);
        }

    }
}