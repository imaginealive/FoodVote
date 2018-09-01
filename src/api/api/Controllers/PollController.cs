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
    public class PollController : ControllerBase
    {
        private readonly IPollDac pollDac;
        private readonly IAccountDac accDac;

        public PollController(IPollDac pollDac, IAccountDac accDac)
        {
            this.pollDac = pollDac;
            this.accDac = accDac;
        }

        [HttpGet]
        public ActionResult<PollInfo> GetNewestPoll()
        {
            var poll = pollDac.Get(it => it.IsClose == false);
            var pollinfo = new PollInfo
            {
                Id = poll.Id,
                ShopName = poll.ShopName,
                CreateAt = poll.CreateAt,
                CreateBy = poll.CreateBy,
                IsClose = poll.IsClose,
                Menus = poll.Menus,
                Unvoter = new List<string>()
            };
            var accounts = accDac.List(it => true);

            pollinfo.Menus.ToList().ForEach((menu) =>
            {
                if (menu.Voter != null || menu.Voter.Count != 0)
                    menu.Voter.ToList().ForEach((voter) =>
                    {
                        accounts = accounts.Where(acc => acc.Username != voter);
                    });
            });

            foreach (var acc in accounts)
            {
                pollinfo.Unvoter.Add(acc.Username);
            }
            return pollinfo;
        }

        [HttpPost]
        public ActionResult<string> CreatePoll([FromBody] PollRequest request)
        {
            var poll = pollDac.Get(it => it.IsClose == false);
            if (poll == null)
            {
                var newPoll = new Poll
                {
                    Id = Guid.NewGuid().ToString(),
                    ShopName = request.ShopName,
                    CreateBy = request.CreateBy,
                    CreateAt = DateTime.Now,
                    IsClose = false,
                    Menus = new List<Menu>
                    {
                        new Menu
                        {
                            Id = Guid.NewGuid().ToString(),
                            IsDefault = true,
                            MenuName = request.MenuName,
                            Voter = new List<string>()
                        }
                    }
                };

                pollDac.Create(newPoll);
                return "complete";
            }
            return "fail";
        }

        [HttpGet("menu")]
        public ActionResult UpdatePoll(string menu)
        {
            var poll = pollDac.Get(it => it.IsClose == false);
            if (poll != null)
            {
                poll.Menus.Add(new Menu
                {
                    Id = Guid.NewGuid().ToString(),
                    IsDefault = false,
                    MenuName = menu,
                    Voter = new List<string>()
                });

                pollDac.Update(poll);
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Vote([FromBody] VoteRequest vote)
        {
            var poll = pollDac.Get(it => it.IsClose == false);
            if (poll != null)
            {
                poll.Menus.FirstOrDefault(it => it.Id == vote.FoodId).Voter.Add(vote.Username);

                pollDac.Update(poll);
            }
            return Ok();
        }

        [HttpGet("{username}")]
        public ActionResult Close(string username)
        {
            var poll = (PollInfo)pollDac.Get(it => it.IsClose == false);
            if (poll != null)
            {
                poll.IsClose = poll.CreateBy == username ? true : false;

                pollDac.Update(poll);

                if (!poll.IsClose) return Ok();

                //var accounts = accDac.List(it => true);

                //poll.Menus.ToList().ForEach((menu) =>
                //{
                //    if (menu.Voter != null || menu.Voter.Count != 0)
                //        menu.Voter.ToList().ForEach((voter) =>
                //        {
                //            accounts = accounts.Where(acc => acc.Username != voter);
                //        });
                //});

                //foreach (var acc in accounts)
                //{
                //    poll.Unvoter.Add(acc.Username);
                //}

                //pollDac.Update(poll);
            }

            return Ok();
        }

        //[HttpGet]
        //public ActionResult<Poll> GetReustPoll()
        //{
        //    return (PollInfo)pollDac.Get(it => it.IsClose == true);
        //}
    }
}