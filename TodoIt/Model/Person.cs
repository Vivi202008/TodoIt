using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model

{
    public class Person
    {
	static int idCounter = 0;
	public static int Counter { get { return idCounter; } }

	private readonly int personId;
	public int PersonId { get { return personId; } }

	string firstName;
	string lastName;//default value stats with is null.
	public string FirstName
	{
	    get { return firstName; }
	    set
	    {
		if (string.IsNullOrEmpty(value))
		{
		    throw new ArgumentException("Empty or only whitespace is not allowed.");
		}
		firstName = value;
	    }
	}
	public string LastName
	{
	    get { return lastName; }
	    set
	    {
		if (string.IsNullOrEmpty(value))
		{
		    throw new ArgumentException("Empty or only whitespace is not allowed.");
		}

		lastName = value;
	    }
	}
	public string FullName { get { return $"{firstName} ${lastName}"; } }

	public Person(string firstName, string lastName)
	{
	    personId = ++idCounter;
	    FirstName = firstName;
	    LastName = lastName;
	}

	public string Details()
	{
	    return $"personId: {personId}\nName: {FullName}";
	}
    }
}
