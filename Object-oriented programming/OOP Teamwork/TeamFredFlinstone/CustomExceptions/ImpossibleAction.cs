using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class ImpossibleActionException : ArgumentException
    {
        private string action;

        public string Action
        {
            get { return action; }
            private set { action = value; }
        }

        private string reason;

        public string Reason
        {
            get { return reason; }
            private set { reason = value; }
        }

        public ImpossibleActionException(string action, string reason)
            : base(String.Format("Action {0} cannot be completed because {1}", action, reason))
        {
            this.Action = action;
            this.Reason = reason;
        }
    }
}
