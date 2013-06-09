using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ExcelDocument : OfficeDocument
{
    private int? rows;
    private int? cols;

    public int? Rows
    {
        get { return this.rows; }
        set { this.rows = value; }
    }

    public int? Cols
    {
        get { return this.cols; }
        set { this.cols = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.Rows = int.Parse(value);
        }
        if (key == "cols")
        {
            this.Cols = int.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        output.Add(new KeyValuePair<string, object>("cols", this.Cols));
        base.SaveAllProperties(output);
    }
}