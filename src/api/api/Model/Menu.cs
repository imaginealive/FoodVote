using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Menu
    {
        public string Id { get; set; }
        public string MenuName { get; set; }
        public bool IsDefault { get; set; }
        public IList<string> Voter { get; set; }
    }
}
