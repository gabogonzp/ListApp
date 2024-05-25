using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ListApp.Datamodels
{
    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Task { get; set; }
        public bool Status { get; set; }

    }
}
