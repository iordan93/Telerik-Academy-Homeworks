using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AudioDocument : MultimediaDocument
{
    private int? sampleRate;

    public int? SampleRate
    {
        get { return sampleRate; }
        set { sampleRate = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if(key=="samplerate")
        {
            this.SampleRate = int.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));        
        base.SaveAllProperties(output);
    }
}