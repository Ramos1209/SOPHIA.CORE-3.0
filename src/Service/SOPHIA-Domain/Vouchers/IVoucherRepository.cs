using System.Threading.Tasks;
using SOPHIA_Core.Data;

namespace SOPHIA_Domain.Vouchers
{
    public  interface IVoucherRepository: IRepository<Vouchers.Voucher>
    {
        Task<Vouchers.Voucher> ObterVoucherPorCodigo(string codigo);
        void Atualizar(Vouchers.Voucher voucher);
    }
}
