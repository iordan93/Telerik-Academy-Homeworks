namespace _14.ApplyXsltTransformation
{
    using System;
    using System.Xml.Xsl;

    public class ApplyXsltTransformation
    {
        public static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../../catalogue-transformation.xsl");
            xslt.Transform("../../../catalogue.xml", "../../../catalogue.html");

            Console.WriteLine("The file has been transformed successfully Look for it in the main program folder.");
        }
    }
}
