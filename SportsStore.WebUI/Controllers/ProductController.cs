using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
       
        private IProductRepository repository;
        int pageSize = 1;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        
        // GET: /Product/
        public ActionResult List(string category, int page=1)
        {
            
            IEnumerable<Product> prods = repository.Products
                .Where(x => category == null || x.Category == category);
            IEnumerable<Product> prod = prods
                .OrderBy(k => k.ProductID).Skip((page - 1) * pageSize).Take(pageSize);
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = prod,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = prods.Count()
                },
                CurrentCategory=category
            };
            
            return View(model);
        }
	}
}