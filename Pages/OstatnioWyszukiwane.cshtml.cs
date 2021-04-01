using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using zajêcia_3.Models;

namespace zajêcia_3.Pages
{
    public class OstatnioWyszukiwaneModel : PageModel
    {
        public string entriesList_string;

        public void OnGet()
        {
            string list_serialized_ = HttpContext.Session.GetString("entriesList");
            if (list_serialized_ is null)
            {
                entriesList_string = "Empty...";
                return;
            }
            entriesList_string = string.Join("\n",
                JsonConvert.DeserializeObject<List<FizzBuzzEntry?>>(
                    list_serialized_
                    )
                );
        }
    }
}
