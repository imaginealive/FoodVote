﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class VoteRequest
    {
        public string Username { get; set; }
        public string FoodId { get; set; }
    }
}
