using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalTaskManager.Models;

namespace PersonalTaskManager.Repository
{
    public interface IRepository
    {
        void CreateUser(User user);

        User GetUser(string login);


        void CreateTask(Task task);

        Task GetTask(int Id);

        List<Task> GetTaskList(User user);

        void DeleteTask(Task task);

        void SaveChanges();

    }
}
