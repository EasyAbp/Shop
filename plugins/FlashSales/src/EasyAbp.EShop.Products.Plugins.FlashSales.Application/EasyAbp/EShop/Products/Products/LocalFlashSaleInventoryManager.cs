﻿using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.EShop.Products.ProductInventories;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.EShop.Products.Products;

public class LocalFlashSaleInventoryManager : ILocalFlashSaleInventoryManager, ITransientDependency
{
    protected IProductInventoryProviderResolver ProductInventoryProviderResolver { get; }

    public LocalFlashSaleInventoryManager(IProductInventoryProviderResolver productInventoryProviderResolver)
    {
        ProductInventoryProviderResolver = productInventoryProviderResolver;
    }

    public virtual async Task<bool> TryReduceInventoryAsync(Guid? tenantId, string providerName, Guid storeId, Guid productId,
        Guid productSkuId, int quantity, bool increaseSold)
    {
        var model = new InventoryQueryModel(tenantId, storeId, productId, productSkuId);
        return await (await ProductInventoryProviderResolver.GetAsync(providerName))
            .TryReduceInventoryAsync(model, quantity, increaseSold);
    }

    public virtual async Task<bool> TryIncreaseInventoryAsync(Guid? tenantId, string providerName, Guid storeId, Guid productId,
        Guid productSkuId, int quantity, bool decreaseSold)
    {
        var model = new InventoryQueryModel(tenantId, storeId, productId, productSkuId);
        return await (await ProductInventoryProviderResolver.GetAsync(providerName))
            .TryIncreaseInventoryAsync(model, quantity, decreaseSold);
    }
}
