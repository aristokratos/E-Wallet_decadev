using E_Wallet_App.Core.Interface;
using E_Wallet_App.Entity.Dtos;
using E_WalletApp.CORE.Interface.RepoInterface;
using Microsoft.AspNetCore.Mvc;

namespace E_Wallet_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private ITransLogic _transLogic;
        private IWalletRepository _walletRepository;

        public CurrencyController(ITransLogic transLogic, IWalletRepository walletRepository)
        {
            _transLogic = transLogic;
            _walletRepository = walletRepository;
            _transLogic = transLogic;
            
        }

        [HttpGet("CurrencyConverter")]
        public async Task<ActionResult<BalanceDto>> GetWalletBalance(string walletid, string currency)
        {
            try
            {
                var wallet = await _walletRepository.GetByWalletId(walletid);
                if (wallet == null)
                {
                    return NotFound("wallet does not exist");
                }
                var bal = await _transLogic.GetBalance(walletid, currency);
                return bal;
                // new BalanceDto 
                //{
                //    WalletId = bal.WalletId,
                //    Balance = bal.Balance
                //};
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}