using E_Wallet_App.Core.Interface;
using E_Wallet_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet_App.Core.Core
{
    public class WalletLogic: IWalletLogic
    {
        private IWalletService _wallet;
        private readonly ILoggerManager _logger;

        public WalletLogic(IWalletService wallet, ILoggerManager logger) 
        {
            _wallet = wallet;
            _logger = logger;
        }
        public async Task<Wallet> CreateWallet()
        {
            try
            {


                var wallet = new Wallet();
                wallet.WalletId = await _wallet.GenerateWallet();
                wallet.Date = DateTime.Now;
                wallet.Balance = 0;
                return wallet;
            }
            catch (Exception ex)
            {
                _logger.Debug($"{ex.Message}");
                _logger.Debug($"{ex.StackTrace}");
                _logger.Error($"{ex.InnerException}");
                _logger.Info($"{ex.GetBaseException}");
                _logger.Warn($"{ex.GetObjectData}");
                _logger.Fatal($"{ex.GetHashCode}");
            }
            return null;
        }
    }
}
