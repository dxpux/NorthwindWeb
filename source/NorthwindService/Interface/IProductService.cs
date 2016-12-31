using NorthwindModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindService.Interface
{
    public interface IProductService
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
        IEnumerable<Supplier> GetAllSupplier();
        IEnumerable<Category> GetAllCategory();
    }
}
