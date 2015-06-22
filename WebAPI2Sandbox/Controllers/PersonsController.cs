using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebAPI2Sandbox.Models;

namespace WebAPI2Sandbox.Controllers
{
	public class PersonsController : ApiController
	{

		#region ================================================== Private Members ==================================================

		private static Dictionary<int, Person> persons = new Dictionary<int, Person>()
		{
			{ 1, new Person(){ Id = 1, FirstName = "Soup",        LastName = "Food" } },
			{ 2, new Person(){ Id = 2, FirstName = "Yo-yo",       LastName = "Toys" } },
			{ 3, new Person(){ Id = 3, FirstName = "Hammer",      LastName = "Tools" } },
			{ 4, new Person(){ Id = 4, FirstName = "Tomahawk",    LastName = "Weaponry" } },
			{ 5, new Person(){ Id = 5, FirstName = "Ragdoll",     LastName = "Cats" } },
			{ 6, new Person(){ Id = 6, FirstName = "Camera",      LastName = "Electronics" } },
			{ 7, new Person(){ Id = 7, FirstName = "Pantyhose",   LastName = "Clothing" } },
			{ 8, new Person(){ Id = 8, FirstName = "Coffee",      LastName = "Beverages" } }
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

		/// <summary>
		/// Decorate with HttpGet, because method does not start with Get.
		/// </summary>
		[HttpGet]
		public ServiceResult<Person[]> RetrieveEven()
		{
			return ExecuteSafely<Person[]>(() => {
				return new ServiceResult<Person[]>(
					persons.Values.Where(x => x.Id % 2 == 0).ToArray()
				);
			});
		}




		/// <summary>
		/// Decorate with HttpGet, because method does not start with Get.
		/// </summary>
		[HttpGet]
		public ServiceResult<Person[]> RetrieveOdd()
		{
			return ExecuteSafely<Person[]>(() => {
				return new ServiceResult<Person[]>(
					persons.Values.Where(x => x.Id % 2 == 1).ToArray()
				);
			});
		}

		#endregion ================================================== Private Methods ==================================================

	}
}
