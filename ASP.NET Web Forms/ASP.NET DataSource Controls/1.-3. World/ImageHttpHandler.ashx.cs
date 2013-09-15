using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1._3.World
{
    public class ImageHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["Id"]))
            {
                string countryId = context.Request.QueryString["Id"].ToString();
                if (!string.IsNullOrEmpty(countryId))
                {
                    var result = RetrieveFlagImage(countryId);
                    if (result != null)
                    {
                        context.Response.BinaryWrite(result);
                        context.Response.End();
                    }
                }
            }
        }


        private byte[] RetrieveFlagImage(string countryId)
        {
            WorldEntities db = new WorldEntities();
            var country = db.Countries.Find(countryId);
            if (country != null)
            {
                return country.FlagImage;
            }

            return null;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
