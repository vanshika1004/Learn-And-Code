using CreatorMonetization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorMonetization.Interfaces
{
    public interface IEarningStrategy
    {
        string EarningType { get; }


        double Calculate(EarningContext context);
    }
}
