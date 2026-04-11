using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationGeoCoder.Interfaces
{
    public interface ILocationValidator
    {
        bool IsValid(string? input, out string errorMessage);
    }
}
