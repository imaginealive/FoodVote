using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class PollInfo : Poll
    {
        public IList<string> Unvoter { get; set; }
    }
}
