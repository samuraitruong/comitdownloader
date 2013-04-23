using System;
using System.Collections.Generic;
using System.Text;
using DDay.Script;
using System.CodeDom.Compiler;

namespace DDay.Update.Scripting
{
    public class Script : IScript
    {
        #region Private Fields

        string _Text;
        string _ScriptLanguageFullyQualifiedTypeName;
        IScriptEntryPoint _EntryPoint;

        #endregion

        #region Constructors

        public Script(string scriptLanguageTypeName)
        {
            _ScriptLanguageFullyQualifiedTypeName = scriptLanguageTypeName;
        }

        #endregion

        #region IScript Members

        public void Run()
        {
            IScriptableLanguage scriptableLanguage = null;

            Type type = Type.GetType(_ScriptLanguageFullyQualifiedTypeName, false);
            if (type != null)
                scriptableLanguage = Activator.CreateInstance(type) as IScriptableLanguage;

            if (scriptableLanguage == null)
                throw new ScriptException("The scripting language could not be loaded. Are the libraries present?");

            // Add a reference to DDay.Update.dll, if the language allows for it
            ILibraryReferencableLanguage lrLanguage = scriptableLanguage as ILibraryReferencableLanguage;
            if (lrLanguage != null)
            {
                lrLanguage.AddReference("DDay.Update.dll");
            }

            CompilerError[] errors = scriptableLanguage.Compile(Text);
            if (errors.Length > 0)
            {
                List<string> errorMessages = new List<string>();
                foreach (CompilerError error in errors)
                    errorMessages.Add(error.ErrorText);

                throw new ScriptException(
                    "The script had errors: " + Environment.NewLine +
                        string.Join(Environment.NewLine, errorMessages.ToArray()),
                    errors);
            }

            scriptableLanguage.Run(EntryPoint.ClassName, EntryPoint.MethodName);
        }

        #endregion

        #region IScript Members

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        public IScriptEntryPoint EntryPoint
        {
            get { return _EntryPoint; }
            set { _EntryPoint = value; }
        }

        #endregion
    }
}
