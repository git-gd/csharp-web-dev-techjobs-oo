using System;
using System.Xml;

namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            string oName = (Name.Length > 0) ? Name : "Data not available";
            string oEmployerName = (EmployerName.ToString().Length > 0) ? EmployerName.ToString() : "Data not available";
            string oEmployerLocation = (EmployerLocation.ToString().Length > 0) ? EmployerLocation.ToString() : "Data not available";
            string oJobType = (JobType.ToString().Length > 0) ? JobType.ToString() : "Data not available";
            string oJobCoreCompetency = (JobCoreCompetency.ToString().Length > 0) ? JobCoreCompetency.ToString() : "Data not available";

            string output = $"{Environment.NewLine}ID: {Id}{Environment.NewLine}Name: {oName}{Environment.NewLine}Employer: {oEmployerName}{Environment.NewLine}Location: {oEmployerLocation}{Environment.NewLine}Position Type: {oJobType}{Environment.NewLine}Core Competency: {oJobCoreCompetency}{Environment.NewLine}{Environment.NewLine}";
            return output;
        }

        // DONE: Add the two necessary constructors.

        // DONE: Generate Equals() and GetHashCode() methods.
    }
}
