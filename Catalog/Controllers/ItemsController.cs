using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        //Coletar o repositorio de items/inventario
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        //Passo a mais para coletar o item com base no id
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if(item is null){
                return NotFound();
            }

            return item.AsDto();
        }

        //Apos a criação de items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id}, item.AsDto() );
        }
        // Put items{id} -> Update de um item sobre seu id, podendo trocar os parametros de Name e Price
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);

            if(existingItem is null)
            {
                return NotFound();
            }
            //Criação de cópia dando um update em atributos pré-existentes
            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }
        // Deletar o item com base no Id
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
           var existingItem = repository.GetItem(id);

           if(existingItem is null)
           {
               return NotFound();
           }

           repository.DeleteItem(id);
           return NoContent();     
        }
    }
}