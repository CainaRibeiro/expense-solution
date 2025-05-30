﻿using ExpenseSolution.Domain.Refunds;
using Microsoft.EntityFrameworkCore;

namespace ExpenseSolution.Repositories.Refund
{
    public class RefundRepository(AppDbContext context): GenericRepository<RefundDomain>(context), IRefundRepository
    {
        private readonly AppDbContext _refundContext = context;

        public async Task<List<RefundDomain>> GetApprovedByPeriod(DateTime startAt, DateTime endAt)
        {
            return await _refundContext
                    .Refunds
                    .Include(r => r.Expense)
                    .Where(r => r.Status == RefundStatusEnum.APPROVED && (r.RequestDate >= startAt && r.RequestDate <= endAt))
                    .ToListAsync();
        }

        public async Task<RefundDomain> GetByExpenseId(int ExpenseId)
        {
            var refund = await _refundContext.Refunds.FirstOrDefaultAsync(r => r.ExpenseId == ExpenseId);
            if (refund == null)
            {
                throw new Exception("Refund not found");
            }
            return refund;
        }

        public async Task<bool> UpdateStatus(int id, RefundStatusEnum status)
        {
            var refund = await _refundContext
                    .Refunds
                    .FirstOrDefaultAsync(r => r.Id == id);
            if (refund == null)
            {
                return false;
            }
            refund.Status = status;
            await _refundContext.SaveChangesAsync();
            return true;
        }
    }
}
