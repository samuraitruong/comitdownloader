using System;
using System.Collections.Generic;
using System.Text;
using DDay.Script;

namespace DDay.Update.Scripting
{
    public class CSharpScript : Script
    {
        public CSharpScript() : base("DDay.Script.CSharp.CSharpScriptLanguage, DDay.Script.CSharp")
        {
        }
    }
}
