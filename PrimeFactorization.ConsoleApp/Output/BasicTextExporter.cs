using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PrimeFactorization.ConsoleApp.Output.Interfaces;

namespace PrimeFactorization.ConsoleApp.Output
{
    public class BasicTextExporter : IFileExporter
    {
        private readonly IEnumerable<IFileOutputLinesFormatter> _formatters;

        public BasicTextExporter(IEnumerable<IFileOutputLinesFormatter> formatters)
        {
            _formatters = formatters;
        }


        public async Task AppendLinesAsync(IReadOnlyCollection<FactorizationResult> results, string fileBasePath)
        {
            foreach (var f in _formatters)
            {
                var lines = results.Select(f.Format);
                string filePath = GetFilePath(fileBasePath, f.FormatSuffix);

                await File.AppendAllLinesAsync(filePath, lines);
            }
        }

        public void InitFiles(string fileBasePath)
        {
            foreach (var f in _formatters)
            {
                string filePath = GetFilePath(fileBasePath, f.FormatSuffix);

                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath)) { }
                }
                else
                {
                    File.WriteAllText(filePath, string.Empty);
                }
            }
        }

        public void CleanupAbort(string fileBasePath)
        {
            foreach (var f in _formatters)
            {
                string filePath = GetFilePath(fileBasePath, f.FormatSuffix);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }


        private static string GetFilePath(string fileBasePath, string formatterSuffix)
        {
            return $"{fileBasePath}{formatterSuffix}.txt";
        }
    }
}
