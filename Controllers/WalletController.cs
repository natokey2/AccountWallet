using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WalletAPI.Data;
using WalletAPI.Models;

namespace WalletAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WalletController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult>GetWallets()
        {
             var wallets= await _context.Wallets.ToListAsync();
             return Ok(wallets);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetWallets(int id )
        {
            var wallets= await _context.Wallets.FindAsync(id);

            if (wallets==null)
            {
                return NotFound();
            }
            return Ok(wallets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWallets(Wallet wallet)
        {
           _context.Wallets.Add(wallet);
           await _context.SaveChangesAsync();
           return CreatedAtAction("GetWallets",new {id= wallet.Id},wallet);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteWallets(int id )
        {
            var wallets= await _context.Wallets.FindAsync(id);
            if (wallets== null)
            {
                return NotFound();

            }
            _context.Wallets.Remove(wallets);
            await _context.SaveChangesAsync();
            return Ok(wallets);
        }
    }
}