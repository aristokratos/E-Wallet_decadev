using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet_App.Entity.Dtos
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DOB { get; set; }

        public DateTime DateCreated { get; set; }

        public string Gender { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string VerificationToken { get; set; }
        public DateTime VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime ResetTokenExpires { get; set; }
    }
}