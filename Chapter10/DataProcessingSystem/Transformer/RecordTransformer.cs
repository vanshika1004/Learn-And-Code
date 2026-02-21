using DataProcessingSystem.Domain;
using DataProcessingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Transformer
{
    public class RecordTransformer : ITransformer
    {
        public void Transform(Record record, string format)
        {
            record.Name = record.Name.ToUpper();

            if (record.Date.HasValue)
                record.Date = DateTime.Parse(record.Date.Value.ToString(format));
        }
    }
}
