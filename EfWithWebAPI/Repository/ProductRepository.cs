using EfWithWebAPI.DTOs;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EfWithWebAPI.Repository
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<SelectProductWithCategory>>> GetProductListWithCategory()
        {
            var query = await _context.Products.Include(x => x.Category)
                .Select(x => new SelectProductWithCategory()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock,
                    CategoryId = x.Category.CategoryId,
                    CategoryName = x.Category.CategoryName,
                    Description = x.Category.Description
                }).ToListAsync();
            var result = Result<List<SelectProductWithCategory>>.Success(query, 200, "İşlem Başarılı.", query.Count);
            return result;

        }
        public async Task<Result<List<SelectProductWithCategory>>> GetProductListWithCategoryByCategoryName(string categoryName)
        {
            try
            {
                var query = await _context.Products.Include(x => x.Category)
                            .Select(x => new SelectProductWithCategory()
                            {
                                ProductId = x.ProductId,
                                ProductName = x.ProductName,
                                UnitPrice = x.UnitPrice,
                                UnitsInStock = x.UnitsInStock,
                                CategoryId = x.Category.CategoryId,
                                CategoryName = x.Category.CategoryName,
                                Description = x.Category.Description
                            })
                            .Where(x => x.Description.Contains(categoryName))
                            .ToListAsync();
                int sayi = 0;
                int sayi1 = 1 / sayi;
                return Result<List<SelectProductWithCategory>>.Success(query, 200, "İşlem Başarılı", query.Count);
            }
            catch (Exception e)
            {
                return Result<List<SelectProductWithCategory>>.Error(500, e.Message,true);
            }

        }
    }
}
