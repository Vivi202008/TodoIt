﻿using System;
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
            Todo[] todoPersonId = new Todo[0];
            int count = 0;
            for (int i = 0; i < todoAll.Length; i++)
            {
                if (todoAll[i].Assignee.PersonId == personId)
                {
                    todoPersonId[count] = todoAll[i];
                    ++count;
                }
            }

            return todoPersonId;
        }

        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] todoAssignee = new Todo[0];
            int count = 0;
            for (int i = 0; i < todoAll.Length; i++)
            {
                if (todoAll[i].Assignee == assignee)
                {
                    todoAssignee[count] = todoAll[i];
                    ++count;
                }
            }

            return todoAssignee;
        }

        public Todo[] FindUnassignedTodoItems()
        {

            Todo[] todoUnAssignee = new Todo[0];
            int count = 0;
            for (int i = 0; i < todoAll.Length; i++)
            {
                if (todoAll[i].Assignee == null)
                {
                    todoUnAssignee[count] = todoAll[i];
                    ++count;
                }
            }
            return todoUnAssignee;
        }

        public bool TodoAfterRemove(int todoId)
        {
            bool todoToBeRemovedFound = false;
            Todo[] todoAllAfterRemove = new Todo[0];
            int indxTodoAll = 0;
            int indxTodoAllAfterRemove = 0;

            while (indxTodoAll < todoAll.Length)
            {
                if (todoAll[indxTodoAll].TodoId == todoId) // den här Todo ska inte med men mata inte fram indxTodoAllAfterRemove
                {
                    indxTodoAll++;
                    todoToBeRemovedFound = true;
                }
                else
                {
                    Array.Resize(ref todoAllAfterRemove, todoAllAfterRemove.Length + 1);
                    todoAllAfterRemove[indxTodoAllAfterRemove] = todoAll[indxTodoAll];
                    indxTodoAll++;
                    indxTodoAllAfterRemove++;
                }
            }

            todoAll = todoAllAfterRemove;
            return todoToBeRemovedFound;
        }
    }
}
