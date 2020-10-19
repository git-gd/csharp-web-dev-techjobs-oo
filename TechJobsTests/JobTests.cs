using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job jobA, jobB = null;

        [TestInitialize]
        public void InitTest()
        {
            jobA = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            jobB = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
        }

        [TestMethod]
        public void TestSettingJobId()
        {
            // Create two Job objects using the empty constructor
            Job jobC = new Job();
            Job jobD = new Job();

            // test that the ID values for the two objects are NOT the same and differ by 1
            Assert.IsTrue(jobC.Id == (jobD.Id - 1));
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            //Use Assert statements to test that the constructor correctly assigns the value of each field.
            Assert.AreEqual("Product tester", jobA.Name);
            Assert.AreEqual("ACME", jobA.EmployerName.Value);
            Assert.AreEqual("Desert", jobA.EmployerLocation.Value);
            Assert.AreEqual("Quality control", jobA.JobType.Value);
            Assert.AreEqual("Persistence", jobA.JobCoreCompetency.Value);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            // Generate two Job objects that have identical field values EXCEPT for id. Test that Equals() returns false.
            Assert.IsFalse(jobA.Equals(jobB));
        }

        [TestMethod]
        public void JobToStringHasBlankLineBeforeAndAfter()
        {
            // When passed a Job object, it should return a string that contains a blank line before and after the job information.
            string output = jobA.ToString();

            Assert.IsTrue(output.StartsWith(Environment.NewLine) && output.EndsWith($"{Environment.NewLine}"));
        }

        [TestMethod]
        public void JobToStringProducesLabelsForEachFieldWithDataOnNewLines()
        {
            // The string should contain a label for each field, followed by the data stored in that field. Each field should be on its own line.
            string output = jobA.ToString();

            string[] line = output.Split(Environment.NewLine);

            //ID: _______
            //Name: _______
            //Employer: _______
            //Location: _______
            //Position Type: _______
            //Core Competency: _______

            Assert.IsTrue(line[0] == "");
            Assert.IsTrue(line[1] == $"ID: {jobA.Id}");
            Assert.IsTrue(line[2] == $"Name: Product tester");
            Assert.IsTrue(line[3] == $"Employer: ACME");
            Assert.IsTrue(line[4] == $"Location: Desert");
            Assert.IsTrue(line[5] == $"Position Type: Quality control");
            Assert.IsTrue(line[6] == $"Core Competency: Persistence");
            Assert.IsTrue(line[7] == "");
        }

        [TestMethod]
        public void EmptyFieldSetToDataNotAvailable()
        {
            // If a field is empty, the method should add, “Data not available” after the label.

            Job job = new Job("NOT_BLANK", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));

            string output = job.ToString();

            string[] line = output.Split(Environment.NewLine);

            Assert.IsTrue(line[3] == $"Employer: Data not available");
            Assert.IsTrue(line[4] == $"Location: Data not available");
            Assert.IsTrue(line[5] == $"Position Type: Data not available");
            Assert.IsTrue(line[6] == $"Core Competency: Data not available");

            job = new Job("", new Employer("ACME"), new Location(""), new PositionType(""), new CoreCompetency(""));

            output = job.ToString();

            line = output.Split(Environment.NewLine);

            Assert.IsTrue(line[2] == $"Name: Data not available");
        }

        [TestMethod]
        public void NoJobFieldSetReturnsErrorMessage()
        {
            // (Bonus) If a Job object ONLY contains data for the id field, the method should return, “OOPS! This job does not seem to exist.”
            Job job = new Job("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));

            string output = job.ToString();

            Assert.AreEqual($"{Environment.NewLine}OOPS! This job does not seem to exist.{Environment.NewLine}", output);
        }
    }
}
