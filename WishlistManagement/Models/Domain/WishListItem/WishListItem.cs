﻿using System;

namespace WishListManagement.Models.Domain.WishListItem
{
    public class WishListItem : BaseEntity.BaseEntity

    {
        public string Title { get; private set; }
        public decimal RoughPrice { get; private set; }
        public int Priority { get; private set; }
        public WishList.WishList WishList { get; private set; }
        public long WishListId { get; private set; }

        public WishListItem(string title, decimal roughPrice, int priority, long wishListId)
        {
            Title = title;
            RoughPrice = roughPrice;
            Priority = priority;
            WishListId = wishListId;
            CreatedDateTime = DateTime.Now;
            ModifiedDateTime = DateTime.Now;
        }
        public void Update(string title, decimal roughPrice, int priority)
        {
            Title = title;
            RoughPrice = roughPrice;
            Priority = priority;
        }
        private WishListItem(){}
    }
}