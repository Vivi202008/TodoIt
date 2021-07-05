using System;
using Xunit;
using TodoIt.Model;

namespace TodoIt.Tests
{
    public class TodoTests
    {
	//
	// kontrollera att efter instantiering av en Todo
	// att den statiska idCounter i klassen är förändrad
	// annars kan man kanske få två instanser av Todo
	// med samma Id
	//
	[Fact]
	public void IdCounterTest()
	{
	    //Arrange
	    string firstName = "Billy";
	    string lastName = "Svensson";
	    string description = "The work is a game---Hangman";
	    Person assignee = new Person(firstName, lastName);

	    //Act
	    int before = Todo.Counter;
	    new Todo(description, assignee);//create person to make counter count up.

	    //Assert
	    Assert.True(before < Todo.Counter);
	}

	//
	// Todo.cs hade ett bugg att alla Todo fick samma assignee
	//   private Person assignee var static-markerad
	//
	[Fact]
	public void TodoAssigneNotStatic1()
	{
	    //Arrange
	    string firstName1 = "Kent";    string lastName1 = "Svensson";
	    string firstName2 = "Billy";   string lastName2 = "Eriksson";
	    Person assignee1 = new Person(firstName1, lastName1);
	    Person assignee2 = new Person(firstName2, lastName2);
	    string description1 = "The work is a calculator";
	    string description2 = "The work a game---Hangman";

	    //Act
	    Todo todo1 = new Todo(description1, assignee1);
	    Todo todo2 = new Todo(description2, assignee2);

	    //Assert
	    Assert.NotEqual(todo1.Assignee, todo2.Assignee);
	}

	//
	// kontrollera att todoId i instanser av Todo är unik
	// dvs att för två instanser av Todo, att de har olika todoId
	// och att todo1 har en lägre id än todo2
	//
	[Fact]
	public void TodoIdWorks()
	{
	    //Arrange
	    string firstName1 = "Kent";
	    string lastName1 = "Svensson";
	    string firstName2 = "Billy";
	    string lastName2 = "Eriksson";
	    Person assignee1 = new Person(firstName1, lastName1);
	    Person assignee2 = new Person(firstName2, lastName2);
	    string description1 = "The work is a calculator";
	    string description2 = "The work a game---Hangman";

	    //Act
	    Todo todo1 = new Todo(3,  description1, assignee1);
	    Todo todo2 = new Todo(10, description2, assignee2);

	    //Assert
	    Assert.NotEqual(todo1.TodoId, todo2.TodoId);
	    Assert.True(todo1.TodoId < todo2.TodoId);
	}

	//
	// garanterar att description innehåller det den ska innehålla
	//
	[Fact]
	public void DetailsContainsCorrectInfo()
	{
	    //Arrange
	    string firstName = "Kent";
	    string lastName = "Svensson";
	    string description = "The work is a game---Hangman";
	    Person assignee = new Person(firstName, lastName);

	    //Act
	    Todo todo1 = new Todo(description, assignee);
	    string result = todo1.Details();

	    //Assert
	    Assert.NotNull(description);
	    Assert.Contains(description, result);
	}
    }
}
