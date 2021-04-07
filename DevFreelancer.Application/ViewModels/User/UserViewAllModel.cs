using DevFreelancer.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Application.ViewModels
{
    public class UserViewAllModel
    {
        public UserViewAllModel(string fullName, string email, DateTime? birthDate, DateTime createdAt, bool active)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Active = active;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
    }
}
