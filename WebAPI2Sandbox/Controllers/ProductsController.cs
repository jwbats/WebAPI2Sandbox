using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebAPI2Sandbox.Models;

namespace WebAPI2Sandbox.Controllers
{
	public class ProductsController : ApiController
	{

		#region ================================================== Private Members ==================================================

		private static Dictionary<int, Product> products = new Dictionary<int, Product>()
		{
			{ 1, new Product(){ Id = 1, Name = "Soup",        Category = "Food",        Price = 1.5M } },
			{ 2, new Product(){ Id = 2, Name = "Yo-yo",       Category = "Toys",        Price = 2.5M } },
			{ 3, new Product(){ Id = 3, Name = "Hammer",      Category = "Tools",       Price = 3.5M } },
			{ 4, new Product(){ Id = 4, Name = "Tomahawk",    Category = "Weaponry",    Price = 4.5M } },
			{ 5, new Product(){ Id = 5, Name = "Ragdoll",     Category = "Cats",        Price = 5.5M } },
			{ 6, new Product(){ Id = 6, Name = "Camera",      Category = "Electronics", Price = 6.5M } },
			{ 7, new Product(){ Id = 7, Name = "Pantyhose",   Category = "Clothing",    Price = 7.5M } },
			{ 8, new Product(){ Id = 8, Name = "Coffee",      Category = "Beverages",   Price = 8.5M } }
		};

		#endregion ================================================== Private Members ==================================================




		#region ================================================== Private Methods ==================================================

		private ServiceResult<T> ExecuteSafely<T>(Func<ServiceResult<T>> func)
		{
			try
			{
				return func();
			}
			catch (Exception exception)
			{
				// TO DO: log exception
				return new ServiceResult<T>(default(T), exception.ToString(), false);
			}
		}

		#endregion ================================================== Private Methods ==================================================




		#region ================================================== Public Methods ==================================================

		// GET api/<controller>
		public ServiceResult<Product[]> Get()
		{
			return ExecuteSafely<Product[]>(() => {
				return new ServiceResult<Product[]>(
					products.Values.ToArray()
				);
			});
		}


	
		
		// GET api/<controller>/5
		public ServiceResult<Product> Get(int id)
		{
			return ExecuteSafely<Product>(() => {
				return (products.ContainsKey(id))
					? new ServiceResult<Product>(products[id])
					: new ServiceResult<Product>(null, "Not found.", false);
			});
		}



	
		// POST api/<controller>
		public ServiceResult<Product> Post([FromBody]Product product)
		{
			return ExecuteSafely<Product>(() => {
				bool containsKey = products.ContainsKey(product.Id);
				
				if (!containsKey)
				{
					products[product.Id] = product;
				}

				return (!containsKey)
					? new ServiceResult<Product>(product)
					: new ServiceResult<Product>(null, "Conflicting ids.", false);
			});
		}



	
		// PUT api/<controller>/5
		public ServiceResult<Product> Put([FromBody]Product product)
		{
			return ExecuteSafely<Product>(() => {
				bool containsKey = products.ContainsKey(product.Id);

				if (containsKey)
				{
					products[product.Id] = product;
				}

				return (containsKey)
					? new ServiceResult<Product>(product)
					: new ServiceResult<Product>(null, "Id not found.", false);
			});
		}



	
		// DELETE api/<controller>/5
		public ServiceResult<int> Delete(int id)
		{
			return ExecuteSafely<int>(() => {
				bool containsKey = products.ContainsKey(id);

				if (containsKey)
				{
					products.Remove(id);
				}

				return (containsKey)
					? new ServiceResult<int>(id)
					: new ServiceResult<int>(0, "Id not found.", false);
			});
		}

		#endregion ================================================== Public Methods ==================================================

	}
}