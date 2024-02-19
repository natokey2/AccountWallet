using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAPI.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public string? Holder { get; set; }

        public decimal Balance { get; set; }
    }
}