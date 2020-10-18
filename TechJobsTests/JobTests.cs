using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Employer employer = new Employer("ACME");
        Location location = new Location("Desert");
        PositionType positionType = new PositionType("Quality control");
        CoreCompetency coreCompetency = new CoreCompetency("Persistence");

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
            Job job = new Job("Product tester", employer, location, positionType, coreCompetency);

            //Use Assert statements to test that the constructor correctly assigns the value of each field.

            Assert.AreEqual("Product tester", job.Name);
            Assert.AreEqual("ACME", job.EmployerName.Value);
            Assert.AreEqual("Desert", job.EmployerLocation.Value);
            Assert.AreEqual("Quality control", job.JobType.Value);
            Assert.AreEqual("Persistence", job.JobCoreCompetency.Value);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            // Generate two Job objects that have identical field values EXCEPT for id. Test that Equals() returns false.
            Job jobA = new Job("Product tester", employer, location, positionType, coreCompetency);
            Job jobB = new Job("Product tester", employer, location, positionType, coreCompetency);

            Assert.IsFalse(jobA.Equals(jobB));
        }

        [TestMethod]
        public void JobToStringHasBlankLineBeforeAndAfter()
        {
            Job job = new Job("Product tester", employer, location, positionType, coreCompetency);

            string output = job.ToString();

            Assert.IsTrue(output.StartsWith(Environment.NewLine) && output.EndsWith(Environment.NewLine));
        }
    }
}
