using Lab3.Models;

namespace Lab3.Services
{
    public interface IEqService
    {
        Task<string> Solve(Equation equation);
        Task<string> Find(int ind);
        Task<bool> Clear();
    }
}
