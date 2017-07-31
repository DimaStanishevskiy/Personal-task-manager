using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonalTaskManager.Models;
using PersonalTaskManager.Services;
using Newtonsoft.Json;
using System.Web;
using PersonalTaskManager.Repository;
using Newtonsoft.Json.Converters;

namespace PersonalTaskManager.Controllers
{
    [Authorize]
    public class TaskController : ApiController
    {
        TaskServices taskServices = new TaskServices(new MSSQLRepository());

        [HttpPost]
        public string Find(int id)
        {
            return JsonConvert.SerializeObject(taskServices.FindTask(id), new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" });
        }

        [HttpPost]
        public void Create(Task task)
        {
            taskServices.CreateTask(task.Title, task.Content);
        }
        [HttpPost]
        public void Update(Task task)
        {
            taskServices.UpdateTask(task.Id, task.Title, task.Content);
        }
        [HttpPost]
        public void Delete(int Id)
        {
            taskServices.RemoveTask(Id);
        }
        [HttpPost]
        //[Route("api/task/findpage")]
        public string FindPage(int Id)
        {
            List<Task> tasks = taskServices.FindTaskList();
            return JsonConvert.SerializeObject(taskServices.CreatePage(tasks, Id), new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" });

        }
    }
}
