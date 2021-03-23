﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Core.DTOs
{
    public class SkillDTO
    {
        public SkillDTO(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
