using RuleEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Domain.Models
{
    public class RuleEvaluationResult
    {
        public bool IsSuccess { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<string> Messages { get; set; } = new();
    }
    public class HCRuleEvaluator //: IRuleEvaluator
        {
            //private readonly RulesEngine.RulesEngine _engine;

            //public HCRuleEvaluator(Workflow[] workflows)
            //{
            //    // Workflows are loaded from MSSQL or JSON files
            //    _engine = new RulesEngine.RulesEngine(workflows);
            //}

            //public async Task<bool> ValidatePatientEligibility(PatientData patient)
            //{
            //    // 'PatientData' would be your input object
            //    List<RuleResultTree> resultList = await _engine.ExecuteAllRulesAsync("EligibilityWorkflow", patient);

            //    // Log results for Healthcare Audit Trails
            //    return resultList.All(r => r.IsSuccess);
            //}
        }
    }
