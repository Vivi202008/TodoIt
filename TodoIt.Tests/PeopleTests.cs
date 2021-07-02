
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
            Assert.True(actualPerson.PersonId == 1);
            Assert.True(actualPerson1.PersonId == 2);

            Assert.Contains(actualPeople.FindById(1).FirstName, "Erik");
            Assert.Contains(actualPeople.FindById(2).FirstName, "Jonas");

        }

        [Fact]
        public void RemovePersons()
        {

            // Arrange
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

            // Act
            // PersonSequencer.reset();
            People actualPeople = new People();
            Person actualPerson = actualPeople.AddPerson(expectedFirstName, expectedLastName);
            Person actualPerson1 = actualPeople.AddPerson(expectedFirstName1, expectedLastName1);
            Person actualPerson2 = actualPeople.AddPerson(expectedFirstName2, expectedLastName2);
            Person actualPerson3 = actualPeople.AddPerson(expectedFirstName3, expectedLastName3);
            Person actualPerson4 = actualPeople.AddPerson(expectedFirstName4, expectedLastName4);
            Person actualPerson5 = actualPeople.AddPerson(expectedFirstName5, expectedLastName5);

            actualPeople.PersonAfterRemove(2);
            Person[] testPersonArray = actualPeople.FindAll();

            // Assert
            Assert.Contains(actualPerson, testPersonArray);
            Assert.DoesNotContain(actualPerson1, testPersonArray);

            Assert.NotEqual(actualPerson.PersonId, actualPerson1.PersonId);
            Assert.True(actualPerson.PersonId == 1);
            Assert.True(actualPerson2.PersonId == 3);

            Assert.Contains(actualPeople.FindById(1).FirstName, "Erik");
            Assert.Contains(actualPeople.FindById(3).FirstName, "Helen");
            Assert.Contains(actualPeople.FindById(4).FirstName, "Eva");
            Assert.Contains(actualPeople.FindById(5).FirstName, "Ulf");
            Assert.Contains(actualPeople.FindById(6).FirstName, "Johan");

            //Act
            //PersonSequencer.reset();
            actualPeople.PersonAfterRemove(4);
            Person[] testPersonArray1 = actualPeople.FindAll();

            //Assert
            Assert.Contains(actualPerson, testPersonArray1);
            Assert.DoesNotContain(actualPerson1, testPersonArray1);
            Assert.Contains(actualPerson2, testPersonArray1);
            Assert.DoesNotContain(actualPerson3, testPersonArray1);
            Assert.Contains(actualPerson4, testPersonArray1);
            Assert.Contains(actualPerson5, testPersonArray1);
        }
    }
}
