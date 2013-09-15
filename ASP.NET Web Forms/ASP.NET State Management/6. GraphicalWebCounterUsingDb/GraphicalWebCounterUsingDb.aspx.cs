using _6.GraphicalWebCounterUsingDb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _6.GraphicalWebCounterUsingDb
{
    public partial class GraphicalWebCounterUsingDb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int usersCount = 0;

            using (var context = new WebCounterContext())
            {
                var counter = context.WebCounters.FirstOrDefault();
                if (counter == null)
                {
                    counter = new WebCounter()
                    {
                        UsersCount = 0
                    };

                    context.WebCounters.Add(counter);
                    context.SaveChanges();
                }

                context.WebCounters.First().UsersCount++;
                context.SaveChanges();

                usersCount = context.WebCounters.First().UsersCount;
            }

            HttpWebRequest request = WebRequest.Create("http://localhost:6657/.img") as HttpWebRequest;
            request.Method = "POST";

            StreamWriter content = new StreamWriter(request.GetRequestStream());
            content.Write(string.Format(
                "We have had {0} {1} since the start of the SQL server.",
                usersCount,
                usersCount == 1 ? "user" : "users"));
            content.Close();

            Response.ContentType = "image/jpg";
            byte[] buffer = new byte[0];
            using (var memoryStream = new MemoryStream())
            {
                request.GetResponse().GetResponseStream().CopyTo(memoryStream);
                Response.BinaryWrite(memoryStream.ToArray());
            }

            request.GetResponse().Close();
        }
    }
}