using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoApp_2_WebApplication1
{
    public partial class TodoAppList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        public void DisplayData()
        {
            const string url = "https://localhost:44397/api/todos";

            using (var client = new HttpClient())
            {
                //데이터 전송
                var json = JsonConvert.SerializeObject(new Todo { Title = "HttpClient", IsDone = true });
                var post = new StringContent(json, Encoding.UTF8, "application/json");
                client.PostAsync(url, post).Wait();

                //데이터 수신
                var response = client.GetAsync(url).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                var todos = JsonConvert.DeserializeObject<List<Todo>>(result);

                //필터링 : LINQ로 함수형 프로그램 스타이 구현 
                // Select(): map()
                // var q = todos.Select(t => t);
                //var q = from todo in todos
                //        select todo;

                var query = todos.AsQueryable<Todo>();
                //query = query.Where(it => it.Id % 2 == 0);

                if (DateTime.Now.Second % 2 == 0)
                {
                    query = query.Where(it => it.Id % 2 == 0); //짝수 
                }
                else
                {
                    query = query.Where(it => it.Id % 2 == 1); //홀수 
                }

                // 조건처리 
                query = query.Where(it => it.IsDone == false);

                // 정렬 
                const string sortOrder = "Title";
                query = (sortOrder == "Title" ? query = query.OrderBy(it => it.Title) : query);

                var q = query.Select(t => new TodoViewModel
                {
                    Title = t.Title,
                    IsDone = t.IsDone
                });


                //var q = from todo in todos
                //        select new TodoViewModel { Title = t.Title, IsDone = t.IsDone };


                //IEnumerable < Todo > q = todos.Select(t => t);


                //데이터 바인딩
                this.GridView1.DataSource = q;
                this.GridView1.DataBind();

                this.GridView2.DataSource = 
                    todos
                    .Where(t => t.Id % 2 == 1 && t.IsDone == false)
                    .OrderByDescending(t => t.Title)
                    .Select(t => new { 제목 = t.Title, 완료여부 = t.IsDone })
                    .ToList();

                this.GridView2.DataBind();

            }
        }
    }
    public class TodoViewModel
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }

    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }

}