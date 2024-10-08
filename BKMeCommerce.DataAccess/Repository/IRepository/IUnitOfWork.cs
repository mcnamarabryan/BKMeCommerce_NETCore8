﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKMeCommerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {

        IApplicationUserRepository ApplicationUser { get; }
        ICategoryRepository Category { get; }
        ICompanyRepository Company { get; }
        IProductRepository Product { get; }
        IShoppingCartRepository ShoppingCart { get; }

        void Save();
    }
}
