using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.Models
{
    public class User : Base, ICloneable
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string FullName
        {
            get
            {
                // C# 6.0
                return $"{FirstName} {LastName}"; 
            }
        }


        public byte Age2 { get; set; }

        public Gender Gender { get; set; }

        public bool IsActive { get; set; }

        public User()
        {

        }

        public User(string firstName, string lastName, bool isActive = true)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
            IsActive = isActive;
        }


        public override string ToString()
        {
            return FullName;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
