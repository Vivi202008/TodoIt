using System;

namespace TodoIt.Model
{
    public class Todo
    {
	static int idCount = 0;
	public static int Counter { get { return idCount; } }
	private readonly int todoId;
	public int TodoId { get { return todoId; } }

	private string description;
	private bool done;
	private static Person assignee;

	public Person Assignee
	{
	    get { return assignee; }
	    set
	    {
		assignee = value;
	    }
	}
	public string Description
	{
	    get { return description; }
	    set
	    {
		if (string.IsNullOrEmpty(value))
		{
		    throw new ArgumentException("Empty or only whitespace is not allowed.");
		}
		description = value;
	    }
	}

	public bool Done
	{
	    get { return done; }
	    set
	    {
		done = value;
	    }
	}

	public Todo(string description, Person nominatedAssignee)
	{
	    todoId = ++idCount;
	    Description = description;
	    Done = false;
	    Assignee = nominatedAssignee;
	}

	public Todo(int id, string description)
	{
	    todoId = id;
	    Description = description;
	    Done = false;
	}

	public string Details()
	{
	    return $"todoId: {todoId}\nDescription: {description}\nDone?:{done}\nAssignee:{assignee}";
	}
    }
}
