using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThunderWings.Api.Models;
using ThunderWings.Api.Models.Domain;
using ThunderWings.Api.Repositories.IRepositories;
using ThunderWings.Api.Services.Cart;
using ThunderWings.Api.Services.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThunderWings.Api.Models.DTO;
using ThunderWings.Api.Repositories;

namespace ThunderWings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly ILogger<AircraftController> _logger;

        public AircraftController(IUnitOfWork unitOfWork, IOrderService orderService, ICartService cartService, ILogger<AircraftController> logger)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _cartService = cartService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all aircrafts.
        /// </summary>
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Aircraft>> GetAircrafts()
        {
            try
            {
                var aircraftsList = _unitOfWork.Aircraft.GetAll();

                return Ok(aircraftsList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving aircrafts.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        /// <summary>
        /// Adds an aircraft to the shopping cart.
        /// </summary>
        /// <param name="airCraftId">The ID of the aircraft to add.</param>
        /// <param name="userId">The ID of the user.</param>
        [HttpPost("AddToCart")]
        public IActionResult AddToCart(int aircraftId, string userId)
        {
            try
            {
                ShoppingCart cart = _cartService.AddToCart(aircraftId, userId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding an item to the cart.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        /// <summary>
        /// Removes an item from the shopping cart.
        /// </summary>
        /// <param name="cartId">The ID of the cart item to remove.</param>
        /// <param name="userId">The ID of the user.</param>
        [HttpPost("RemoveFromCart")]
        public IActionResult RemoveFromCart(int aircraftId, string userId)
        {
            try
            {
                ShoppingCart cart = _cartService.RemoveFromCart(aircraftId, userId);
                if (cart != null)
                {
                    return Ok(cart);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing an item from the cart.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        /// <summary>
        /// Retrieves the cart details for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        [HttpGet("CartDetails")]
        public IActionResult CartDetails(string userId)
        {
            try
            {
                List<ShoppingCart> cartDetails = _cartService.GetCartDetails(userId);
                return Ok(cartDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving cart details.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        /// <summary>
        /// Submits an order for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        [HttpGet("Submit")]
        public async Task<IActionResult> Submit(string userId)
        {
            try
            {
                string orderConfirmation = await _orderService.SubmitOrderAsync(userId);
                return Ok(orderConfirmation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while submitting the order.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("Search")]
        public IActionResult SearchJets([FromBody] SearchRequestDto requestDto)
        {
            try
            {
                var jets = _unitOfWork.Aircraft.SearchJets(requestDto);
                return Ok(jets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while searching for jets.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while searching for jets. Please try again later.");
            }
        }
    }
}
