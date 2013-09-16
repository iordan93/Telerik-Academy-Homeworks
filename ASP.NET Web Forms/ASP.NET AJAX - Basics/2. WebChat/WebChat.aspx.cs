using _2.WebChat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.WebChat
{
    public partial class WebChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Creating the database at the first run
            //var context = new WebChatContext();
            //context.Messages.ToList();
        }

        protected void ButtonSendMessage_Click(object sender, EventArgs e)
        {
            string username = this.TextBoxUsername.Text;
            string message = this.TextBoxMessage.Text;

            var context = new WebChatContext();
            var author = context.Users.FirstOrDefault(u => u.Username == username);
            if (author == null)
            {
                var newUser = new User()
                {
                    Username = username
                };

                author = context.Users.Add(newUser);
                context.SaveChanges();
            }

            var newMessage = new Message()
            {
                Text = this.TextBoxMessage.Text,
                Author = author,
                CreationDate = DateTime.Now
            };

            context.Messages.Add(newMessage);
            context.SaveChanges();
        }

        public IQueryable<Message> ListViewMessages_GetData()
        {
            var context = new WebChatContext();
            return context.Messages
                .Include(m => m.Author)
                .OrderBy(m => m.CreationDate);
        }

        protected void TimerMessages_Tick(object sender, EventArgs e)
        {
            this.ListViewMessages.DataBind();
        }
    }
}