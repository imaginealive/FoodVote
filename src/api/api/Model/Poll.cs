using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Poll
    {
        public string Id { get; set; }
        public string ShopName { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsClose { get; set; }
        public IList<Menu> Menus { get; set; }
    }
}
