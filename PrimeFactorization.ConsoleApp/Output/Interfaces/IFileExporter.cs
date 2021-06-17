using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeFactorization.ConsoleApp.Output.Interfaces
{
    public interface IFileExporter
    {
        Task AppendLinesAsync(IReadOnlyCollection<FactorizationResult> results, string fileBasePath);

        void InitFiles(string fileBasePath);

        void CleanupAbort(string fileBasePath);

    }
}
