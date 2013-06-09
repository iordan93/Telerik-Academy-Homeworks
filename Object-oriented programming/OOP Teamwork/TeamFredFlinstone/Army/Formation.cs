using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army
{
    public delegate void FormationHandler<T>(T sender, EventArgs e);

    public class Formation : INameable
    {
        public event FormationHandler<Formation> FormationConfirmation;

        private string name;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Formation(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }

        public void CheckUnits()
        {
            FormationHandler<Formation> handler = this.FormationConfirmation;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
