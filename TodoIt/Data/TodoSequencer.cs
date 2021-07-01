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
            return ++todoId;
        }

        public static void Reset()
        {
            todoId = 0;
        }

    }
}

