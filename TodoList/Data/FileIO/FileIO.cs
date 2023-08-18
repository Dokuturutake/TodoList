using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoList.Data.Interface;

namespace TodoList.Data.FileIO
{
	public class FileIO : IOptionIO
	{
		public Dictionary<string,string> GetData(string path)
		{
			string fullPath = GetFileFullPath(path);
			if (Path.Exists(fullPath))
			{
				string json = File.ReadAllText(fullPath);
				return ToJsonDeserialize(json);
			}
			else { return null; }
		}

		public bool SetData(Dictionary<string,string> data, string path)
		{
			string jsonString = ToJsonSerialize(data);
			string fullPath = GetFileFullPath(path);
			File.WriteAllText(fullPath, jsonString);
			return true;
		}

		private static string GetFileFullPath(string path)
		{
			string AbsolutePath = FileSystem.AppDataDirectory;
			return Path.Combine(AbsolutePath, path);
		}
		
		private static string ToJsonSerialize<T>(T data)
		{
			return JsonSerializer.Serialize(data);
		}
		private static Dictionary<string, string> ToJsonDeserialize(string json)
		{
			return JsonSerializer.Deserialize<Dictionary<string, string>>(json);
		}

	}

}
