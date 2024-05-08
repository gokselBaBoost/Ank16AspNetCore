using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DTO
{
    public class AccountUserDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
    }

    public enum AccountType
    {
        Admin = 1,
        ReportUser = 2,
        ModeratorUser = 3,
        OperationUser = 4
    }
}
