using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace UnitTests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly TradingNetworkContext Context;

        public TestCommandBase()
        {
            Context = TradingNetworkContextFactory.Create();
        }
        public void Dispose()
        {
            TradingNetworkContextFactory.Destroy(Context);
        }
    }
}
