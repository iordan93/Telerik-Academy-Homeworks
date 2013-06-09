using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WordDocument : OfficeDocument, IEditable
{
    private int? characters;

    public int? Characters
    {
        get { return this.characters; }
        set { this.characters = value; }
    }


    public void ChangeContent(string newContent)
    {
        this.Content=newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.Characters = int.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.Characters));
        base.SaveAllProperties(output);
    }
}