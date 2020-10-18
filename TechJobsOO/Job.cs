using System;
using System.Linq;
using System.Text.RegularExpressions;
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

        private static string hasData(string str)
        {
            if (str.Length > 0) return str;
 
            return "Data not available";
        }

        public override string ToString()
        {
            if (Name.Length + EmployerName.Value.Length + EmployerLocation.Value.Length + JobType.Value.Length + JobCoreCompetency.Value.Length < 1) return $"{Environment.NewLine}OOPS! This job does not seem to exist.{Environment.NewLine}{Environment.NewLine}";

            string name = hasData(Name);
            string employerName = hasData(EmployerName.Value);
            string employerLocation = hasData(EmployerLocation.Value);
            string jobType = hasData(JobType.Value);
            string jobCoreCompetency = hasData(JobCoreCompetency.Value);

            string output = $"{Environment.NewLine}ID: {Id}{Environment.NewLine}Name: {name}{Environment.NewLine}Employer: {employerName}{Environment.NewLine}Location: {employerLocation}{Environment.NewLine}Position Type: {jobType}{Environment.NewLine}Core Competency: {jobCoreCompetency}{Environment.NewLine}{Environment.NewLine}";

            return output;
        }

        // DONE: Add the two necessary constructors.

        // DONE: Generate Equals() and GetHashCode() methods.
    }
}
