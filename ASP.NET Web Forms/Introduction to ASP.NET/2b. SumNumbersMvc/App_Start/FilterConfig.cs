﻿using System.Web;
using System.Web.Mvc;

namespace _2b.SumNumbersMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}