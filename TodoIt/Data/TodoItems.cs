using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;


namespace TodoIt.Data
{
    class TodoItems
    {
        static Todo[] todoAll = new Todo[0];

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] todoDone = new Todo[0];
            int count = 0;
            for (int i = 0; i < todoAll.Length; i++)
            {
                if (todoAll[i].Done == doneStatus)
                {
                    todoDone[count] = todoAll[i];
                    ++count;
                }
            }

            return todoDone;
        }

        public Todo[] FindByAssignee(int personId)
        {
            Todo[] todoDone = new Todo[0];
            int count = 0;
            for (int i = 0; i < todoAll.Length; i++)
            {
                if (todoAll[i].PersonId == personId)
                {
                    todoDone[count] = todoAll[i];
                    ++count;
                }
            }

            return todoDone;
        }

        public Todo[] FindByAssignee(Person assignee)
        {

        }

        public Todo[] FindUnassignedTodoItems()
        {

        }
    }
}
