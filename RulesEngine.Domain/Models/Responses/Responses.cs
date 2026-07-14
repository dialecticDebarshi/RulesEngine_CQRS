using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Domain.Models.Responses
{
    //internal class Responses
    //{
    //}
    public class RuleEvaluationResult
    {
        public bool IsSuccess { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<string> Messages { get; set; } = new();
    }
}
