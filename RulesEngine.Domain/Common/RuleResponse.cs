using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Domain.Common
{
    public record RuleResponse(bool IsSuccess, string Message, string Status);
}
