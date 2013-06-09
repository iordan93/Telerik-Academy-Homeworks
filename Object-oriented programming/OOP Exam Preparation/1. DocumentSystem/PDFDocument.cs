using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PDFDocument : EncryptableDocument
{
    private int? pages;

    public int? Pages
    {
        get { return this.pages; }
        set { this.pages = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages") 
        {
            this.Pages = int.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        base.SaveAllProperties(output);
    }
}
