using System;
using TodoIt.Model;
using TodoIt.Data;

namespace TodoIt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string expectedFirstName = "Erik";
            string expectedLastName = "Eriksson";

            string expectedFirstName1 = "Jonas";
            string expectedLastName1 = "Jonasson";

            string expectedFirstName2 = "Helen";
            string expectedLastName2 = "Eriksson";

            string expectedFirstName3 = "Eva";
            string expectedLastName3 = "Jonasson";

            string expectedFirstName4 = "Ulf";
            string expectedLastName4 = "Eriksson";

            string expectedFirstName5 = "Johan";
            string expectedLastName5 = "Jonasson";

            People actualPeople = new People();
            Person actualPerson = actualPeople.AddPerson(expectedFirstName, expectedLastName);
            Person actualPerson1 = actualPeople.AddPerson(expectedFirstName1, expectedLastName1);
            Person actualPerson2 = actualPeople.AddPerson(expectedFirstName2, expectedLastName2);
            Person actualPerson3 = actualPeople.AddPerson(expectedFirstName3, expectedLastName3);
            Person actualPerson4 = actualPeople.AddPerson(expectedFirstName4, expectedLastName4);
            Person actualPerson5 = actualPeople.AddPerson(expectedFirstName5, expectedLastName5);

            Console.WriteLine(actualPerson.PersonId + actualPerson.FullName);
            Console.WriteLine(actualPerson1.PersonId + actualPerson1.FullName);
            Console.WriteLine(actualPerson2.PersonId + actualPerson2.FullName);
            Console.WriteLine(actualPerson3.PersonId + actualPerson3.FullName);
            Console.WriteLine(actualPerson4.PersonId + actualPerson4.FullName);
            Console.WriteLine(actualPerson5.PersonId + actualPerson5.FullName);

            actualPeople.PersonAfterRemove(3);



        }
    }
}
