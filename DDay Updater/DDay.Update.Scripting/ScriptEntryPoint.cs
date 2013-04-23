using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update.Scripting
{
    public class ScriptEntryPoint : IScriptEntryPoint
    {
        #region Private Fields

        string _ClassName;
        string _MethodName;

        #endregion

        #region Constructors

        public ScriptEntryPoint()
        {
        }

        public ScriptEntryPoint(string className, string methodName)
        {
            ClassName = className;
            MethodName = methodName;
        }

        #endregion

        #region IScriptEntryPoint Members

        public string ClassName
        {
            get { return _ClassName; }
            set { _ClassName = value; }
        }

        public string MethodName
        {
            get { return _MethodName; }
            set { _MethodName = value; }
        }

        #endregion        
    }
}
