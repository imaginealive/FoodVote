using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dac.Contract;
using api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDac accDac;

        public AccountController(IAccountDac accDac)
        {
            this.accDac = accDac;
        }

        [HttpGet("{username}")]
        public ActionResult<Account> GetAccount(string username)
        {
             var acc = accDac.Get(it => it.Username == username);

            if (acc == null)
            {
                acc = new Account { Id = Guid.NewGuid().ToString(), Username = username, CreateAt = DateTime.Now };
                accDac.Create(acc);
            }

            return acc;
        }
    }
}