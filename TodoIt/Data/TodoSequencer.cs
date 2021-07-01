namespace TodoIt.Data
{
    public class TodoSequencer
    {
	private static int todoId=0;

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
