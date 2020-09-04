using System.Threading.Tasks;

namespace NAoCHelper
{
    public interface IPuzzle
    {
        Task<string> GetInputAsync();
    }
}