using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalTaskManager.Models;
using PersonalTaskManager.Repository;


namespace PersonalTaskManager.Services
{
    public class TaskServices
    {
        private UserServices userServices;
        private IRepository repository;

        public TaskServices(IRepository Repository)
        {
            this.repository = Repository;
            userServices = new UserServices(Repository);
        }

        public Task FindTask(int Id)
        {
            return repository.GetTask(Id);
        }

        public void CreateTask(string Title, string Content)
        {
            Task task = new Task()
            {
                Title = Title,
                Content = Content,
                User = userServices.CurrentUser,
                DateCreate = DateTime.Now
            };

            repository.CreateTask(task);
        }

        public void RemoveTask(int Id)
        {
            Task task = repository.GetTask(Id);
            if (task != null)
                repository.DeleteTask(task);
        }
        public bool UpdateTask(int Id, string Title = null, string Content = null)
        {
            Task task = repository.GetTask(Id);
            if (task != null)
            {
                if (Title != null)
                    task.Title = Title;
                if (Content != null)
                    task.Content = Content;
                repository.SaveChanges();
                return true;
            }
            else return false;

        }

        public List<Task> FindTaskList()
        {
            return repository.GetTaskList(userServices.CurrentUser);
        }
        public Page<Task> CreatePage(List<Task> Tasks, int PageNumber)
        {
            return new Page<Task>(Tasks, PageNumber);
        }
    }
}