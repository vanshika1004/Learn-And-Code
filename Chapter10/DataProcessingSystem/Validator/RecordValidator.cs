using DataProcessingSystem.Domain;
using DataProcessingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Validator
{
    public class RecordValidator : IValidator
    {
        public ValidationResult Validate(Record record)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(record.Id))
                result.Errors.Add("Record missing ID");

            if (string.IsNullOrWhiteSpace(record.Name))
                result.Errors.Add($"Record {record.Id} missing name");

            if (double.IsNaN(record.Value) || double.IsInfinity(record.Value))
                result.Errors.Add($"Record {record.Id} has invalid value");

            return result;
        }
    }
}
