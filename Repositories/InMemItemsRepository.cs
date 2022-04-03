using System;
using System.Collections.Generic;
using Catalogo.Entities;

namespace Repositories 
{
    
    public class InMemItemsRepository 
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Potion1", Price = 45, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Potion2", Price = 100, CreatedDate = DateTimeOffset.UtcNow}
        };
    }
}