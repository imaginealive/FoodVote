using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class PollRequest
    {
        public string ShopName { get; set; }
        public string MenuName { get; set; }
        public string CreateBy { get; set; }
    }
}
