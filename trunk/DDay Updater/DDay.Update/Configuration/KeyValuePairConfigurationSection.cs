using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace DDay.Update.Configuration
{
    public class KeyValuePairConfigurationSection : ConfigurationSection
    {
        #region Private Fields

        private ConfigurationProperty _CollectionProperty;
        private ConfigurationPropertyCollection _PropertyList;

        #endregion

        #region Protected Properties

        protected ConfigurationProperty CollectionProperty
        {
            get { return _CollectionProperty; }
            set { _CollectionProperty = value; }
        }

        protected ConfigurationPropertyCollection PropertyList
        {
            get { return _PropertyList; }
            set { _PropertyList = value; }
        }

        #endregion

        #region Public Properties

        virtual public KeyValuePairConfigurationElement Items
        {
            get { return this[CollectionProperty] as KeyValuePairConfigurationElement; }
            set { this[CollectionProperty] = value; }
        }

        virtual new public KeyValuePairConfigurationElement this[string propertyName]
        {
            get { return Items[propertyName]; }
        }

        #endregion        

        #region Constructors

        public KeyValuePairConfigurationSection()
        {
            EnsurePropertyBag();
        }

        #endregion

        #region Protected Methods

        virtual protected ConfigurationPropertyCollection EnsurePropertyBag()
        {
            if (PropertyList == null)
            {
                CollectionProperty = new ConfigurationProperty(
                    null,
                    typeof(KeyValuePairConfigurationElement),
                    null,
                    ConfigurationPropertyOptions.IsDefaultCollection);
                PropertyList = new ConfigurationPropertyCollection();
                PropertyList.Add(CollectionProperty);
            }
            return PropertyList;
        }

        #endregion

        #region Overrides

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return EnsurePropertyBag();
            }
        }        

        #endregion
    }
}
