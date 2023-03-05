﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WishListManagement.Domain.WishListItem;

namespace WishlistManagement.Core.Mapping.WishListMapping
{
    public class WishListMapping : EntityTypeConfiguration<WishListItem>
    {
        public WishListMapping()
        {
            ToTable("WishListItems").HasKey(a => a.Id)
                .Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.WishListItemDescription).IsRequired();
            Property(a => a.Priority).IsOptional();
            Property(a => a.RoughPrice).IsOptional();
        }
    }
}