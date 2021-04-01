using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using zajęcia_3.Models;

namespace zajęcia_3.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Display(Name = "FizzBuzz")]
        [Required(ErrorMessage = "Value has to be in range from 1 to 10000!")]
        [Range(1, 10000, ErrorMessage = "Value has to be in range from 1 to 10000!")]
        public int? input { get; set; }

        public FizzBuzzEntry? lastEntry { get; private set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            lastEntry = null;
            try
            {
                //input = HttpContext.Session.GetInt32("input");
                lastEntry = JsonConvert.DeserializeObject<FizzBuzzEntry?>(HttpContext.Session.GetString("lastEntry"));
            }
            catch (Exception e)
            {
                // Ignore
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            lastEntry = new FizzBuzzEntry(input.Value);
            HttpContext.Session.SetString("lastEntry", JsonConvert.SerializeObject(lastEntry));

            // Saving to list in this Session.
            if (lastEntry.HasValue)
            {
                string list_serialized_ = HttpContext.Session.GetString("entriesList");
                if (list_serialized_ is null)
                    list_serialized_ = JsonConvert.SerializeObject(new List<FizzBuzzEntry?>());

                var list_ = JsonConvert.DeserializeObject<List<FizzBuzzEntry?>>(
                    list_serialized_
                    );
                list_.Add(lastEntry.Value);
                HttpContext.Session.SetString("entriesList",
                    JsonConvert.SerializeObject(list_)
                    );
            }

            return Page();
        }
    }
}
