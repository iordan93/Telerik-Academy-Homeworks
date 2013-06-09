using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Document : IDocument
{
    // Fields
    private string name;
    private string content;

    // Properties
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Content
    {
        get { return this.content; }
        set { this.content = value; }
    }

    // Instance methods
    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }

        if (key == "content")
        {
            this.Content = value;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    protected string PropertiesToString()
    {
        var output = new List<KeyValuePair<string, object>>();
        SaveAllProperties(output);
        string properties = String.Join(";", from pair in output
                                             where pair.Value != null
                                             orderby pair.Key
                                             select pair.Key + "=" + pair.Value);
        return properties;
    }

    protected string ToStringHelper(string info) 
    {
        return String.Format("{0}[{1}]",this.GetType(),info);
    }

    public override string ToString()
    {
        return ToStringHelper(PropertiesToString());
    }
}