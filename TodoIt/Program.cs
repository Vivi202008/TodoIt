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
            //Arrange
            string expectedFirstName = "Erik";
            string expectedLastName = "Eriksson";
            Person assignee = new Person(expectedFirstName, expectedLastName);

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
            Todo actualTodo1 = actualTodoItems.AddTodo("Work 2", assignee1);
            Todo actualTodo2 = actualTodoItems.AddTodo("Work 3", null);
            Todo actualTodo3 = actualTodoItems.AddTodo("Work 4", assignee2);
            Todo actualTodo4 = actualTodoItems.AddTodo("Work 5", assignee2);
            actualTodo.Done = true;
            actualTodo1.Done = false;
            actualTodo2.Done = true;
            actualTodo3.Done = false;
            actualTodo4.Done = true;
            Todo[] testTodoAll = actualTodoItems.FindAll();
            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine(testTodoAll[i].Details());
            }


            //Act            FindByDoneStatus   
            Todo[] testTodoDone = actualTodoItems.FindByDoneStatus(true);
            //Assert
            Console.WriteLine(3 + "st. " + testTodoDone.Length);
            Console.WriteLine(testTodoDone[0].Done);
            Console.WriteLine(testTodoDone[1].Done);
            Console.WriteLine(testTodoDone[2].Done);


            //Act       
            Todo[] testTodoPersonId = actualTodoItems.FindByAssignee(3);
            //Assert
            Console.WriteLine(3 + "st. " + testTodoPersonId.Length);
            Console.WriteLine(testTodoPersonId[0].Assignee.PersonId + " 3");
            Console.WriteLine(testTodoPersonId[1].Assignee.PersonId + " 3");
            Console.WriteLine(testTodoPersonId[2].Assignee.PersonId + " 3");


        }
    }
}
