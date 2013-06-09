using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class MultimediaDocument : BinaryDocument
{
    private int? length;

    public int? Length
    {
        get { return this.length; }
        set { this.length = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.Length = int.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("length", this.Length));
        base.SaveAllProperties(output);
    }
}
