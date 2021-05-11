using DBAdapter.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdapter
{
    public class coreentity : IDisposable
    {
        protected WEBIEIEntities objtIEIEntities { get; set; }

        public coreentity()
        {
            objtIEIEntities = new WEBIEIEntities();
        }

        public void CommitChanges()
        {
            try
            {
                objtIEIEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
