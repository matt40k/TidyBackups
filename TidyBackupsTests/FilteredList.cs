using System;
using NUnit.Framework;

namespace TidyBackupsTests
{
    using System.IO;
    using TidyBackups;

    [TestFixture]
    public class FilteredListTest
    {
        private string file1;           // Ignore file
        private string file2;           // Created Today
        private string file3;           // Created Yesterday
        private string file4;           // Created 90 days ago
        private string file5;           // Created 90 days ago
        private string file6;           // Corrupt zip

        private string dir;

        [SetUp]
        public void Setup()
        {
            string tmpFile1 = Path.GetTempFileName();
            string tmpFile2 = Path.GetTempFileName();
            string tmpFile3 = Path.GetTempFileName();
            string tmpFile4 = Path.GetTempFileName();
            string tmpFile5 = Path.GetTempFileName();
            string tmpFile6 = Path.GetTempFileName();

            this.dir = Path.Combine(Path.GetDirectoryName(tmpFile1), "TidyBackupsTest");
            if (!Directory.Exists(this.dir))
            {
                Directory.CreateDirectory(this.dir);
            }

            this.file1 = Path.Combine(this.dir, Path.GetFileName(tmpFile1));
            this.file2 = Path.Combine(this.dir, (Path.GetFileNameWithoutExtension(tmpFile2) + ".bak"));
            this.file3 = Path.Combine(this.dir, (Path.GetFileNameWithoutExtension(tmpFile3) + ".bak"));
            this.file4 = Path.Combine(this.dir, (Path.GetFileNameWithoutExtension(tmpFile4) + ".bak"));
            this.file5 = Path.Combine(this.dir, (Path.GetFileNameWithoutExtension(tmpFile5) + ".bak"));
            this.file6 = Path.Combine(this.dir, (Path.GetFileNameWithoutExtension(tmpFile6) + ".zip"));

            

            File.Move(tmpFile1, this.file1);
            File.Move(tmpFile2, this.file2);
            File.Move(tmpFile3, this.file3);
            File.Move(tmpFile4, this.file4);
            File.Move(tmpFile5, this.file5);         
            File.Move(tmpFile6, this.file6);

            DateTime today = DateTime.Today;
            DateTime yesterday = DateTime.Today.AddDays(-1);
            DateTime days90Ago = DateTime.Today.AddDays(-90);

            File.SetCreationTime(this.file2, today);
            File.SetCreationTime(this.file3, yesterday);
            File.SetCreationTime(this.file4, days90Ago);
            File.SetCreationTime(this.file5, days90Ago);
        }

        [Test]
        public void GetList_valid()
        {
            Logger logger = new Logger(null, true);
            FilteredList filteredList = new FilteredList(logger);


            int cnt = filteredList.GetList(this.dir, null).Count;

            Assert.AreEqual(cnt, 5);
        }


        [TearDown]
        public void Teardown()
        {
            File.Delete(file1);
            File.Delete(file2);
            File.Delete(file3);
            File.Delete(file4);
            File.Delete(file5);
            File.Delete(file6);
        }

    }
}
