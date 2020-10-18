using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            // Create two Job objects using the empty constructor
            Job jobA = new Job();
            Job jobB = new Job();

            // test that the ID values for the two objects are NOT the same and differ by 1
            Assert.IsTrue(jobA.Id == (jobB.Id - 1));
        }
    }
}
