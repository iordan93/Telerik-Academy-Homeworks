using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ErrorLogger
{
    public class Logger
    {
        // Singleton
        private static Logger errorLogger;

        private Logger() 
        {
        }

        public static void Log() 
        {
            StreamWriter writer = new StreamWriter("D:\\test.txt");
        }

        public static Logger ErrorLogger
        {
            get
            {
                if (errorLogger == null)
                {
                    errorLogger = new Logger();
                }
                return errorLogger;
            }
        }
    }
}
