using DataProcessingSystem.Configuration;
using DataProcessingSystem.Domain;
using DataProcessingSystem.Interfaces;
using System.Collections.Generic;

namespace DataProcessingSystem.Services
{
    public class DataProcessor
    {
        private readonly IDataReader _reader;
        private readonly IValidator _validator;
        private readonly ITransformer _transformer;
        private readonly ILogger _logger;

        public List<string> ErrorMessages { get; } = new List<string>();
        public Dictionary<string, int> Statistics { get; private set; }
        public int RecordsProcessed { get; private set; }
        public int ErrorCount { get; private set; }

        public DataProcessor(
            IDataReader reader,
            IValidator validator,
            ITransformer transformer,
            ILogger logger)
        {
            _reader = reader;
            _validator = validator;
            _transformer = transformer;
            _logger = logger;
        }

        public List<Record> Process(string input, ProcessorConfiguration config)
        {
            _logger.Log("Starting processing");

            var records = _reader.Read(input, ErrorMessages);
            var validRecords = new List<Record>();

            foreach (var record in records)
            {
                var result = _validator.Validate(record);

                if (result.IsValid)
                {
                    validRecords.Add(record);
                }
                else
                {
                    ErrorCount++;
                    ErrorMessages.AddRange(result.Errors);
                }
            }

            if (config.TransformData)
            {
                validRecords.ForEach(record =>
                    _transformer.Transform(record, config.DateFormat));
            }

            Statistics = new StatisticsService().Calculate(validRecords, ErrorCount);

            RecordsProcessed = validRecords.Count;

            _logger.Log($"Processed {RecordsProcessed} records");
            _logger.Save();

            return validRecords;
        }
    }
}