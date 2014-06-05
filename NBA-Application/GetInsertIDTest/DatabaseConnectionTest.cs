using NBA_Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace GetInsertIDTest
{
    
    
    /// <summary>
    ///This is a test class for DatabaseConnectionTest and is intended
    ///to contain all DatabaseConnectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatabaseConnectionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetInsertID
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Sasa2905\\Documents\\skola\\P4\\SE22\\Individuele opdracht\\NBA-Application\\NBA-Application", "/")]
        [UrlToTest("http://localhost:12672/AdminstratorForm.aspx")]
        public void GetInsertIDTest()
        {
            DatabaseConnection target = new DatabaseConnection(); // TODO: Initialize to an appropriate value
            string ID = "PlayerID"; // TODO: Initialize to an appropriate value
            string tabelname = "Player"; // TODO: Initialize to an appropriate value
            int expected = 11; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetInsertID(ID, tabelname);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetIDFromName
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Sasa2905\\Documents\\skola\\P4\\SE22\\Individuele opdracht\\NBA-Application\\NBA-Application", "/")]
        [UrlToTest("http://localhost:12672/AdminstratorForm.aspx")]
        [DeploymentItem("NBA-Application.dll")]
        public void GetIDFromNameTest()
        {
            DatabaseConnection_Accessor target = new DatabaseConnection_Accessor(); // TODO: Initialize to an appropriate value
            string Name = "Meny Metekia"; // TODO: Initialize to an appropriate value
            string tabelname = "Player"; // TODO: Initialize to an appropriate value
            string idcolumn = "PlayerID"; // TODO: Initialize to an appropriate value
            string namecolumn = "Name"; // TODO: Initialize to an appropriate value
            int expected = 6; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetIDFromName(Name, tabelname, idcolumn, namecolumn);
            Assert.AreEqual(expected, actual);
        }
    }
}
