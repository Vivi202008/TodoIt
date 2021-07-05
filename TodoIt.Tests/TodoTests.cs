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
	// kontrollera att todoId i instanser av Todo är unik
	// dvs att för två instanser av Todo, att de har olika personId
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

            var result = todo1.Details();

            //Assert
            Assert.Contains(description, result);
            Assert.NotNull(description);
        }


    }
}