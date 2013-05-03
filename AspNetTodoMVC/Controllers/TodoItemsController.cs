using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AspNetTodoMVC.Storage;
using AspNetTodoMVC.Models;

namespace AspNetTodoMVC.Controllers
{
    public class TodoItemsController : ApiController
    {
        private TodoItemRepository todoItemRepository;


        public TodoItemsController()
        {
            todoItemRepository = new TodoItemRepository();
        }

        public HttpResponseMessage Post(TodoItem[] items)
        {
            todoItemRepository.SaveTodoItems(items);
            var response = Request.CreateResponse<TodoItem[]>(System.Net.HttpStatusCode.Created, items);
            return response;
        }

        public TodoItem[] Get()
        {
            return todoItemRepository.GetTodoItems();
        }
    }
}
