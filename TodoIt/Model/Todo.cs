using System;

namespace TodoIt.Model
{
    public class Todo
    {
	static int todoCounter = 0;
	public static int Counter { get { return todoCounter; } }
	private readonly int todoId;
	public int TodoId { get { return todoId; } }

	private string description;
	private bool done;
	private Person assignee;

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
	    todoCounter++;
	    Description = description;
	    Done = false;
	    Assignee = nominatedAssignee;
	}

	public Todo(int id, string description, Person nominatedAssignee):this(description, nominatedAssignee)
	{
	    todoId = id;
	}

	public string Details()
	{
	    return $"todoId: {todoId}\nDescription: {description}\nDone:{done}\nAssignee:{assignee.PersonId + assignee.FullName}";
	}
    }
}
