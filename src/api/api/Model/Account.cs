using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Account
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
