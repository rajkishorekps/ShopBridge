﻿using System;
using System.Collections.Generic;

namespace ShopBridge.Entity
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
