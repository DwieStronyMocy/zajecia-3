using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace zajęcia_3.Pages
{
    public class AddressModel : PageModel
    {
        public Models.Address Address {get; set;}
        public void OnGet()
        {
            var SessionAddress =
            HttpContext.Session.GetString("SessionAddress");
            if (SessionAddress != null)
                Address = JsonConvert.DeserializeObject<Models.Address>(SessionAddress);
        }
    }
}
