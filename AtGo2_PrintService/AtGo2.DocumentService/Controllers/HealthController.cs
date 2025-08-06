// <copyright file="HealthController.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace AtGo2.DocumentService.Controllers
{
    /// <summary>
    /// Health controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() =>
            {
                return Ok("API is runninng.");
            });
        }
    }
}
