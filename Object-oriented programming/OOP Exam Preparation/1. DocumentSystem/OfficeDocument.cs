using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class OfficeDocument : EncryptableDocument
{
    private string version;

    public string Version
    {
        get { return this.version; }
        set { this.version = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "version")
        {
            this.Version = value;
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("version", this.Version));
        base.SaveAllProperties(output);
    }
}