using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Samples.Infrastructure.Entity
{
    public class ReferencePerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override bool Equals(object obj)
        {
            ReferencePerson other = (ReferencePerson)obj;
            return other != null
                && this.GetType() == obj.GetType()
                && FirstName.Equals(other.FirstName)
                && LastName.Equals(other.LastName);
        }
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode()+this.LastName.GetHashCode();
        }
    }
}
