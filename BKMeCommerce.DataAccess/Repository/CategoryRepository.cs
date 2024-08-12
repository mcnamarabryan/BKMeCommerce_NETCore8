using BKMeCommerce.DataAccess.Data;
using BKMeCommerce.DataAccess.Repository.IRepository;
using BKMeCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKMeCommerce.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        void ICategoryRepository.Update(Category category)
        {
            _context.Categories.Update(category);

        }
    }
}
