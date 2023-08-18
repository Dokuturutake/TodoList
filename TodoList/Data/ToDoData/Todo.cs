using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TodoList.Data.PlanData
{
	[Table("todo")]
	public class Todo

	{
		[PrimaryKey, AutoIncrement]
	 	public int Id { get; set; }
		public DateTime Limit {  get; set; }
		public string Title { get; set; }
		public string Detail { get; set; }
	}
}
