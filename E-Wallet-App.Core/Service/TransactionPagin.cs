using E_Wallet_App.Entity.Dtos;
using E_Wallet_App.Entity.Helper;
using E_Wallet_App.Core.Interface.RepoInterface;
using E_WalletApp.DB.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Wallet_App.Core.Service
{
    public class TransactionPagin : ITransactPagin
    {
        private readonly ApplicationContext _applicationContext;

        public TransactionPagin(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<PageList<TransactionDTO>> GetAllTransactions(PaginationParameter pagin)
        {

            var page = await _applicationContext.transactions.Select(x =>
            new TransactionDTO
            {
                TransactionId = x.TransactionId,
                TransactionType = x.TransactionType,
                Description = x.Description,
                Amount = x.Amount,
                CurrentBalance = x.CurrentBalance,
                Date = x.Date,
                WalletId = x.WalletId
            }).ToListAsync();
            return PageList<TransactionDTO>.ToPageList(page, pagin.PageNumber, pagin.PageSize);
        }
    }

    public interface ITransactPagin
    {
    }
}