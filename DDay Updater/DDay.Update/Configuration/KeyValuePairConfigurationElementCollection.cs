using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DDay.Update.Configuration
{
    public class KeyValuePairConfigurationElementCollection : ConfigurationElementCollection
    {
        public KeyValuePairConfigurationElementCollection()
        {            
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new KeyValuePairConfigurationElement();
        }
        
        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            KeyValuePairConfigurationElement elm = new KeyValuePairConfigurationElement();
            elm.Name = elementName;
            return elm;            
        }


        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((KeyValuePairConfigurationElement)element).Name;
        }

        public KeyValuePairConfigurationElement this[int index]
        {
            get
            {
                return (KeyValuePairConfigurationElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public KeyValuePairConfigurationElement this[string Name]
        {
            get
            {
                return (KeyValuePairConfigurationElement)BaseGet(Name);
            }
        }

        public int IndexOf(KeyValuePairConfigurationElement kvp)
        {
            return BaseIndexOf(kvp);
        }

        public void Add(KeyValuePairConfigurationElement kvp)
        {
            BaseAdd(kvp);

            // Add custom code here.
        }

        protected override void  BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
            // Add custom code here.
        }

        public void Remove(KeyValuePairConfigurationElement kvp)
        {
            if (BaseIndexOf(kvp) >= 0)
                BaseRemove(kvp.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
            // Add custom code here.
        }
    }
}
