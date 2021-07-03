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
	    Todo theItem = null;

	    foreach (Todo item in todoAll)
	    {
		if (item.TodoId == todoId) // hittad
		    theItem = item;
	    }

	    return theItem;
	}

	public Todo AddTodo(string description, Person nominatedAssignee)
	{
	    Todo addTodo = new Todo(TodoSequencer.nextTodoId(), description, nominatedAssignee);
	    int sizeofTodoAll = Size(); // Get incrementing size of Array.

	    Array.Resize(ref todoAll, sizeofTodoAll + 1); // Increase the size of Array when add new todo object
	    todoAll[sizeofTodoAll] = addTodo; // Adding todo object to Array.

	    return addTodo;
	}

	// <summary>
	// vilka todo har en viss status dvs ej färdig/klar(inaktuell) ?
	// </summary>
	public Todo[] FindByDoneStatus(bool doneStatus)
	{
	    Todo[] todoDone = new Todo[0];
	    int count = 0;

	    // omskrivning till foreach ?
	    for (int i = 0; i < Size(); i++)
	    {
		if (todoAll[i].Done == doneStatus)
		{
		    Array.Resize(ref todoDone, todoDone.Length + 1); // Increase the size of Array when add new todo object
		    todoDone[count] = todoAll[i];
		    ++count;
		}
	    }

	    return todoDone;
	}

	// <summary>
	// vilka todo har en viss ansvarig ?
	// utgår från personId
	// </summary>
	public Todo[] FindByAssignee(int personId)
	{
	    Todo[] todoPersonId = new Todo[0];
	    int count = 0;

	    for (int i = 0; i < Size(); i++)
	    {
		if (todoAll[i].Assignee.PersonId == personId)
		{
		    Array.Resize(ref todoPersonId, todoPersonId.Length + 1); // Increase the size of Array when add new todo object
		    todoPersonId[count] = todoAll[i];
		    ++count;
		}
	    }

	    return todoPersonId;
	}

	// <summary>
	// vilka todo har en viss ansvarig ?
	// utgår från person-objekt
	// </summary>
	public Todo[] FindByAssignee(Person assignee)
	{
	    Todo[] todoAssignee = new Todo[0];
	    int count = 0;

	    for (int i = 0; i < todoAll.Length; i++)
	    {
		if (todoAll[i].Assignee == assignee)
		{
		    Array.Resize(ref todoAssignee, todoAssignee.Length + 1); // Increase the size of Array when add new todo object
		    todoAssignee[count] = todoAll[i];
		    ++count;
		}
	    }

	    return todoAssignee;
	}

	// <summary>
	// vilka todo har inte fått en ansvarig nominerad ?
	// </summary>
	public Todo[] FindUnassignedTodoItems()
	{
	    Todo[] todoUnAssigned = new Todo[0];
	    int count = 0;

	    for (int i = 0; i < todoAll.Length; i++)
	    {
		if (todoAll[i].Assignee == null)
		{
		    Array.Resize(ref todoUnAssigned, todoUnAssigned.Length + 1); // Increase the size of Array when add new todo object
		    todoUnAssigned[count] = todoAll[i];
		    ++count;
		}
	    }

	    return todoUnAssigned;
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
