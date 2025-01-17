﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WishListManagement.Core.DbContext;
using WishListManagement.Models.Domain.WishList;
using WishListManagement.Models.Domain.WishListItem;

namespace WishListManagement.Repositories
{
    public class WishListRepository
    {
        private readonly WishListManagementDbContext db;
        public WishListRepository()
        {
            db = new WishListManagementDbContext();
        }
        public long Create(WishList wishList)
        {
            db.WishLists.Add(wishList);
            db.SaveChanges();
            return wishList.Id;
        }

        public long Delete(long id)
        {
            var entity = GetSummaryById(id);
            db.WishLists.Remove(entity);
            db.SaveChanges();

            return entity.UserId;
        }

        public bool Update(WishList wishList)
        {
            db.Entry(wishList).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public WishList GetById(long id)
        {
            return db.WishLists
                .Include(a => a.User)
                .Include(a => a.WishListItems)
                .SingleOrDefault(a => a.Id == id);
        }
        public WishList GetSummaryById(long id)
        {
            return db.WishLists
                .SingleOrDefault(a => a.Id == id);
        }

        public List<WishList> GetWishListsByUserId(long userId)
        {
            return db.WishLists.Where(a => a.UserId == userId).ToList();
        }
    }
}