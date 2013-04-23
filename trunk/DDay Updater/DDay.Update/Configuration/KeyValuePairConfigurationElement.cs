using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DDay.Update.Configuration
{
    public class KeyValuePairConfigurationElement : ConfigurationElementCollection
    {
        #region Private Fields

        private KeyValuePairConfigurationElement _Parent;

        #endregion

        #region Public Properties

        [ConfigurationProperty("name", IsRequired = false)]
        virtual public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = false)]
        virtual public string Value
        {
            get { return (string)base["value"]; }
            set { base["value"] = value; }
        }

        [ConfigurationProperty("index", IsRequired = false)]
        virtual public int Index
        {
            get { return (int)base["index"]; }
            set { base["index"] = value; }
        }

        virtual public string FullName
        {
            get
            {
                if (Parent != null &&
                    Parent.FullName.Trim().Length > 0)
                    return Parent.FullName + "." + Name;
                return Name;
            }
        }

        virtual public KeyValuePairConfigurationElement Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }        
        
        virtual new public KeyValuePairConfigurationElement this[string propertyName]
        {
            get
            {
                List<string> pName = new List<string>(propertyName.Split('.'));

                foreach (KeyValuePairConfigurationElement element in this)
                {
                    string[] localName = element.Name.Split('.');

                    // Check if each segment name matches
                    bool isEqual = true;
                    for (int i = 0; i < localName.Length; i++)
                    {
                        if (!localName[i].Equals(pName[i]))
                        {
                            isEqual = false;
                            break;
                        }
                    }

                    // If all segments match to begin with, then let's move on!
                    if (isEqual)
                    {
                        // Check if our name matches the property name
                        if (pName.Count == localName.Length)
                        {
                            return element;
                        }
                        else
                        {
                            // Trim the segment name parts we've already handled
                            for (int i = 0; i < localName.Length; i++)
                                pName.RemoveAt(0);

                            // Find the item that matches the rest of the name
                            return element[string.Join(".", pName.ToArray())];
                        }
                    }
                }
                return null;
            }
        }

        #endregion

        #region Constructor

        public KeyValuePairConfigurationElement()
        {
        }

        public KeyValuePairConfigurationElement(KeyValuePairConfigurationElement parent)
        {
            Parent = parent;
        }

        #endregion        

        #region Public Methods

        virtual public object BaseProperty(string propertyName)
        {
            return base[propertyName];
        }

        virtual public object BaseProperty(ConfigurationProperty prop)
        {
            return base[prop];
        }

        virtual public void SetBaseProperty(string propertyName, object value)
        {
            base[propertyName] = value;
        }

        virtual public void SetBaseProperty(ConfigurationProperty prop, object value)
        {
            base[prop] = value;
        }

        #endregion

        #region Overrides

        protected override ConfigurationElement CreateNewElement()
        {
            return new KeyValuePairConfigurationElement(this);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            KeyValuePairConfigurationElement elm = element as KeyValuePairConfigurationElement;
            if (elm != null)
                return elm.Name + elm.Index;
            return string.Empty;
        }

        #endregion
    }
}
