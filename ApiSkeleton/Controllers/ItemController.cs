using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiSkeleton.Controllers
{
	[Produces("application/json")]
	[Route("api/items")]
	public class ItemController : Controller
	{
		private readonly List<Item> _items;

		public ItemController()
		{
			_items = new List<Item>
			{
				new Item {Id = 1, Title = "Item 1", Value = 512M},
				new Item {Id = 2, Title = "Item 2", Value = 784M}
			};
		}

		[Route("")] // api/items
		[HttpGet]
		public IActionResult GetItems()
		{
			if (_items.Count == 0)
				return StatusCode(204);

			return Ok(_items);
		}

		[Route("{id}")] // api/items/2
		[HttpGet]
		public IActionResult GetItems(int id)
		{
			var item = _items.FirstOrDefault(i => i.Id == id);
			if (item == null)
				return NotFound();

			return Ok(item);
		}

		[Route("titles")] // api/items/titles
		[HttpGet]
		public IActionResult GetTitles()
		{
			var titlesList = new List<string>();

			_items.ForEach(i => titlesList.Add(i.Title));

			return Ok(titlesList);
		}
	}
}