using Magazine.Data;
using Magazine.MOdel.CategoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Service
{
    
    public class CategoryServices
    {
        private readonly Guid _UserId;
        public CategoryServices(Guid userid)
        {
            _UserId = userid;
        }
        //Create a new Category
        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category() { CategoryName = model.CategoryName,OwnerId=_UserId };
            using(var ctx= new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        //GET All Categories
        public IEnumerable<CategoryListItem> GetAllCategory()
        {
            using (var ctx=new ApplicationDbContext())
            {
                var categories = ctx
                                    .Categories
                                    
                                    .Select(e => new CategoryListItem
                                    {
                                        CategoryId = e.CategoryId,
                                        CategoryName = e.CategoryName
                                    });
                return categories.ToList();
            }
        }

        //Edit Cartegory
        public bool UpdateCategory(int CategoryId, CategoryCreate model)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var category = ctx
                                 .Categories
                                 .Single(e => e.OwnerId == _UserId);
                category.CategoryName = model.CategoryName;
                return ctx.SaveChanges() == 1;
            }
        }
        //DeleteCategory
        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var category = ctx
                                 .Categories
                                .Single(e => e.OwnerId == _UserId);
                ctx.Categories.Remove(category);
                return ctx.SaveChanges() == 1;
            }
        }

        //GetCategory BY Id
        public CategoryListItem GetCagtegoryById(int categoryId)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var category = ctx
                                 .Categories
                                 .Find(categoryId);
                return new CategoryListItem ()
                { CategoryName = category.CategoryName ,CategoryId=category.CategoryId};
                                 
                
            }
        }
    }
}
