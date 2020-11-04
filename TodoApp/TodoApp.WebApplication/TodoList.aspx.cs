using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoApp.WebApplication
{
    public partial class TodoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         

        }

       
        
    }

    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}