using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    class Todo
    {
	private static idCount = 0;
	public static int Counter{ get { return idCound; }}

	private readonly int todoId;
	string               description;
	int                 assignee;
	bool    done;

	public Todo( int id, string description)
	{
	    if (string.IsNullOrEmpty(description))
	    {
		throw new ArgumentException("Empty or only whitespace is not allowed.");
	    }
	    todoId = id;
	    this.description = description;
	}

	public string Description {
	    get { return description; }
	    set
	    {
		if (string.IsNullOrEmpty(value))
		{
		    throw new ArgumentException("Empty or only whitespace is not allowed.");
		}
		this.description = value;
	    }
	}

	public int Assignee {
	    get { return assignee; }
	    set
	    {
		this.assignee = value;
	    }
	}
    }
}
