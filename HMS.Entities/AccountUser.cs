using HMS.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public class AccountUser : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}
