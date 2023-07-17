using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests
{
    using NUnit.Framework;
    using Moq;
    using ThunderWings.Api.Services.Cart;
    using Microsoft.Extensions.Logging;
    using ThunderWings.Api.Repositories.IRepositories;
    using ThunderWings.Api.Models.Domain;
    using System.Linq.Expressions;

    [TestFixture]
    public class CartServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ILogger<CartService>> _loggerMock;
        private ICartService _cartService;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _loggerMock = new Mock<ILogger<CartService>>();
            _cartService = new CartService(_unitOfWorkMock.Object, _loggerMock.Object);
        }

        [Test]
        public void GetCartDetails_Should_ReturnCartDetails_When_UserIdIsValid()
        {
            // Arrange
            var userId = "testUser";
            var cartDetails = new List<ShoppingCart>
        {
            new ShoppingCart { ApplicationUserId = userId, AircraftId = 1, Count = 1 },
            new ShoppingCart { ApplicationUserId = userId, AircraftId = 2, Count = 3 }
        };

            _unitOfWorkMock.Setup(uow => uow.ShoppingCart.GetAll(It.IsAny<Func<ShoppingCart, bool>>()))
                .Returns(cartDetails);

            // Act
            var result = _cartService.GetCartDetails(userId);

            // Assert
            Assert.AreEqual(cartDetails, result);
        }

        [Test]
        public void RemoveFromCart_Should_RemoveItemFromCart_When_CartExists()
        {
            // Arrange
            var userId = "testUser";
            var aircraftId = 1;
            var cartFromDb = new ShoppingCart
            {
                ApplicationUserId = userId,
                AircraftId = aircraftId,
                Count = 2
            };

            _unitOfWorkMock.Setup(uow => uow.ShoppingCart.Get(It.IsAny<Func<ShoppingCart, bool>>()))
     .Returns<Func<ShoppingCart, bool>>(predicate => cartFromDb);

            // Act
            var result = _cartService.RemoveFromCart(aircraftId, userId);

            // Assert
            Assert.AreEqual(cartFromDb, result);
            Assert.AreEqual(1, result.Count); // Verify that the count is decremented
            _unitOfWorkMock.Verify(uow => uow.ShoppingCart.Update(cartFromDb), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [Test]
        public void RemoveFromCart_Should_RemoveCart_When_CartIsEmpty()
        {
            // Arrange
            var userId = "testUser";
            var aircraftId = 1;
            var cartFromDb = new ShoppingCart
            {
                ApplicationUserId = userId,
                AircraftId = aircraftId,
                Count = 1
            };

            _unitOfWorkMock.Setup(uow => uow.ShoppingCart.Get(It.IsAny<Func<ShoppingCart, bool>>()))
                .Returns(cartFromDb);

            // Act
            var result = _cartService.RemoveFromCart(aircraftId, userId);

            // Assert
            Assert.AreEqual(cartFromDb, result);
            Assert.IsNull(result); // Verify that the cart is removed (null is returned)
            _unitOfWorkMock.Verify(uow => uow.ShoppingCart.Remove(cartFromDb), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }
    }

}
