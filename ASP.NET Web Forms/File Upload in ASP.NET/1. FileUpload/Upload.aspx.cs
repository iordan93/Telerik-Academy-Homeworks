using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using _1.FileUpload.Models;

namespace _1.FileUpload
{
    public partial class Upload : System.Web.UI.Page
    {
        private const string ZipFileExtension = "zip";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            Response.ContentType = "application/json";

            try
            {
                HttpPostedFile file = Request.Files["fileUpload"];
                string extension = GetExtension(file.FileName);

                if (extension == ZipFileExtension)
                {
                    MemoryStream zipFileAsStream = WriteToMemoryStream(file);

                    WriteAllFilesToDb(zipFileAsStream);

                    Response.StatusCode = (int)HttpStatusCode.NoContent;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        private string GetExtension(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf('.') + 1);
        }

        private MemoryStream WriteToMemoryStream(HttpPostedFile file)
        {
            int length = file.ContentLength;
            byte[] fileData = new byte[length + 1];
            Stream fileStream = file.InputStream;
            fileStream.Read(fileData, 0, length);

            MemoryStream stream = new MemoryStream(fileData);
            return stream;
        }

        private static void WriteAllFilesToDb(MemoryStream stream)
        {
            ZipInputStream fileFromMemory = new ZipInputStream(stream);
            var entry = fileFromMemory.GetNextEntry();

            while (entry != null)
            {
                WriteFileToDb(fileFromMemory);

                entry = fileFromMemory.GetNextEntry();
            }
        }

        private static void WriteFileToDb(ZipInputStream fileFromMemory)
        {
            MemoryStream unzippedFileMemoryStream = new MemoryStream();
            byte[] buffer = new byte[4096];

            using (unzippedFileMemoryStream)
            {
                StreamUtils.Copy(fileFromMemory, unzippedFileMemoryStream, buffer);

                using (var sr = new StreamReader(unzippedFileMemoryStream, System.Text.Encoding.UTF8))
                {
                    unzippedFileMemoryStream.Seek(0, SeekOrigin.Begin);
                    string fileContent = sr.ReadToEnd();
                    using (var context = new FileEntryContext())
                    {
                        context.FileEntries.Add(new FileEntry()
                        {
                            Content = fileContent
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}