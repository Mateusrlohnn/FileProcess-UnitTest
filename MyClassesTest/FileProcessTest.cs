using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTest;
using System;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.txt";
        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        #region Test Initialize e Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName == "FileNameDoesExist")
            {
                SetGoodFileName();

                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Creating File: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "FileNameDoesExist")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting File: {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }

        #endregion

        [TestMethod]
        [Description("Check to see if a file does exist.")]
        [Owner("Mateus")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing File: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsTrue(fromCall);
        }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];

            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace(
                    "[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                );
            }
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("Mateus")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string fileName;    
            bool fromCall;
                
            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";
            TestContext.WriteLine($"Checking file: {fileName}");

            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if a file does NOT exist.")]
        [Owner("Mateus")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();

            bool fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("Mateus")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        [Owner("Mateus")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                // Teste passou
                return;
            }

            Assert.Fail("Fail expected");
        }
    }
}
