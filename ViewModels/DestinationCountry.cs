using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBlog.ViewModels
{
    public class DestinationCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountryName { get; set; }

        [DataType(DataType.Url)]
        public string Image { get; set; }
    }
}