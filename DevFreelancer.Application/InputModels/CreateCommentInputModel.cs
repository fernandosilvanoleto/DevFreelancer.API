﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Application.InputModels
{
    public class CreateCommentInputModel
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
