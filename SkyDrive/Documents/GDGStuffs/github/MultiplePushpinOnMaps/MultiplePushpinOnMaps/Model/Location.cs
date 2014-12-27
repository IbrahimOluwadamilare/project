

using System.Collections.Generic;
using System.Device.Location;
using System.Xml.Serialization;



/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false, ElementName = "LOCATIONS")]
public partial class LOCATIONS
{

    private List<LOCATIONSLOCATION> itemsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LOCATION", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public List<LOCATIONSLOCATION> Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class LOCATIONSLOCATION
{

    private string idField;

    private string aDDRESSField;

    private string cITYField;

    private string sTATEField;

    private string pHONEField;

    private string cOUNTRYField;

    private string zIPField;

    private string wEBSITEField;

    private string eMAILField;

    private string lATITUDEField;

    private string lONGITUDEField;

    private string dESCRIPTIONField;

    private string name;

    private GeoCoordinate location;

    private string locationname;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ADDRESS
    {
        get
        {
            return this.aDDRESSField;
        }
        set
        {
            this.aDDRESSField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CITY
    {
        get
        {
            return this.cITYField;
        }
        set
        {
            this.cITYField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string STATE
    {
        get
        {
            return this.sTATEField;
        }
        set
        {
            this.sTATEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string PHONE
    {
        get
        {
            return this.pHONEField;
        }
        set
        {
            this.pHONEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string COUNTRY
    {
        get
        {
            return this.cOUNTRYField;
        }
        set
        {
            this.cOUNTRYField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ZIP
    {
        get
        {
            return this.zIPField;
        }
        set
        {
            this.zIPField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string WEBSITE
    {
        get
        {
            return this.wEBSITEField;
        }
        set
        {
            this.wEBSITEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EMAIL
    {
        get
        {
            return this.eMAILField;
        }
        set
        {
            this.eMAILField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string LATITUDE
    {
        get
        {
            return this.lATITUDEField;
        }
        set
        {
            this.lATITUDEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string LONGITUDE
    {
        get
        {
            return this.lONGITUDEField;
        }
        set
        {
            this.lONGITUDEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string DESCRIPTION
    {
        get
        {
            return this.dESCRIPTIONField;
        }
        set
        {
            this.dESCRIPTIONField = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public GeoCoordinate Location
    {
        get
        {
            return this.location;
        }
        set
        {
            this.location = value;
        }
    }

    public string LocationName
    {
        get
        {
            return this.locationname;
        }
        set
        {
            this.locationname = value;
        }
    }
}
