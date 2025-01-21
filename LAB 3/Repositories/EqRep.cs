
using Lab3.DB;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Repositories
{
    public class EqRep : IEqRep
    {
        private readonly Lab3Context _context;

        public EqRep(Lab3Context context)
        {
            _context = context;
        }

        public async Task<bool> Clear()
        {
            _context.EqList.RemoveRange(_context.EqList);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<string> Find(int ind)
        {
            return Task.Run(() =>
            {
                if (ind > _context.EqList.Count())
                {
                    return "";
                }
                foreach (Equation eq in _context.EqList)
                {
                    if (eq.number == ind)
                        return eq.PrintEquation();
                }
                return "";
            });
        }

        public async Task<string> Solve(Equation equation)
        {
            try
            {
                equation.number = _context.EqList.Count() + 1;
                _context.EqList.Add(equation);
                await _context.SaveChangesAsync();
                return equation.PrintEquation();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving changes: {e.Message}");
                throw;
            }
        }
    }
}
