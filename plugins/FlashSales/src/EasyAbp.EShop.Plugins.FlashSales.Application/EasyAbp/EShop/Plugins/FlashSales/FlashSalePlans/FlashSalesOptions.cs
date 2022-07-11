﻿using System;

namespace EasyAbp.EShop.Plugins.FlashSales.FlashSalePlans;

public class FlashSalesOptions
{
    /// <summary>
    /// Default: 3 minutes
    /// </summary>
    public TimeSpan PreOrderExpirationTime { get; set; } = TimeSpan.FromMinutes(3);
}