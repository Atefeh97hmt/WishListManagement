﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WishListManagement.Core.DbContext;
using WishListManagement.Models.Domain.WishList;
using WishListManagement.Models.ViewModels.WishList;
using WishListManagement.Services;

namespace WishListManagement.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        private readonly WishListService _service;
        private readonly UserService _userService;
        public WishListController()
        {
            _service = new WishListService();
            _userService = new UserService();
        }
        public ActionResult Index(long id)
        {
            var wishLists = _service.GetAllByUserId(id);
            return View(wishLists);
        }
        public ActionResult Details(long id)
        {
            var wishList = _service.GetById(id);
            return View(wishList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateWishListViewModel wishList)
        {
            wishList.UserId = _userService.GetUserByUsername(HttpContext.User.Identity.Name).Id;
            var createdWishListId = _service.Create(wishList);
            return RedirectToAction("Details",new { id = createdWishListId});
        }
        public ActionResult Edit(long id)
        {
            var wishList = _service.GetById(id);
            return View(wishList);
        }
        [HttpPost]
        public ActionResult Edit( ModifyWishListViewModel wishList)
        {
            _service.Edit(wishList);
            return RedirectToAction("Details",new {id =wishList.Id});
        }
        public ActionResult Delete(long id)
        {
            var userId = _service.Delete(id);
            return RedirectToAction("Index",new{ id = userId});
        }
    }
}
