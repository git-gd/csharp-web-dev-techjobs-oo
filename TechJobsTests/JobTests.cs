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
            // When passed a Job object, it should return a string that contains a blank line before and after the job information.
            Job job = new Job("Product tester", employer, location, positionType, coreCompetency);

            string output = job.ToString();

            Assert.IsTrue(output.StartsWith(Environment.NewLine) && output.EndsWith(Environment.NewLine));
        }

        [TestMethod]
        public void JobToStringProducesLabelsForEachFieldWithDataOnNewLines()
        {
            // The string should contain a label for each field, followed by the data stored in that field. Each field should be on its own line.
            Job job = new Job("Product tester", employer, location, positionType, coreCompetency);

            string output = job.ToString();

            string[] line = output.Split(Environment.NewLine);

            //ID: _______
            //Name: _______
            //Employer: _______
            //Location: _______
            //Position Type: _______
            //Core Competency: _______

            Assert.IsTrue(line[0] == "");
            Assert.IsTrue(line[1] == $"ID: {job.Id}");
            Assert.IsTrue(line[2] == $"Name: Product tester");
            Assert.IsTrue(line[3] == $"Employer: {employer}");
            Assert.IsTrue(line[4] == $"Location: {location}");
            Assert.IsTrue(line[5] == $"Position Type: {positionType}");
            Assert.IsTrue(line[6] == $"Core Competency: {coreCompetency}");
            Assert.IsTrue(line[7] == "");
        }

        [TestMethod]
        public void EmptyFieldSetToDataNotAvailable()
        {
            //If a field is empty, the method should add, “Data not available” after the label.
            Employer employerB = new Employer("");
            Location locationB = new Location("");
            PositionType positionTypeB = new PositionType("");
            CoreCompetency coreCompetencyB = new CoreCompetency("");

            Job job = new Job("", employerB, locationB, positionTypeB, coreCompetencyB);

            string output = job.ToString();

            string[] line = output.Split(Environment.NewLine);

            Assert.IsTrue(line[0] == "");
            Assert.IsTrue(line[1] == $"ID: {job.Id}");
            Assert.IsTrue(line[2] == $"Name: Data not available");
            Assert.IsTrue(line[3] == $"Employer: Data not available");
            Assert.IsTrue(line[4] == $"Location: Data not available");
            Assert.IsTrue(line[5] == $"Position Type: Data not available");
            Assert.IsTrue(line[6] == $"Core Competency: Data not available");
            Assert.IsTrue(line[7] == "");
        }
    }
}
