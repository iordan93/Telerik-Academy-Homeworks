using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5.GraphicalWebCounter
{
    public partial class GraphicalWebCounter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["userCounter"] == null)
            {
                Application["userCounter"] = 1;
            }

            else
            {
                int userCounter = Convert.ToInt32(Application["userCounter"]);
                userCounter++;
                Application["userCounter"] = userCounter;
            }

            HttpWebRequest request = WebRequest.Create("http://localhost:6310/.img") as HttpWebRequest;
            request.Method = "POST";

            StreamWriter content = new StreamWriter(request.GetRequestStream());
            content.Write(string.Format(
                "We have had {0} {1} since the start of this application.",
                Application["userCounter"],
                (int)Application["userCounter"] == 1 ? "user" : "users"));
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