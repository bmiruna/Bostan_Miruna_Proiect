using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bostan_Miruna_Proiect.Data;


namespace Bostan_Miruna_Proiect.Models
{
    public class ProductCategoriesPageModel:PageModel
    {
        public List<SelectedCategory> SelectedCategoriesList;

        public void PopulateSelectedCategoriesList(Bostan_Miruna_ProiectContext context, Product product)
        {
            var allCategories = context.Category;
            var productCategories = new HashSet<int>(
                    product.ProductCategories.Select(c => c.ProductID));

            SelectedCategoriesList = new List<SelectedCategory>();

            foreach(var category in allCategories)
            {
                SelectedCategoriesList.Add(new SelectedCategory
                {
                    CategoryID = category.ID,
                    Name = category.CategoryName,
                    Selected = productCategories.Contains(category.ID)
                });  
            }
        }

        public void UpdatePrductCategories(Bostan_Miruna_ProiectContext context, string[] selectedCategories, Product product)
        {
            if(selectedCategories == null)
            {
                product.ProductCategories = new List<ProductCategory>();
                return;
            }

            var selectedCategoriesSet = new HashSet<string>(selectedCategories);
            var productCategories = new HashSet<int>(
                    product.ProductCategories.Select(c=>c.Category.ID));

            foreach(var category in context.Category)
            {
                if (selectedCategoriesSet.Contains(category.ID.ToString()))
                {
                    if (!productCategories.Contains(category.ID))
                    {
                        product.ProductCategories.Add(
                                new ProductCategory
                                {
                                    ProductID = product.ID,
                                    CategoryID = category.ID
                                }
                            );
                    }
                }
                else
                {
                    if (productCategories.Contains(category.ID))
                    {
                        ProductCategory toRemove = product.ProductCategories.SingleOrDefault(i => i.CategoryID == category.ID);
                        context.Remove(toRemove);
                    }
                }
            }
        }
    }
}
