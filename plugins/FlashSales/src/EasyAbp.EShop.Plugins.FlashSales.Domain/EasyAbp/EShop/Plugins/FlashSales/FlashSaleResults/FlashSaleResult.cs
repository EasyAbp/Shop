﻿using System;
using EasyAbp.EShop.Stores.Stores;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EShop.Plugins.FlashSales.FlashSaleResults;

public class FlashSaleResult : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiStore
{
    public virtual Guid? TenantId { get; protected set; }

    public virtual Guid StoreId { get; protected set; }

    public virtual Guid PlanId { get; protected set; }

    public virtual FlashSaleResultStatus Status { get; protected set; }

    public virtual string Reason { get; protected set; }

    public virtual Guid UserId { get; protected set; }

    public virtual Guid? OrderId { get; protected set; }

    protected FlashSaleResult() { }

    public FlashSaleResult(Guid id, Guid? tenantId, Guid storeId, Guid planId, FlashSaleResultStatus status, string reason, Guid userId, Guid? orderId)
        : base(id)
    {
        TenantId = tenantId;
        StoreId = storeId;
        PlanId = planId;
        Status = status;
        Reason = reason;
        UserId = userId;
        OrderId = orderId;
    }

    public void MarkAsSuccessful(Guid orderId)
    {
        Status = FlashSaleResultStatus.Successful;
        OrderId = orderId;
    }

    public void MarkAsFailed(string reason)
    {
        Status = FlashSaleResultStatus.Failed;
        Reason = Check.NotNullOrEmpty(reason, nameof(reason));
    }
}