using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EShop.Plugins.FlashSales.FlashSalesPlans;

public class FlashSalesPlan : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }

    public virtual Guid StoreId { get; protected set; }

    public virtual DateTime BeginTime { get; set; }

    public virtual DateTime EndTime { get; set; }

    public virtual Guid ProductId { get; protected set; }

    public virtual Guid ProductSkuId { get; protected set; }

    public virtual bool IsPublished { get; protected set; }

    protected FlashSalesPlan()
    {
    }

    public FlashSalesPlan(Guid id, Guid? tenantId, Guid storeId, DateTime beginTime, DateTime endTime, Guid productId, Guid productSkuId, bool isPublished)
        : base(id)
    {
        TenantId = tenantId;
        StoreId = storeId;
        SetTimeRange(beginTime, endTime);
        SetProduct(productId, productSkuId);
        SetPublished(isPublished);
    }

    public void SetTimeRange(DateTime beginTime, DateTime endTime)
    {
        if (beginTime > endTime)
        {
            throw new EndTimeMustBeLaterThanBeginTimeException();
        }

        BeginTime = beginTime;
        EndTime = endTime;
    }

    public void SetProduct(Guid productId, Guid productSkuId)
    {
        ProductId = productId;
        ProductSkuId = productSkuId;
    }

    public void SetPublished(bool isPublished)
    {
        IsPublished = isPublished;
    }
}