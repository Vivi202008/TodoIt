using System;
using Xunit;
using TodoIt.Model;

namespace TodoIt.Tests
{
    public class PersonTests
    {
	//
	// kontrollera att efter instantiering av en Person
	// att personCounter i klassen är förändrad
	//
	[Fact]
	public void IdCounterTest()
	{
	    //Arrange
	    string firstName = "Kent";
	    string lastName = "Svensson";

	    //Act
	    int before = Person.Counter;
	    personen = new Person(firstName, lastName);//create person to make counter count up.

	    //Assert
	    Assert.True(before < Person.Counter);
	}

	//
	// kontrollera att personId i instanser av Person är unik
	// dvs att för två instanser av Person, att verkligen är två olika
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
	    Person person1 = new Person(firstName, lastName, 2);
	    Person person2 = new Person(firstName2, lastName2, 4);

	    //Assert
	    Assert.NotEqual(person1, person2);
	}

	//
	// garanterar att FullName inkluderar för och efternamn
	//
	[Fact]
	public void FullNameContainsCorrectInfo()
	{
	    //Arrange
	    string firstName = "Kent";
	    string lastName = "Svensson";
	    Person testPerson = new Person(firstName, lastName);

	    //Act
	    string result = testPerson.FullName;

	    //Assert
	    // förnamn först !
	    Assert.NotNull( result);
	    Assert.StartsWith(firstName, result);
	    Assert.Contains(lastName, result);
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
	    Assert.NotNull( result);
	    Assert.Contains(firstName, result);
	    Assert.Contains(lastName, result);
	}
    }
}
