using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{
    public class TodoSequencer
    {
        private static int todoId = 0;

        public static int nextTodoId()
        {
            return ++todoId;
        }

        public static void reset()
        {
            todoId = 0;
        }
    }
}
