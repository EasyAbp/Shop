using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EShop.Plugins.ProductTag.ProductTags
{
    public class ProductTag : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid StoreId { get; set; }

        public virtual Guid TagId { get; protected set; }

        public virtual Guid ProductId { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        protected ProductTag()
        {
        }

        public ProductTag(
            Guid id,
            Guid? tenantId,
            Guid tagId,
            Guid productId,
            int displayOrder = 0
        ) : base(id)
        {
            TenantId = tenantId;
            TagId = tagId;
            ProductId = productId;
            DisplayOrder = displayOrder;
        }
    }
}
