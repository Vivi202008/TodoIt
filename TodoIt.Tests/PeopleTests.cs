
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoIt.Data;
using TodoIt.Model;
using System.Linq;


namespace TodoIt.Tests
{

    public class PeopleTests
    {

        [Fact]
        public void AddPersons()
        {

            // Arrange
            string expectedFirstName = "Erik";
            string expectedLastName = "Eriksson";

            string expectedFirstName1 = "Jonas";
            string expectedLastName1 = "Jonasson";

            // Act
            People actualPeople = new People();
            Person actualPerson = actualPeople.AddPerson(expectedFirstName, expectedLastName);
            Person actualPerson1 = actualPeople.AddPerson(expectedFirstName1, expectedLastName1);
            Person[] testPersonArray = actualPeople.FindAll();

            // Assert
            Assert.Equal(expectedFirstName, actualPerson.FirstName);
            Assert.Equal(expectedLastName, actualPerson.LastName);
            Assert.Equal(expectedFirstName1, actualPerson1.FirstName);
            Assert.Equal(expectedLastName1, actualPerson1.LastName);
            Assert.Contains(actualPerson, testPersonArray);
            Assert.Contains(actualPerson1, testPersonArray);

            Assert.NotEqual(actualPerson.PersonId, actualPerson1.PersonId);
            Assert.True(actualPerson.PersonId == 2);
            Assert.True(actualPerson1.PersonId == 3);

            Assert.Contains(actualPeople.FindById(0).FirstName, "Erik");
            Assert.Contains(actualPeople.FindById(1).FirstName, "Jonas");

        }


    }
}
