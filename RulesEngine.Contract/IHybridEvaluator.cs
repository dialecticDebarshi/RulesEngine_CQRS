using RuleEngine.Domain.Common;
using RuleEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Contract
{
    public interface IHybridEvaluator
    {
        public  Task<RuleResponse> EvaluateAsync(HealthcareClaim claim);
    }
}
