using System;
using System.Collections.Generic;
using CheckoutAd.Api.Middlewares.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CheckoutAd.Api.Controllers
{
	/// <summary>
	/// Values endpoint controller
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly ILogger<ValuesController> _logger;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="logger"></param>
		public ValuesController(ILogger<ValuesController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// GET api/values
		/// </summary>
		/// <returns>"value1", "value2"</returns>
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			_logger.LogInformation("Get mthod is called");
			//throw new Exception();
			return new string[] { "value1", "value2" };
		}

		/// <summary>
		/// GET api/values/5
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		/// <summary>
		/// GET api/values/exception
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		[HttpGet("{exception}")]
		public ActionResult<string> GetHandledException(string exception)
		{
			throw new NotFoundCustomException("No data found", $"Please check your parameters id: {exception}");
		}

		/// <summary>
		/// POST api/values
		/// </summary>
		/// <param name="value"></param>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		/// <summary>
		/// PUT api/values/5
		/// </summary>
		/// <param name="id"></param>
		/// <param name="value"></param>
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		/// <summary>
		/// DELETE api/values/5
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
