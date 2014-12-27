using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todoapp;

namespace Todoapp.Classes
{
    public class ToDoDataContext: DataContext
    {
        public const string ConnectionString = @"Data Source = isostore:/ToDo.sdf";

        public ToDoDataContext(string connectionString) : base(connectionString) 
        {
            
        }

        public Table<ToDo> Events;
    }
}
