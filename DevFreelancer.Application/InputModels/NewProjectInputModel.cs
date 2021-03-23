﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Application.InputModels
{
    public class NewProjectInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime FinishedAt { get; set; }
    }
}
