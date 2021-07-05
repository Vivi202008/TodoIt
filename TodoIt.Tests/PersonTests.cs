using System;
using Xunit;
using TodoIt.Model;

namespace TodoIt.Tests
{
    public class PersonTests
    {
	//
	// kontrollera att efter instantiering av en Person
	// att den statiska idCounter i klassen är förändrad
	// annars kan man kanske få två instanser av Person
	// med samma Id
	//
	[Fact]
	public void IdCounterTest()
	{
	    //Arrange
	    string firstName = "Kent";
	    string lastName = "Svensson";

	    //Act
	    int before = Person.Counter;
	    new Person(firstName, lastName);//create person to make counter count up.

	    //Assert
	    Assert.True(before < Person.Counter);
	}

	//
	// kontrollera att personId i instanser av Person är unik
	// dvs att ingen annan instans av Person har samma personId
	//
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
	    Assert.True(person1.PersonId < person2.PersonId);
	}

	//
	// garanterar att Details inkluderar FullName dvs förnamn efternamn
	//
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
