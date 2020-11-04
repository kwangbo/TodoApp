using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TodoApp.Models
{
    public class TodoRepositoryFile : ITodoRepository
    {

        private readonly string _filePath = "";

        private static List<Todo> _todos = new List<Todo>();
        public TodoRepositoryFile()
        {
            _todos = new List<Todo>
            {
                new Todo { Id = 1, Title = "ASP.NET Core 학습", IsDone = false },
                new Todo { Id = 2, Title = "Blazor 학습", IsDone = false },
                new Todo { Id = 3, Title = "C# 학습", IsDone = true }
            };
        }


        public TodoRepositoryFile(string filePath = @"D:\temp\Todos.txt")
        {
            this._filePath = filePath;
            string[] todos = File.ReadAllLines(filePath, Encoding.Default);

            foreach (var t in todos)
            {

                string[] line = t.Split(',');
                Todo txtItem = new Todo();
                txtItem.Id = Convert.ToInt32(line[0]);
                txtItem.Title = line[1].ToString();
                txtItem.IsDone = Convert.ToBoolean(line[2]);                
                _todos.Add(txtItem);

                //_todos.Add(new Todo {IsDone = Convert.ToBoolean(todos[2]), Title = todos[1], Id = Convert.ToInt32(todos[0]) });


            }


        }

        public void Add(Todo model)
        {
            model.Id = _todos.Max(t => t.Id) + 1;
            _todos.Add(model);

            //파일저장 
            string data = "";
            foreach (var t in _todos)
            {
                data += $"{t.Id},{t.Title},{t.IsDone}{Environment.NewLine}"  ;
            }

            using (StreamWriter sw =new StreamWriter(_filePath))
            {
                sw.Write(data);
                sw.Close();
                //sw.Dispose();
            }

        }
        public List<Todo> GetAll()
        {
            return _todos.ToList();
        }
    }

}

