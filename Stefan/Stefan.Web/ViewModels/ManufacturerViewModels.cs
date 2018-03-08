using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Stefan.Web.ViewModels
{
    public class ManufacturerCreateViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string LogoPath { get; set; }

        [MaxLength(512)]
        public string Comment { get; set; }

        [Display(Name = "View order")]
        public int? ViewOrder { get; set; }
    }

    public class ManufacturerEditViewModel : ManufacturerCreateViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }

    public class ManufacturerDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Create date")]
        public DateTime CreateDate { get; set; }

        public string Name { get; set; }

        public string LogoPath { get; set; }

        public string Comment { get; set; }

        [Display(Name = "View order")]
        public int? ViewOrder { get; set; }
    }

    public class ManufacturerIndexViewModel
    {
        public List<ManufacturerDetailsViewModel> Manufacturers { get; set; }
    }
}
