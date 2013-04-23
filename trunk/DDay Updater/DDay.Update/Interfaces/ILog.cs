using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update
{
    public interface ILog
    {
        void Debug(object msg);        
        void Debug(object msg, Exception e);
        void Error(object msg);
        void Error(object msg, Exception e);
        void Fatal(object msg);
        void Fatal(object msg, Exception e);
        void Info(object msg);
        void Info(object msg, Exception e);
        void Warn(object msg);
        void Warn(object msg, Exception e);
    }
}
