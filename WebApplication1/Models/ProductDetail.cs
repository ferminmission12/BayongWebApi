using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BayongWebAppApi.Models
{
    public class ProductDetail
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string SKU { get; set; }

        [Column(TypeName = "nvarchar(100)")]

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Image { get; set; }

        [Required]
        [ForeignKey("CategoryDetails")]
        public int CategoryId { get; set; }
        public CategoryDetail CategoryDetails { get; set; }

        [Required]
        public float Quantity { get; set; }

    }
}
