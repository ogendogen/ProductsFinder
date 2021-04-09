using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ProductsManager
    {
        public ProductContext ProductContext { get; set; }
        public ProductsManager()
        {

        }

        public async Task<Product> GetProductByNumber(int number)
        {
            return await ProductContext.Products.FirstOrDefaultAsync(product => product.ProductNumber == number);
        }

        public async Task<IEnumerable<Product>> GetProductsByAddon(string addonContent, int addonNumber)
        {
            switch (addonNumber)
            {
                case 1:
                    return await ProductContext.Products.Where(product => product.Addon1.Contains(addonContent)).ToListAsync();

                case 2:
                    return await ProductContext.Products.Where(product => product.Addon2.Contains(addonContent)).ToListAsync();

                case 3:
                    return await ProductContext.Products.Where(product => product.Addon3.Contains(addonContent)).ToListAsync();

                case 4:
                    return await ProductContext.Products.Where(product => product.Addon4.Contains(addonContent)).ToListAsync();

                default:
                    return new List<Product>();
            }
        }
    }
}
