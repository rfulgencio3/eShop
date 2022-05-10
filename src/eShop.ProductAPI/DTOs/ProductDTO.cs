﻿using eShop.ProductAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace eShop.ProductAPI.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; private set; }
        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; private set; }
        [Required(ErrorMessage = "The Price is required")]
        public decimal Price { get; private set; }
        [Required(ErrorMessage = "The Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Description { get; private set; }
        [Required(ErrorMessage = "The Stock is required")]
        [Range(1,9999)]
        public long Stock { get; private set; }
        public string? ImageUrl { get; private set; }

        public Category? Category { get; private set; }
        public int CategoryId { get; private set; }
    }
}
