using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TextDocument : Document, IEditable
{
    // Fields
    private string charset;

    // Properties
    public string Charset
    {
        get { return this.charset; }
        set { this.charset = value; }
    }

    // Instance methods
    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
        {
            this.Charset = value;
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        base.SaveAllProperties(output);
    }
}