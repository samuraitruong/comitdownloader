using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update.Scripting
{
    public class ScriptException : Exception
    {
        object _RelatedObject;

        public object RelatedObject
        {
            get { return _RelatedObject; }
            set { _RelatedObject = value; }
        }

        public ScriptException()
        {
        }

        public ScriptException(string msg) : base(msg)
        {
        }

        public ScriptException(string msg, object relatedObject)
        {
            RelatedObject = relatedObject;
        }
    }
}
