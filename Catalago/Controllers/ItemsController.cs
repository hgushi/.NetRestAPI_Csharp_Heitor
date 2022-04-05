using Microsoft.AspNetCore.Mvc;
using Catalago.Repositories;

namespace Catalago.Controllers
{

    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository repository;
        public ItemsController()
        {
            repository = new InMemItemsRepository();
        }
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
			var items = repository.GetItems();
			return items;
        }
    }
}