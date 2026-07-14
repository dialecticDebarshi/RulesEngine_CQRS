using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Contract
{
    public interface IRulePlugin
    {
        string PluginName { get; }
       // Task<RuleResult> ExecuteAsync(PatientContext context);
    }
}
