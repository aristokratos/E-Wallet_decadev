using E_Wallet_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet_App.Entity.Dtos
{
    public class TransactionDTO
    {
        public Guid TransactionId { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(nameof(Wallet))]
        public string WalletId { get; set; }
    }
}