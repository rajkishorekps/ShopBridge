
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBridge.Entity;
using ShopBridge.Model;

namespace ShopBridge.Model.Entity
{
        class ItemEntityMap : IEntityTypeConfiguration<Item>
        {
            public void Configure(EntityTypeBuilder<Item> builder)
            {
            builder.ToTable("Item");
            builder.Property(t => t.Id).HasColumnName("Id").UseIdentityColumn();
            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Price).HasColumnName("Price");
            builder.Property(t => t.Description).HasColumnName("Description");
        }
        }
    }
