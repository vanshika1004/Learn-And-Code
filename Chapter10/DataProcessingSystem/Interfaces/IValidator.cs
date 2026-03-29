using DataProcessingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Interfaces
{
    public interface IValidator
    {
        ValidationResult Validate(Record record);
    }
}
