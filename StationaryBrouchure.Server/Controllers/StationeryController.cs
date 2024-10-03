using Microsoft.AspNetCore.Mvc;

namespace StationaryBrouchure.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class StationeryController : ControllerBase
	{
		// Mock data for demonstration
		private static readonly List<StationeryItem> Stationeries = new List<StationeryItem>
		{
			new StationeryItem
			{
				Id = 1,
				Name = "Ballpoint Pen",
				Description = "Smooth writing ballpoint pen.",
				ImageUrl = "pen.jpg"
			},
            // Add more items as needed
        };

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(Stationeries);
		}
	}

	public class StationeryItem
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty; // Initialize with default value
		public string Description { get; set; } = string.Empty; // Initialize with default value
		public string ImageUrl { get; set; } = string.Empty; // Initialize with default value
	}
}
