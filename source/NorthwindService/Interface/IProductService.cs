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
        IEnumerable<Product> GetAll();
    }
}
