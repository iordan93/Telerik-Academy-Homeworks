namespace _6.GraphicalWebCounterUsingDb
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;
    using System.Text;
    using System.Web;

    public class TextToImageHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string text = GetTextFromRequest(context);
            Bitmap bitmap = new Bitmap(1, 1);
            Font font = new Font("Arial", 25, FontStyle.Regular, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = (int)graphics.MeasureString(text, font).Width;
            int height = (int)graphics.MeasureString(text, font).Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font, new SolidBrush(Color.FromArgb(0, 0, 0)), 0, 0);
            graphics.Flush();
            string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".jpg";
            bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        }

        private string GetTextFromRequest(HttpContext context)
        {
            string text = string.Empty;
            using (Stream receiveStream = context.Request.InputStream)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    text = readStream.ReadToEnd();
                }
            }

            return text;
        }
    }
}