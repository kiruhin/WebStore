using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryProductService : IProductService
    {
        private readonly List<Category> _categories;
        private readonly List<Brand> _brands;

        public InMemoryProductService()
        {
            _categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Sportswear 2",
                    Order = 0,
                    ParentId = null
                },
                new Category()
                {
                    Id = 2,
                    Name = "Nike",
                    Order = 0,
                    ParentId = 1
                },
                new Category()
                {
                    Id = 3,
                    Name = "Under Armour",
                    Order = 1,
                    ParentId = 1
                },
                new Category()
                {
                    Id = 4,
                    Name = "Adidas",
                    Order = 2,
                    ParentId = 1
                },
                new Category()
                {
                    Id = 5,
                    Name = "Puma",
                    Order = 3,
                    ParentId = 1
                },
                new Category()
                {
                    Id = 6,
                    Name = "ASICS",
                    Order = 4,
                    ParentId = 1
                },
                new Category()
                {
                    Id = 7,
                    Name = "Mens",
                    Order = 1,
                    ParentId = null
                },
                new Category()
                {
                    Id = 8,
                    Name = "Fendi",
                    Order = 0,
                    ParentId = 7
                },
                new Category()
                {
                    Id = 9,
                    Name = "Guess",
                    Order = 1,
                    ParentId = 7
                },
                new Category()
                {
                    Id = 10,
                    Name = "Valentino",
                    Order = 2,
                    ParentId = 7
                },
                new Category()
                {
                    Id = 11,
                    Name = "Dior",
                    Order = 3,
                    ParentId = 7
                },
                new Category()
                {
                    Id = 12,
                    Name = "Versace",
                    Order = 4,
                    ParentId = 7
                },
                new Category()
                {
                    Id = 13,
                    Name = "Armani",
                    Order = 5,
                    ParentId = 7
                },
                new Category()
                {
                    Id = 14,
                    Name = "Prada",
                    Order = 6,
                    ParentId = 7
                },
                new Category()
                {
                    Id = 15,
                    Name = "Dolce and Gabbana",
                    Order = 7,
                    ParentId = 7
                },
                new Category()
                {
                    Id = 16,
                    Name = "Chanel",
                    Order = 8,
                    ParentId = 7
                },
                new Category()
                {
                    Id = 17,
                    Name = "Gucci",
                    Order = 1,
                    ParentId = 7
                },
                new Category()
                {
                    Id = 18,
                    Name = "Womens",
                    Order = 2,
                    ParentId = null
                },
                new Category()
                {
                    Id = 19,
                    Name = "Fendi",
                    Order = 0,
                    ParentId = 18
                },
                new Category()
                {
                    Id = 20,
                    Name = "Guess",
                    Order = 1,
                    ParentId = 18
                },
                new Category()
                {
                    Id = 21,
                    Name = "Valentino",
                    Order = 2,
                    ParentId = 18
                },
                new Category()
                {
                    Id = 22,
                    Name = "Dior",
                    Order = 3,
                    ParentId = 18
                },
                new Category()
                {
                    Id = 23,
                    Name = "Versace",
                    Order = 4,
                    ParentId = 18
                },
                new Category()
                {
                    Id = 24,
                    Name = "Kids",
                    Order = 3,
                    ParentId = null
                },
                new Category()
                {
                    Id = 25,
                    Name = "Fashion",
                    Order = 4,
                    ParentId = null
                },
                new Category()
                {
                    Id = 26,
                    Name = "Households",
                    Order = 5,
                    ParentId = null
                },
                new Category()
                {
                    Id = 27,
                    Name = "Interiors",
                    Order = 6,
                    ParentId = null
                },
                new Category()
                {
                    Id = 28,
                    Name = "Clothing",
                    Order = 7,
                    ParentId = null
                },
                new Category()
                {
                    Id = 29,
                    Name = "Bags",
                    Order = 8,
                    ParentId = null
                },
                new Category()
                {
                    Id = 30,
                    Name = "Shoes",
                    Order = 9,
                    ParentId = null
                }
            };
            _brands = new List<Brand>()
            {
                new Brand()
                {
                    Id = 1,
                    Name = "Acne",
                    Order = 0
                },
                new Brand()
                {
                    Id = 2,
                    Name = "Grüne Erde",
                    Order = 1
                },
                new Brand()
                {
                    Id = 3,
                    Name = "Albiro",
                    Order = 2
                },
                new Brand()
                {
                    Id = 4,
                    Name = "Ronhill",
                    Order = 3
                },
                new Brand()
                {
                    Id = 5,
                    Name = "Oddmolly",
                    Order = 4
                },
                new Brand()
                {
                    Id = 6,
                    Name = "Boudestijn",
                    Order = 5
                },
                new Brand()
                {
                    Id = 7,
                    Name = "Rösch creative culture",
                    Order = 6
                },
            };
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _brands;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }
    }
}
