using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Domain.Entities
{
    public class Workflow
    {
        public Guid Id { get; set; }
        public string WorkflowName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public List<RuleEntity> Rules { get; set; } = new();
    }

    //public class RuleEntity
    //{
    //    public int Id { get; set; }
    //    public int WorkflowId { get; set; }
    //    public string RuleName { get; set; } = string.Empty;
    //    public string? SuccessEvent { get; set; }
    //    public string? ErrorMessage { get; set; }
    //    public string ExpressionType { get; set; } = "LambdaExpression"; // or "LogicApp"
    //    public string Expression { get; set; } = string.Empty;
    //    public int Priority { get; set; }
    //}
    public class RuleEntity
    {
        public int Id { get; set; } // This can remain an int (Primary Key for Rule)

        // CHANGE THIS: Must match Workflow.Id type
        public Guid WorkflowId { get; set; }

        public string RuleName { get; set; } = string.Empty;
        public string? SuccessEvent { get; set; }
        public string? ErrorMessage { get; set; }
        public string ExpressionType { get; set; } = "LambdaExpression";
        public string Expression { get; set; } = string.Empty;
        public int Priority { get; set; }
    }
    public class HealthcareClaim
    {
        public string ClaimId { get; set; } = Guid.NewGuid().ToString();
        public bool IsInsuranceActive { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public int Age { get; set; }
        public bool RequiresPreAuth { get; set; }
        public bool IsPreAuthApproved { get; set; }
        public decimal ClaimAmount { get; set; }
        public decimal CoverageLimit { get; set; }
        public bool IsInNetworkProvider { get; set; }
        public bool IsDuplicateClaim { get; set; }
        public bool IsEmergency { get; set; }
    }
}
