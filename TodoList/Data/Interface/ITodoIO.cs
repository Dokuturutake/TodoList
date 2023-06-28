using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Data.PlanData;

namespace TodoList.Data.Interface
{
 	interface ITodoIO
	{
		bool Insert(Todo todo);
		bool Delete(Todo todo);
		bool UpDate(Todo todo);
		IEnumerable<Todo> GetData(string path, Func<Todo,bool> predicate = null);
	}
}
