using System;
using System.Collections.Generic;
using System.Text;

namespace Semillitas_Core.Validators
{
    public class ValidationResult
    {
        public bool IsValid => Errors.Count == 0;
        public List<string> Errors { get; set; } = [];
    }
}
