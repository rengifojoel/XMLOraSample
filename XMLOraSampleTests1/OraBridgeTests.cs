using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace XMLOraSample.Tests
{
    [TestClass()]
    public class OraBridgeTests
    {
        [TestMethod()]
        public void passXmlAsCLOBTest()
        {
            string xml = System.IO.File.ReadAllText("input.xml");
            string returnValue = string.Empty;
            XMLOraSample.OraBridge.passXmlAsCLOB(xml, ref returnValue);
            Assert.IsTrue( returnValue == "http://www.twitter.com");
        }
        [TestMethod()]
        public void passXmlAsXMLTest()
        {
            System.Xml.XmlDocument xml= new System.Xml.XmlDocument ();
            xml.LoadXml(System.IO.File.ReadAllText("input.xml"));
            string returnValue = string.Empty;
            XMLOraSample.OraBridge.passXmlAsXML(xml, ref returnValue);
            Assert.IsTrue(returnValue == "http://www.twitter.com");
        }
    }
}