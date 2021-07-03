using System;
using Xunit;
using TodoIt.Model;
using TodoIt.Data;


namespace TodoIt.Tests
{
    public class TodoIdemTests
    {
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
            int result = Todo.Counter;

            //Assert
            Assert.True(before < result);

        }

        [Fact]
        public void todoIdTest()
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
            Todo todo1 = new Todo(description1, assignee1);
            Todo todo2 = new Todo(description2, assignee2);

            //Assert
            Assert.NotEqual(todo1.TodoId, todo2.TodoId);
        }

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

        [Fact]
        public void AddTodoItems()
        {
            // Arrange
            string expectedFirstName = "Erik";
            string expectedLastName = "Eriksson";
            string eriksTodo = "Växel 1";
            string expectedFirstName1 = "Jonas";
            string expectedLastName1 = "Jonasson";
            string jonasTodo = "Växel 3";

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            Person assignee = new Person(expectedFirstName, expectedLastName);
            Todo actualTodo = actualTodoItems.AddTodo(eriksTodo, assignee);
            Person assignee1 = new Person(expectedFirstName1, expectedLastName1);
            Todo actualTodo1 = actualTodoItems.AddTodo(jonasTodo, assignee1);
            Todo[] testTodoAll = actualTodoItems.FindAll();

            // Assert
            Assert.Equal(expectedFirstName, actualTodo.Assignee.FirstName);
            Assert.Equal(expectedLastName, actualTodo.Assignee.LastName);
            Assert.Equal(expectedFirstName1, actualTodo1.Assignee.FirstName);
            Assert.Equal(expectedLastName1, actualTodo1.Assignee.LastName);
            Assert.Contains(actualTodo, testTodoAll);
            Assert.Contains(actualTodo1, testTodoAll);

            Assert.NotEqual(actualTodo.TodoId, actualTodo1.TodoId);
            Assert.True(actualTodo.TodoId == 1);
            Assert.True(actualTodo1.TodoId == 2);

            Assert.Contains(actualTodoItems.FindById(1).Assignee.FirstName, "Erik");
            Assert.Contains(actualTodoItems.FindById(2).Assignee.FirstName, "Jonas");
        }
        [Fact]
        public void MarkTodoItemAsDone()
        {
            // Arrange
            // Act
            TodoSequencer.reset();
            // Assert
        }

        [Fact]
        public void RemoveTodo()
        {

            // Arrange
            string expectedFirstName = "Erik";
            string expectedLastName = "Eriksson";
            Person assignee = new Person(expectedFirstName, expectedLastName);
            string description = "Job 1";

            string expectedFirstName1 = "Jonas";
            string expectedLastName1 = "Jonasson";
            Person assignee1 = new Person(expectedFirstName1, expectedLastName1);
            string description1 = "Job 2";

            string expectedFirstName2 = "Helen";
            string expectedLastName2 = "Eriksson";
            Person assignee2 = new Person(expectedFirstName2, expectedLastName2);
            string description2 = "Job 3";

            string expectedFirstName3 = "Eva";
            string expectedLastName3 = "Jonasson";
            Person assignee3 = new Person(expectedFirstName3, expectedLastName3);
            string description3 = "Job 4";

            string expectedFirstName4 = "Ulf";
            string expectedLastName4 = "Eriksson";
            Person assignee4 = new Person(expectedFirstName4, expectedLastName4);
            string description4 = "Job 5";

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            Todo actualTodo = actualTodoItems.AddTodo(description, assignee);
            Todo actualTodo1 = actualTodoItems.AddTodo(description1, assignee1);
            Todo actualTodo2 = actualTodoItems.AddTodo(description2, assignee2);
            Todo actualTodo3 = actualTodoItems.AddTodo(description3, assignee3);
            Todo actualTodo4 = actualTodoItems.AddTodo(description4, assignee4);


            actualTodoItems.TodoAfterRemove(2);
            Todo[] testTodoAll = actualTodoItems.FindAll();

            // Assert
            Assert.Contains(actualTodo, testTodoAll);
            Assert.DoesNotContain(actualTodo1, testTodoAll);

            Assert.NotEqual(actualTodo.TodoId, actualTodo1.TodoId);
            Assert.True(actualTodo.TodoId == 1);
            Assert.True(actualTodo2.TodoId == 3);

            Assert.Contains(testTodoAll[0].Description, description);
            Assert.Contains(testTodoAll[1].Description, description2);
            Assert.Contains(testTodoAll[2].Description, description3);
            Assert.Contains(testTodoAll[3].Description, description4);


            //Act
            TodoSequencer.reset();
            actualTodoItems.TodoAfterRemove(4);
            Todo[] testTodoAll1 = actualTodoItems.FindAll();

            //Assert
            Assert.Contains(actualTodo, testTodoAll1);
            Assert.DoesNotContain(actualTodo1, testTodoAll1);
            Assert.Contains(actualTodo2, testTodoAll1);
            Assert.DoesNotContain(actualTodo3, testTodoAll1);
            Assert.Contains(actualTodo4, testTodoAll1);
        }

        [Fact]
        public void operations()
        {
            //Arrange
            string expectedFirstName1 = "Jonas";
            string expectedLastName1 = "Jonasson";
            Person assignee1 = new Person(expectedFirstName1, expectedLastName1);

            string expectedFirstName2 = "Henrik";
            string expectedLastName2 = "Eriksson";
            Person assignee2 = new Person(expectedFirstName2, expectedLastName2);

            //Act
            TodoSequencer.reset();
            PersonSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            Todo actualTodo = actualTodoItems.AddTodo("Work 1", assignee2);
            Todo actualTodo1 = actualTodoItems.AddTodo("Work 2", null);
            Todo actualTodo2 = actualTodoItems.AddTodo("Work 3", assignee1);
            Todo actualTodo3 = actualTodoItems.AddTodo("Work 4", assignee2);
            Todo actualTodo4 = actualTodoItems.AddTodo("Work 5", assignee2);
            actualTodo.Done = true;
            actualTodo1.Done = false;
            actualTodo2.Done = true;
            actualTodo3.Done = false;
            actualTodo4.Done = true;
            Todo[] testTodoAll = actualTodoItems.FindAll();

            //Act            FindByDoneStatus   
            Todo[] testTodoDone = actualTodoItems.FindByDoneStatus(true);
            //Assert
            Assert.Equal(3, testTodoDone.Length);
            Assert.True(testTodoDone[0].Done);
            Assert.True(testTodoDone[1].Done);
            Assert.True(testTodoDone[2].Done);


            //Act       FindByAssignee(personId)
            Todo[] testTodoPersonId = actualTodoItems.FindByAssignee(2);
            //Assert
            Assert.Equal(3, testTodoPersonId.Length);
            Assert.True(testTodoPersonId[0].Assignee.PersonId == 2);
            Assert.True(testTodoPersonId[1].Assignee.PersonId == 2);
            Assert.True(testTodoPersonId[2].Assignee.PersonId == 2);

            //Act       FindByAssignee
            Todo[] testTodoAssignee = actualTodoItems.FindByAssignee(assignee2);
            //Assert
            Assert.Equal(3, testTodoAssignee.Length);
            Assert.True(testTodoPersonId[0].Assignee == assignee2);
            Assert.True(testTodoPersonId[1].Assignee == assignee2);
            Assert.True(testTodoPersonId[2].Assignee == assignee2);

            //Act       FindUnassignedTodoItems
            Todo[] testTodoUnAssignee = actualTodoItems.FindUnassignedTodoItems();
            //Assert
            Assert.True(1 == testTodoUnAssignee.Length);
            Assert.True(testTodoPersonId[0].Assignee == null);



        }
    }
}