﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Models
{
    public class GlobalState
    {
        public User CurrentUser { get; set; }
        public string AppBarTitle { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
