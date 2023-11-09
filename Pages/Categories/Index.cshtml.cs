using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nuta_Emilia_Lab2.Data;
using Nuta_Emilia_Lab2.Models;
using Nuta_Emilia_Lab2.Models.ViewModels;

namespace Nuta_Emilia_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Nuta_Emilia_Lab2.Data.Nuta_Emilia_Lab2Context _context;

        public IndexModel(Nuta_Emilia_Lab2.Data.Nuta_Emilia_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                    .ThenInclude(c => c.Book)
                    .ThenInclude(c => c.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories
                    .Select(bc => bc.Book)
                    .ToList();
                Category = await _context.Category.ToListAsync();
            }
        }
    }
}
