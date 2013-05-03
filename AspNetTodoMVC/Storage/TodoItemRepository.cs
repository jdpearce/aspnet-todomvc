using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AspNetTodoMVC.Models;

namespace AspNetTodoMVC.Storage
{
    public class TodoItemRepository
    {
        private const string CacheKey = "TodoItemStore";

        public TodoItem[] GetTodoItems()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    ctx.Cache[CacheKey] = new TodoItem[]
                    {
                        new TodoItem
                        {
                            Title = "Write Todo List",
                            Completed = false
                        }
                    };
                }
                return (TodoItem[])ctx.Cache[CacheKey];
            }

            return null;
        }

        public bool SaveTodoItems(TodoItem[] items)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                try
                {
                    ctx.Cache[CacheKey] = items.ToArray();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}