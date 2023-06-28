using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Data.Interface;
using TodoList.Data.PlanData;

namespace TodoList.Data.SQLite
{
	public class SQLite_TodoIO : ITodoIO
	{

		private readonly string _dbPath = "Todo.db3";
		private SQLiteConnection connection;
		private void Init()
		{
			if (null != connection)
				return;
			var fullPath = GetFileFullPath();
			connection = new SQLiteConnection(fullPath);
			connection.CreateTable<Todo>();
		}

		private string GetFileFullPath()
		{
			Init();
			string AbsolutePath = FileSystem.AppDataDirectory;
			return Path.Combine(AbsolutePath, _dbPath);
		}

		public bool Insert(Todo todo)
		{
			Init();
		   connection.Insert(todo);
			return true;
		}

		public bool Delete(Todo todo)
		{
			Init();
			connection.Delete(todo);
			return true;
		}

		public bool UpDate(Todo todo)
		{
			Init();
			connection.Update(todo);
			return true;
		}

		public IEnumerable<Todo> GetData(string path, Func<Todo, bool> predicate = null)
		{
			Init();
			if (predicate == null) 
				return connection.Table<Todo>().ToList();
			else
				return connection.Table<Todo>().Where(predicate).ToList();
		}
	}
}
