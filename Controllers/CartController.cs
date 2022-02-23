using CicekSepetiAPI.DAL.CartRepo;
using CicekSepetiAPI.DAL.ProductRepo;
using CicekSepetiAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CicekSepetiAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CartController : Controller
    {
        private readonly IProductRepository _productDal;
        private readonly ICartRepository _cartDal;
        private readonly ILogger _logger;


        public CartController(IProductRepository productDal, ICartRepository cartDal, ILogger<CartController> logger)
        {
            _productDal = productDal;
            _cartDal = cartDal;
            _logger = logger;
        }
        [HttpGet]
        [AllowAnonymous]
        public string Get()
        {
            return "It seems to work fine";
        }



        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            try
            {

                //_logger.LogInformation($"Adding {cart.Product.Name} to cart");
                //add to cart
                await _productDal.AddAsync(product);
                //return all cart items of the user
                //var cartList = _cartDal.Get(x => x.UserId == cart.UserId).ToList();
                //_logger.LogInformation($"Success. Total quantity {cartList.Sum(x => x.Quantity)}");
                //return StatusCode(200, new { Message = "Success", CartList = cartList });

                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError($"something went wrong. Exception {e.Message}");
                throw new ArgumentException("Something went wrong please try again");
            }
        }

        /// <summary>
        /// Adds product to user cart
        /// </summary>
        ///// <param name="cart">Cart model</param>
        /// <returns>List of cart with HTTP code</returns>
        [HttpPost]
        [Route("addToCart")]
        public async Task<IActionResult> AddToCartAsync(Cart cart)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                cart.UserId = userId;
                var product = await _productDal.GetByIdAsync(cart.ProductId);
                cart.Product = product;
                if (product == null)
                {
                    _logger.LogWarning($"Product with {cart.ProductId} could not be found");
                    return StatusCode(400, new { Message = "The product could not be found", Cart = cart });
                }
                if (product.StockQuantity < cart.Quantity)
                {
                    _logger.LogWarning($"{cart.Product.Name} is out of stock");
                    return StatusCode(400, new { Message = "The Product is out of stock", Cart = cart });
                }
                _logger.LogInformation($"Adding {cart.Product.Name} to cart");
                //add to cart
                await _cartDal.AddAsync(cart);
                //return all cart items of the user
                var cartList = _cartDal.Get(x => x.UserId == cart.UserId).ToList();
                _logger.LogInformation($"Success. Total quantity {cartList.Sum(x => x.Quantity)}");
                return StatusCode(200, new { Message = "Success", CartList = cartList });
            }
            catch (Exception e)
            {
                _logger.LogError($"something went wrong. Exception {e.Message}");
                throw new ArgumentException("Something went wrong please try again");
            }
        }
    }
}
