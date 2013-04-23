using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update.Scripting
{
    public interface IScriptEntryPoint
    {
        string ClassName { get; set; }
        string MethodName { get; set; }
    }
}
