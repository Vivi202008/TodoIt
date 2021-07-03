using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;


namespace TodoIt.Data
{
    public class TodoItems
    {
        private static Todo[] todoAll = new Todo[0];

        public int Size()
        {
            return todoAll.Length;
        }

        public Todo[] FindAll()
        {
            return todoAll;
        }

        public Todo FindById(int todoId)
        {

            bool found = false;
            int i = 0;  // iterering igenom todoAll
            while (!found && i < todoAll.Length)
            {
                if (todoAll[i].TodoId == todoId)
                {
                    found = true;
                }
                else
                {
                    i++;
                }
            }
            return todoAll[i];

        }

        public Todo AddTodo(string description, Person nominatedAssignee)
        {
            Todo addTodo = new Todo(TodoSequencer.nextTodoId(), description, nominatedAssignee);
            int sizeofTodoAll = Size(); // Get incrementing size of Array.

            Array.Resize(ref todoAll, sizeofTodoAll + 1); // Increase the size of Array when add new todo object

            todoAll[sizeofTodoAll] = addTodo; // Adding todo object to Array.
            return addTodo;
        }

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] todoDone = new Todo[0];
            for (int i = 0; i < todoAll.Length; i++)
            {
                if (todoAll[i].Done == doneStatus)
                {
                    int sizeofTodoDone = todoDone.Length; // Get incrementing size of Array.
                    Array.Resize(ref todoDone, sizeofTodoDone + 1); // Increase the size of Array when add new todo object

                    todoDone[sizeofTodoDone] = todoAll[i];
                }
            }
            return todoDone;
        }

        public Todo[] FindByAssignee(int personId)
        {
            Todo[] todoPersonId = new Todo[0];
            for (int i = 0; i < todoAll.Length; i++)
            {
                if (todoAll[i].Assignee.PersonId == personId)
                {
                    int sizeofTodoPersonId = todoPersonId.Length; // Get incrementing size of Array.
                    Array.Resize(ref todoPersonId, sizeofTodoPersonId + 1); // Increase the size of Array when add new todo object

                    todoPersonId[sizeofTodoPersonId] = todoAll[i];
                }
            }

            return todoPersonId;
        }

        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] todoAssignee = new Todo[0];

            for (int i = 0; i < todoAll.Length; i++)
            {
                if (todoAll[i].Assignee == assignee)
                {
                    int sizeoftodoAssignee = todoAssignee.Length; // Get incrementing size of Array
                    Array.Resize(ref todoAssignee, sizeoftodoAssignee + 1); // Increase the size of Array when add new todo object

                    todoAssignee[sizeoftodoAssignee] = todoAll[i];

                }
            }

            return todoAssignee;
        }

        public Todo[] FindUnassignedTodoItems()
        {

            Todo[] todoUnAssignee = new Todo[0];

            for (int i = 0; i < todoAll.Length; i++)
            {
                if (todoAll[i].Assignee == null)
                {
                    int sizeofTodoUnAssignee = Size(); // Get incrementing size of Array.
                    Array.Resize(ref todoAll, sizeofTodoUnAssignee + 1); // Increase the size of Array when add new todo object

                    todoUnAssignee[sizeofTodoUnAssignee] = todoAll[i];

                }
            }
            return todoUnAssignee;
        }

        public bool TodoAfterRemove(int todoId)
        {
            bool todoToBeRemovedFound = false;
            Todo[] todoAllAfterRemove = new Todo[0];
            int indxTodoAll = 0;
            int indxTodoAllAfterRemove = 0;

            while (indxTodoAll < todoAll.Length)
            {
                if (todoAll[indxTodoAll].TodoId == todoId) // den här Todo ska inte med men mata inte fram indxTodoAllAfterRemove
                {
                    indxTodoAll++;
                    todoToBeRemovedFound = true;
                }
                else
                {
                    Array.Resize(ref todoAllAfterRemove, todoAllAfterRemove.Length + 1);
                    todoAllAfterRemove[indxTodoAllAfterRemove] = todoAll[indxTodoAll];
                    indxTodoAll++;
                    indxTodoAllAfterRemove++;
                }
            }

            todoAll = todoAllAfterRemove;
            return todoToBeRemovedFound;
        }
    }
}
