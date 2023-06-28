using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Data.Interface
{
	public interface IOptionIO
	{
		public Dictionary<string, string> GetData(string path);
		public bool SetData(Dictionary<string, string> data, string path);
	}
}
