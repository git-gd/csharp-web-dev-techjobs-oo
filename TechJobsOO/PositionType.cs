using System;
namespace TechJobsOO
{
    public class PositionType : JobField
    {
        public PositionType(string value) : base(value)
        {

        }

        //public int Id { get; }
        //private static int nextId = 1;
        //public string Value { get; set; }

        //public PositionType()
        //{
        //    Id = nextId;
        //    nextId++;
        //}

        //public PositionType(string value) : this()
        //{
        //    Value = value;
        //}

        //public override bool Equals(object obj)
        //{
        //    return obj is PositionType type &&
        //           Id == type.Id;
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(Id);
        //}

        //public override string ToString()
        //{
        //    return Value;
        //}

        // DONE: Add custom Equals(), GetHashCode(), and ToString() methods.
    }
}
