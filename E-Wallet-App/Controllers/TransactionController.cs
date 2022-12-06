﻿using E_Wallet_App.Core.Core;
using E_Wallet_App.Core.Interface;
using E_Wallet_App.Domain.Dtos;
using E_Wallet_App.Domain.Models;
using E_Wallet_App.Entity.Dtos;
using E_WalletApp.CORE.Interface.RepoInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Wallet_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWalletLogic _wallet;
        private readonly IWalletRepository _walletRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransLogic _transLogic;

        public TransactionController(IUnitOfWork unitOfWork, IWalletLogic wallet, IWalletRepository walletRepository, ITransactionRepository transactionRepository, ITransLogic transLogic)
        {
            _unitOfWork = unitOfWork;
            _wallet = wallet;
            _walletRepository = walletRepository;
            _transactionRepository = transactionRepository;
            _transLogic = transLogic;
        }

        [HttpPost("Deposit")]
        public async Task<ActionResult<TransDto>> Deposite([FromForm]TransDto transDto)
        {
            try
            {
                var user = await _walletRepository.GetByWalletId(transDto.WalletId);
                if (user == null)
                {
                    return BadRequest($"{transDto.WalletId} does not already exixts");
                }
                var check = await _transLogic.Deposite(transDto);
                if (!check)
                {
                    return BadRequest("transaction unsuccessful");
                }
                return Ok("transaction completed");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Withdrawal")]
        public async Task<ActionResult<TransDto>> Withdrawal([FromForm]TransDto transDto)
        {
            try
            {
                var user = await _walletRepository.GetByWalletId(transDto.WalletId);
                if (user == null)
                {
                    return BadRequest($"{transDto.WalletId} does not already exixts");
                }
                var check = await _transLogic.Withdrawal(transDto);
                if (!check)
                {
                    return BadRequest("transaction unsuccessful");
                }
                return Ok("transaction completed");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetAllTransactions")]
        public async Task<ActionResult> GetTransactions()
        {
            try
            {
                var alltransactions = _unitOfWork.Transaction.GetAll();
                if(alltransactions == null)
                {
                    return NotFound("no transactions yet ");
                }
                return Ok(alltransactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetTransactionByWalletId")]
        public async Task<ActionResult> GetTransByWalletId(string walletId)
        {
            try
            {
                var transwithId = await _walletRepository.GetByWalletId(walletId);
                if (transwithId == null) ;
                {
                    return NotFound("wallet nnot found");
                }
                var trans = await _unitOfWork.Transaction.FindByCondition(x => x.WalletId == transwithId.WalletId);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[AllowAnonymous]
        //[Route("Conversion")]
        //[HttpGet]
       
        //public async Task<string> GetExchangeRate([FromForm]string from, string to)
        //{
        //    //Examples:
        //    //from = "EUR"
        //    //to = "USD"
        //    using (var client = new HttpClient())
        //    {
        //        try
        //        {
        //            client.BaseAddress = new Uri("https://open.er-api.com/v6/latest/USD");
        //            var response = await client.GetAsync($"/api/v6/convert?q={from}_{to}&compact=y");
        //            var stringResult = await response.Content.ReadAsStringAsync();
        //            var dictResult = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(stringResult);
        //            return dictResult[$"{from}_{to}"]["val"];
        //        }
        //        catch (HttpRequestException httpRequestException)
        //        {
        //            response.EnsureSuccessStatusCode((httpRequestException.StackTrace));
        //            return BadRequest("Error calling API. Please do manual lookup.");
        //        }
        //    }
       // }
    }
}
