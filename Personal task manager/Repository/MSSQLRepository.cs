using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalTaskManager.Models;
using System.Data.Entity;

namespace PersonalTaskManager.Repository
{
    public class MSSQLRepository : IRepository
    {
        private Context context = new Context();
        public void CreateTask(Task task)
        {
            context.Tasks.Add(task);
            SaveChanges();
        }

        public void CreateUser(User user)
        {
            context.Users.Add(user);
            SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            context.Tasks.Remove(task);
            SaveChanges();
        } 

        public Task GetTask(int Id)
        {
            return context.Tasks.FirstOrDefault(t => t.Id == Id);
        }

        public List<Task> GetTaskList(User user)
        {
            return context.Tasks.Where(t => t.User.Login == user.Login).ToList();
        }

        public User GetUser(string login)
        {
            return context.Users.FirstOrDefault(u => u.Login == login);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }

    class Context : DbContext
    {
        public Context() : base("DBConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}