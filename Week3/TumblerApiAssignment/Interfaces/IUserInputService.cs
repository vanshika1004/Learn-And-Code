using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblerApiAssignment.Models;

namespace TumblerApiAssignment.Interfaces
{
    public interface IUserInputService
    {
        UserInput ReadInput();
    }
}
