using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdapter
{
    public static class DBAdapterEnums
    {
        public enum status
        {
            Success, Fail, Error, Waiting, Cancelled, ConnState
        }
        public enum state
        {
            connected, disconnected, suspended, resume
        }
    }
}
