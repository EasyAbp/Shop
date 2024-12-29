using System;
using System.Collections.Generic;
using EasyAbp.Abp.Trees;
using EasyAbp.EShop.Stores.Stores;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EShop.Plugins.ProductTag.Tags
{
    public class Tag : FullAuditedAggregateRoot<Guid>, ITree<Tag>, IMultiTenant, IMultiStore
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid StoreId { get; protected set; }

        [CanBeNull]
        public virtual string Description { get; protected set; }

        [CanBeNull]
        public virtual string MediaResources { get; protected set; }

        public virtual bool IsHidden { get; protected set; }

        #region Properties of ITree

        [NotNull]
        public virtual string DisplayName { get; set; }

        [NotNull]
        public virtual string Code { get; set; }

        public virtual int Level { get; set; }

        public virtual Guid? ParentId { get; set; }

        public virtual Tag Parent { get; set; }

        public virtual ICollection<Tag> Children { get; set; }

        #endregion

        protected Tag()
        {
        }

        public Tag(
            Guid id,
            Guid? tenantId,
            Guid storeId,
            Guid? parentId,
            string displayName,
            string description,
            string mediaResources,
            bool isHidden
        ) : base(id)
        {
            TenantId = tenantId;
            StoreId = storeId;
            ParentId = parentId;
            DisplayName = displayName;
            Description = description;
            MediaResources = mediaResources;
            IsHidden = isHidden;
        }
    }
}
