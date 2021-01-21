using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBridge;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigBridge.Tests
{
    [TestClass()]
    public class ConfigBridgeTests
    {
        public ConfigBridge configBridge = new ConfigBridge(true);

        [TestMethod()]
        public void DeserializeConnConfigTest()
        {
            configBridge.DeserializeConnConfig();
        }
    }
}