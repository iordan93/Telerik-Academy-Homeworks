using System;
using System.Globalization;
using System.Threading;

namespace _11.Version
{
    // Usage of the attribute - it can be used on anything 
    // (classes, structures, interfaces, methods, and enumerations)
    [AttributeUsage(
        AttributeTargets.Struct |
        AttributeTargets.Class |
        AttributeTargets.Interface |
        AttributeTargets.Method |
        AttributeTargets.Enum
    )]
    class VersionAttribute : System.Attribute
    {
        // Private field
        private double version;
        
        // Public property to encapsulate the field which can be set only from this class
        // Version format - major.minor (a type that is well described as double)
        public double Version
        {
            get
            {
                return this.version;
            }
            private set
            {
                this.version = value;
            }
        }

        // Constructor to set the version
        public VersionAttribute(double version)
        {
            this.Version = version;
        }

        // Method to return the current version
        public override string ToString()
        {
            // Solve problems with decimal points and always print the decimal separator as '.'
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            return this.Version.ToString();
        }

        [VersionAttribute(1.1)]
        class VersionAttributeTest
        {
            static void Main()
            {
                // Get the current version using reflection - GetCustomAttributes
                // Even though the statement returns one value, the result is kept in an array
                object[] versionAttributes = typeof(VersionAttributeTest).GetCustomAttributes(false);

                Console.WriteLine("Version: {0}", versionAttributes[0]);
            }
        }
    }
}
