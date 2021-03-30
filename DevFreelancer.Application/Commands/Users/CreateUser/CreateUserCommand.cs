﻿using MediatR;
using System;

namespace DevFreelancer.Application.Commands.Users.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
