using System;
using System.Linq;

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
            string[] str = { Name, EmployerName.Value, EmployerLocation.Value, JobType.Value, JobCoreCompetency.Value };

            if (string.Join("",str).Length < 1) return $"{Environment.NewLine}OOPS! This job does not seem to exist.{Environment.NewLine}";

            for (int i = 0; i < str.Length; i++) str[i] = str[i].Length > 0 ? str[i] : "Data not available";

            return $"{Environment.NewLine}ID: {Id}{Environment.NewLine}Name: {str[0]}{Environment.NewLine}Employer: {str[1]}{Environment.NewLine}Location: {str[2]}{Environment.NewLine}Position Type: {str[3]}{Environment.NewLine}Core Competency: {str[4]}{Environment.NewLine}";
        }

    }
}
