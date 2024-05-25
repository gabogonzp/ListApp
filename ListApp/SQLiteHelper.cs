using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ListApp.Datamodels;

namespace ListApp
{
    public class SQLiteHelper
    {

        public readonly SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<ToDoItem>();
        }

        public Task<int> CreateTask(ToDoItem Task)
        {
            return db.InsertAsync(Task);
        }

        public Task<List<ToDoItem>> ReadTask()
        {
            return db.Table<ToDoItem>().ToListAsync();
        }

         public Task<int> UpdateTask(ToDoItem Task)
        {
            return db.UpdateAsync(Task);
        }

         public Task<int> DeleteTask(ToDoItem Task)
        {
            return db.DeleteAsync(Task);
        }
    }
}
