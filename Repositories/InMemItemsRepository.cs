using System;
using System.Collections.Generic;
using CatalogAPI.Entities;

namespace Repositories 
{
    
    public class InMemItemsRepository 
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Silver Sword", Price = 45, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 100, CreatedDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid Id)
        {
            return items.Where(items => item.Id == Id).SingleOrDefault();
        }
    }   
}