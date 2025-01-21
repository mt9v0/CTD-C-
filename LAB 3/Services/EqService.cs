using Lab3.Models;
using Lab3.Repositories;

namespace Lab3.Services
{
    public class EqService : IEqService
    {
        private readonly IEqRep _eqRepository;

        public EqService(IEqRep eqRepository)
        {
            _eqRepository = eqRepository;
        }

        public async Task<bool> Clear()
        {
            return await _eqRepository.Clear();
        }

        public async Task<string> Find(int ind)
        {
            return await _eqRepository.Find(ind);
        }

        public async Task<string> Solve(Equation equation)
        {
            return await _eqRepository.Solve(equation);
        }
    }
}
