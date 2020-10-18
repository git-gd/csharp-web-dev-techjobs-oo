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

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            // Declare and initialize a new Job object with the following data: "Product tester" for Name,
            // "ACME" for EmployerName, "Desert" for JobLocation, "Quality control" for JobType, and "Persistence" for JobCoreCompetency.
            Employer employer = new Employer("ACME");
            Location location = new Location("Desert");
            PositionType positionType = new PositionType("Quality control");
            CoreCompetency coreCompetency = new CoreCompetency("Persistence");

            Job job = new Job("Product tester", employer, location, positionType, coreCompetency);

            //Use Assert statements to test that the constructor correctly assigns the value of each field.

            Assert.AreEqual(job.Name, "Product tester");
            Assert.AreEqual(job.EmployerName.Value, "ACME");
            Assert.AreEqual(job.EmployerLocation.Value, "Desert");
            Assert.AreEqual(job.JobType.Value, "Quality control");
            Assert.AreEqual(job.JobCoreCompetency.Value, "Persistence");
        }
    }
}
