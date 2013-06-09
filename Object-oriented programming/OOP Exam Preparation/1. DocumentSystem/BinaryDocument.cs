using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class BinaryDocument : Document
{
    // Best practice: Initialize int? with null
    private int? size;

    public int? Size
    {
        get { return this.size; }
        set { this.size = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.Size = int.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("size", this.Size));
        base.SaveAllProperties(output);
    }
}