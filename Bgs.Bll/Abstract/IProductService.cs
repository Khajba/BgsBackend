using Bgs.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface IProductService
    {
        public IEnumerable<ProductType> GetProductTypes();
    }
}
