using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixCollege.Data;
using HendrixCollege.Models;
using Microsoft.Extensions.Options;

namespace HendrixCollege.Pages.Students
{
    //public class IndexModel : PageModel
    //{
    //    private readonly HendrixCollege.Data.SchoolContext _context;

    //    public IndexModel(HendrixCollege.Data.SchoolContext context)
    //    {
    //        _context = context;
    //    }

    //    public IList<Student> Student { get;set; }

    //    public async Task OnGetAsync()
    //    {
    //        Student = await _context.Students.ToListAsync();
    //    }
    //}

    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;
        private readonly MvcOptions _mvcOptions;

        public IndexModel(SchoolContext context, IOptions<MvcOptions> mvcOptions)
        {
            _context = context;
            _mvcOptions = mvcOptions.Value;
        }

        public IList<Student> Student { get; set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Students.Take(
                _mvcOptions.MaxModelBindingCollectionSize).ToListAsync();
        }
    }
}
