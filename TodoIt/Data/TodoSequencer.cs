using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{
    class TodoSequencer
    {

        private static int todoId;

        public static int NextTodoId()
        {
            int nextTodoId;
            nextTodoId = +todoId;
            return nextTodoId;
        }

        public static int Reset()
        {
            todoId = 0;
            return todoId;
        }

    }
}

