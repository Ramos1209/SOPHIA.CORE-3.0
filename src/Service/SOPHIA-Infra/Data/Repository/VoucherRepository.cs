using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SOPHIA_Core.Data;
using SOPHIA_Domain.Vouchers;

namespace SOPHIA_Infra.Data.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidoContext _context;

        public VoucherRepository(PedidoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public void Atualizar(Voucher voucher)
        {
            _context.Vouchers.Update(voucher);

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
