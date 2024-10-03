using Microsoft.AspNetCore.Mvc;
using StationaryBrouchure.Server.Data;
using StationaryBrouchure.Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Text;

namespace StationaryBrouchure.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CartController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public CartController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<CartItem>>> GetCartItems()
		{
			var cartItems = await _context.CartItems
				.Include(ci => ci.Product) // Include product details
				.ToListAsync();

			return Ok(cartItems);
		}

		[HttpPost("add/{productId}")]
		public async Task<IActionResult> AddToCart(int productId)
		{
			var existingCartItem = await _context.CartItems
				.FirstOrDefaultAsync(ci => ci.ProductId == productId);

			if (existingCartItem != null)
			{
				existingCartItem.Quantity++;
				_context.CartItems.Update(existingCartItem);
			}
			else
			{
				var newCartItem = new CartItem
				{
					ProductId = productId,
					Quantity = 1
				};
				await _context.CartItems.AddAsync(newCartItem);
			}

			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpPost("remove/{productId}")]
		public async Task<IActionResult> RemoveFromCart(int productId)
		{
			var cartItem = await _context.CartItems
				.FirstOrDefaultAsync(ci => ci.ProductId == productId);

			if (cartItem == null)
			{
				return NotFound("Item not found in cart.");
			}

			_context.CartItems.Remove(cartItem);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpPost("proceedToCheckout")]
		public async Task<IActionResult> ProceedToCheckout()
		{
			// Fetch cart items
			var cartItems = await _context.CartItems
				.Include(ci => ci.Product) // Include product details
				.ToListAsync();

			if (!cartItems.Any())
			{
				return BadRequest("Cart is empty.");
			}

			// Example company and branch (replace with actual company and branch info)
			string companyName = "Company-X";
			string branchName = "Branch-Y";

			// Generate email body
			StringBuilder emailBody = new StringBuilder();
			emailBody.AppendLine($"The order details from {companyName} and {branchName} are listed below:");

			int itemNumber = 1;
			foreach (var item in cartItems)
			{
				emailBody.AppendLine($"{itemNumber}. {item.Product.Name} - ${item.Product.Price}");
				itemNumber++;
			}

			// Convert the StringBuilder to string
			string body = emailBody.ToString();

			// Send email
			string email = "raghulkannalakshmanan@gmail.com"; // Replace with actual recipient email
			string subject = $"Checkout Notification - Order recieved for RK Traders from {companyName} and {branchName}";

			await SendEmailAsync(email, subject, body);

			// Clear the cart after checkout
			_context.CartItems.RemoveRange(cartItems);
			await _context.SaveChangesAsync();

			return Ok("Checkout successful");
		}


		private async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
		{
			try
			{
				using (var smtpClient = new SmtpClient("smtp.gmail.com"))
				{
					smtpClient.Port = 587;
					smtpClient.Credentials = new System.Net.NetworkCredential("r1234kanna@gmail.com", "qxbr ecwp lbkj uecv");
					smtpClient.EnableSsl = true;

					var mailMessage = new MailMessage
					{
						From = new MailAddress("r1234kanna@gmail.com"),
						Subject = subject,
						Body = body,
						IsBodyHtml = false,
					};

					mailMessage.To.Add(toEmail);
					await smtpClient.SendMailAsync(mailMessage);
					return true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error sending email: " + ex.Message);
				return false;
			}
		}

	}
}
