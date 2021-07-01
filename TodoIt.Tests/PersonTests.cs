using System;
using Xunit;
using TodoIt.Model;

namespace TodoIt.Tests
{
    public class PersonTests
    {
        [Fact]
        public void IdCounterWorks()
        {
            //Arrange
            string firstName = "Kent";
            string lastName = "Svensson";

            //Act
            int before = Person.Counter;
            new Person(firstName, lastName);//create person to make counter count up.
            int result = Person.Counter;

            //Assert
            Assert.True(before < result);
        }

        [Fact]
        public void PersonIdWorks()
        {
            //Arrange
            string firstName = "Kent";
            string lastName = "Svensson";
            string firstName2 = "Test";
            string lastName2 = "Testsson";

            //Act
            Person person1 = new Person(firstName, lastName);
            Person person2 = new Person(firstName2, lastName2);

            //Assert
            Assert.NotEqual(person1.PersonId, person2.PersonId);
        }

        [Fact]
        public void DetailsContainsCorrectInfo()
        {
            //Arrange
            string firstName = "Kent";
            string lastName = "Svensson";

            Person testPerson = new Person(firstName, lastName);

            //Act
            string result = testPerson.Details();

            //Assert
            Assert.Contains(firstName, result);
            Assert.Contains(lastName, result);
        }
    }
}