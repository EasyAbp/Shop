using System;
using EasyAbp.EShop.Plugins.ProductTag.Tags;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.EShop.Plugins.ProductTag.EntityFrameworkCore
{
    public static class ProductTagDbContextModelCreatingExtensions
    {
        public static void ConfigureProductTag(
            this ModelBuilder builder,
            Action<ProductTagModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ProductTagModelBuilderConfigurationOptions(
                ProductTagDbProperties.DbTablePrefix,
                ProductTagDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */



            builder.Entity<Tag>(b =>
            {
                b.ToTable(options.TablePrefix + "Tags", options.Schema);
                b.ConfigureByConvention();
                /* Configure more properties here */

                b.HasIndex(x => x.StoreId);
            });

            builder.Entity<ProductTags.ProductTag>(b =>
            {
                b.ToTable(options.TablePrefix + "ProductTags", options.Schema);
                b.ConfigureByConvention();
                /* Configure more properties here */

                b.HasIndex(x => x.TagId);
                b.HasIndex(x => x.ProductId);
            });
        }
    }
}