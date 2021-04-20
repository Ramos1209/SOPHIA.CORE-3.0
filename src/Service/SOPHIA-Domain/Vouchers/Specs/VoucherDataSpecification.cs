using System;
using System.Linq.Expressions;
using NetDevPack.Specification;

namespace SOPHIA_Domain.Vouchers.Specs
{
    public class VoucherDataSpecification : Specification<Vouchers.Voucher>
    {
        public override Expression<Func<Vouchers.Voucher, bool>> ToExpression()
        {
            return voucher => voucher.DataValidade >= DateTime.Now;
        }
    }

    public class VoucherQuantidadeSpecification : Specification<Vouchers.Voucher>
    {
        public override Expression<Func<Vouchers.Voucher, bool>> ToExpression()
        {
            return voucher => voucher.Quantidade > 0;
        }
    }

    public class VoucherAtivoSpecification : Specification<Vouchers.Voucher>
    {
        public override Expression<Func<Vouchers.Voucher, bool>> ToExpression()
        {
            return voucher => voucher.Ativo && !voucher.Utilizado;
        }
    }
}
