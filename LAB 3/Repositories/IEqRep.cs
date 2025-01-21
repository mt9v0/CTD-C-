using Lab3.Models;

namespace Lab3.Repositories
{
    public interface IEqRep
    {
        Task<string> Solve(Equation equation);
        Task<string> Find(int ind);
        Task<bool> Clear();
    }
}
