using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update.Scripting
{
    public interface IScript
    {
        string Text { get; set; }
        IScriptEntryPoint EntryPoint { get; set; }

        void Run();        
    }
}
