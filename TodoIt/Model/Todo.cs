using System;


namespace TodoIt.Model
{
    class Todo
    {

        static int idCount = 0;
        public static int Counter { get { return idCount; } }
        private readonly int todoId;

        private string description;
        private bool done;
        private static string firstName;
        private static string lastName;
        private static Person assignee = new Person(firstName, lastName);

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

        public Todo(string description, bool done, Person assignee)
        {
            todoId = ++idCount;
            Description = description;
            Done = done;
            Assignee = assignee;
        }

        public string Details()
        {
            return $"todoId: {todoId}\nDescription: {description}\nDone?:{done}\nAssignee:{assignee}";
        }
    }
}
