using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class People
    {
        private static Person[] personArray = new Person[0];
        int personId = PersonSequencer.nextPersonId(); // Assign uniq Id to person.
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
            return personArray[personId];
        }
        public Person AddPerson(string firstName, string lastName)
        {
            Person addPerson = new Person(firstName, lastName);
            int sizeofPersonArray = Size(); // Get incrementing size of Array.

            Array.Resize(ref personArray, sizeofPersonArray + 1); // Increase the size of Array when add new person object

            personArray[sizeofPersonArray] = addPerson; // Adding person object to Array.
            return addPerson;
        }

        public void Clear()
        {
            Array.Clear(personArray, 0, personArray.Length);
        }

    }
}