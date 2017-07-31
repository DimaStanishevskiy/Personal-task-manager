using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTaskManager.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreate { get; set; }
    }
}