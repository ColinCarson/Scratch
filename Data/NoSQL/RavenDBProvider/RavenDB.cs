using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Contracts;

namespace RavenDBProvider
{
    public class RavenDB : IRavenDBProvider
    {
        public void OpenSession()
        {
            throw new NotImplementedException();
        }

        public void OpenSession(string databasename)
        {
            throw new NotImplementedException();
        }
    }
}
