using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class EncryptableDocument : BinaryDocument, IEncryptable
{
    // Fields
    private bool isEncrypted;

    // Properties
    public bool IsEncrypted
    {
        get
        {
            return this.isEncrypted;
        }
        set
        {
            this.isEncrypted = value;
        }
    }

    // Instance methods
    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override string ToString()
    {
        return this.IsEncrypted ? ToStringHelper("encrypted") : base.ToString(); 
    }
}