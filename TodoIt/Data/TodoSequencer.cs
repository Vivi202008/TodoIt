namespace TodoIt.Data
{
    public class TodoSequencer
    {
	private static int todoId;

	public static int nextTodoID()
	{
	    return ++todoId;
	}

	public static void reset()
	{
	    todoId=0;
	}
    }
}
