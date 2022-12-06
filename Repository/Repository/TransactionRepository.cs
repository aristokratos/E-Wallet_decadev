using E_Wallet_App.Domain.Models;
using E_Wallet_App.Entity.Dtos;
using E_WalletApp.CORE.Interface.RepoInterface;
using E_WalletApp.DB.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = E_Wallet_App.Domain.Models.Transaction;

namespace E_WalletRepository.Repository
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        //public async Task<Transaction> GetByTransaction(string transType)
        //{
        //    var user = _applicationContext.transactions.Where(x => x.TransactionType == transType).Select();
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    return user;
        //}
    }
    //public async Task<TransDto> GetWalletDetails(string Currency, Guid walletAddress)
    //{
    //    var walletDetails = new _context.Wallets.FirstOrDefaultAsync(x => x.WalletAdress,
    //        WalletBalance = $"{Currency.ToUpper()} {Math.Round(walletAddress.WalletBalance * await getApi(Currency), 3)}");
    //}
    //return walletUserView;
       
}
