﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishListManagement.Mappers;
using WishListManagement.Models.Domain.WishList;
using WishListManagement.Models.ViewModels.WishList;
using WishListManagement.Repositories;

namespace WishListManagement.Services
{
    public class WishListService
    {
        private readonly WishListRepository _repository;

        public WishListService()
        {
            _repository = new WishListRepository();
        }

        public long Create(CreateWishListViewModel viewModel)
        {
            var wishList = new WishList(viewModel.Title, viewModel.Description, viewModel.UserId);
            return _repository.Create(wishList);
        }
        public bool Edit(ModifyWishListViewModel viewModel)
        {
            var wishList = _repository.GetById(viewModel.Id);
            wishList.Update(viewModel.Title,viewModel.Description);
            _repository.Update(wishList);
            return true;
        }
        public long Delete(long wishListId)
        {
            return _repository.Delete(wishListId);
        }
        public WishListViewModel GetById(long wishListId)
        {
            var wishList = _repository.GetById(wishListId);
            return WishListMapper.Map(wishList);
        }

        public List<WishListViewModel> GetAllByUserId(long userId)
        {
            var wishLists = _repository.GetWishListsByUserId(userId);
            return WishListMapper.Map(wishLists);
        }
    }
}