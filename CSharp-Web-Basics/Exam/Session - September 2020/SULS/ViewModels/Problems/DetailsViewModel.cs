﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.ViewModels.Problems
{
    public class DetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<ProblemDetailsSubmissionViewModel> Problems { get; set; }
    }
}
