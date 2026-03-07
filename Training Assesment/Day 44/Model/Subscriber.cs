using System;

namespace SaaSArchitect.Models
{
    public abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        protected Subscriber(Guid id, string name, DateTime joinDate)
        {
            ID = id;
            Name = name;
            JoinDate = joinDate;
        }

        public abstract decimal CalculateMonthlyBill();

        // Equality based on ID
        public override bool Equals(object obj)
        {
            if (obj is Subscriber other)
                return ID == other.ID;

            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        // Default sorting: JoinDate then Name
        public int CompareTo(Subscriber other)
        {
            int dateCompare = JoinDate.CompareTo(other.JoinDate);

            if (dateCompare != 0)
                return dateCompare;

            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}