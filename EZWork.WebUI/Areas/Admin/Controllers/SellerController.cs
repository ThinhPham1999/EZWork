using EZWork.Core.Abstract;
using EZWork.Core.Entities;
using EZWork.WebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Areas.Admin.Controllers
{
    public class SellerController : Controller
    {
        private IEZSellerRepository repository;
        public int PageSize = 10;

        public SellerController(IEZSellerRepository ezsellerRepository)
        {
            this.repository = ezsellerRepository;
        }
        public ViewResult ListSeller( int page = 1)
        {
            SellerListViewModel model = new SellerListViewModel
            {
                Sellers = repository.Sellers
                .Where(s => s.Status == 1)
                .OrderBy(s=>s.SellerId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Sellers.Count()
                },
                CurrentCategory = 1
            };
            return View(model);
        }

        public ViewResult ListUser( int page = 1)
        {
            SellerListViewModel model = new SellerListViewModel
            {
                EZUsers = repository.EZUsers
                .Where(p => p.Status == 0)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Sellers.Count()
                },
                CurrentCategory = 1
            };
            return View(model);
        }

        public ViewResult ListCandidate(int category, int page = 1)
        {
            SellerListViewModel model = new SellerListViewModel
            {
                Sellers = repository.Sellers
                .Where(p => p.Status == category)
                .OrderBy(p => p.SellerId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Sellers.Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public ViewResult Details(string Id)
        {
            EZUser users = repository.EZUsers
            .FirstOrDefault(p => p.Id == Id);
            return View(users);
        }
    }
}