using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoIt.Data;
using TodoIt.Model;
using System.Linq;


namespace TodoIt.Tests
{
    //
    // med den här märkningen hindras det här testet från att köras samtidigt
    // med exv de i PersonSequencerTests-klassen
    //
    // xUnit parallelliserar normalt sett körningen av test som är i placerade i olika klasser
    // så exv TodoSequencer kan köras parallellt med denna men även PeopleTests
    //
    // PeopleTests är beroende av att PersonSequencer.nextPersonId
    // alltid ger samma talföljd varje exekvering men om denna körs sam
    //
    // https://xunit.net/docs/running-tests-in-parallel
    //
    [Collection("our_test_runners")]
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

	    // nolla PersonSequencer för att få förutsägelsebara personId
	    PersonSequencer.reset();

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

	    Assert.Equal("Erik",  actualPeople.FindById(1).FirstName);
	    Assert.Equal("Jonas", actualPeople.FindById(2).FirstName);
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

	    // nolla PersonSequencer för att få förutsägelsebara personId
	    PersonSequencer.reset();

	    // Act
	    People actualPeople = new People();
	    Person actualPerson = actualPeople.AddPerson(expectedFirstName, expectedLastName);
	    Person actualPerson1 = actualPeople.AddPerson(expectedFirstName1, expectedLastName1);
	    Person actualPerson2 = actualPeople.AddPerson(expectedFirstName2, expectedLastName2);
	    Person actualPerson3 = actualPeople.AddPerson(expectedFirstName3, expectedLastName3);
	    Person actualPerson4 = actualPeople.AddPerson(expectedFirstName4, expectedLastName4);
	    Person actualPerson5 = actualPeople.AddPerson(expectedFirstName5, expectedLastName5);

	    //Act tag bort Jonas (2) ur listan
	    actualPeople.PersonAfterRemove(2);
	    Person[] testPersonArray = actualPeople.FindAll();

	    // Assert
	    Assert.Contains(actualPerson, testPersonArray);
	    Assert.DoesNotContain(actualPerson1, testPersonArray);
	    Assert.Contains(actualPerson2, testPersonArray);
	    Assert.Contains(actualPerson3, testPersonArray);
	    Assert.Contains(actualPerson4, testPersonArray);
	    Assert.Contains(actualPerson5, testPersonArray);

	    Assert.Contains("Erik", actualPeople.FindById(1).FirstName);
	    Assert.Contains("Helen", actualPeople.FindById(3).FirstName);
	    Assert.Contains("Eva", actualPeople.FindById(4).FirstName);
	    Assert.Contains("Ulf", actualPeople.FindById(5).FirstName);
	    Assert.Contains("Johan", actualPeople.FindById(6).FirstName);

	    //Act tag bort Eva (4) ur listan
	    actualPeople.PersonAfterRemove(4);
	    Person[] testPersonArray1 = actualPeople.FindAll();

	    //Assert
	    Assert.Contains(actualPerson, testPersonArray1);
	    Assert.DoesNotContain(actualPerson1, testPersonArray1);
	    Assert.Contains(actualPerson2, testPersonArray1);
	    Assert.DoesNotContain(actualPerson3, testPersonArray1);
	    Assert.Contains(actualPerson4, testPersonArray1);
	    Assert.Contains(actualPerson5, testPersonArray1);

	    Assert.Contains("Erik", actualPeople.FindById(1).FirstName);
	    Assert.Contains("Helen", actualPeople.FindById(3).FirstName);
	    Assert.Contains("Ulf", actualPeople.FindById(5).FirstName);
	    Assert.Contains("Johan", actualPeople.FindById(6).FirstName);
	}
    }
}
