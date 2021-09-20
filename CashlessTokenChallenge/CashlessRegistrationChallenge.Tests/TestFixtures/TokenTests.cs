using CashlessTokenChallenge.Models;
using CashlessTokenChallenge.Models.DTOs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashlessRegistrationChallenge.Tests.TestFixtures
{
    [TestFixture]
    class TokenTests
    {
        private Token _token;
        private Token _expiredToken;

        [SetUp]
        public void Setup()
        {
            var card = new Card()
            {
                CustomerId = 5,
                CardNumber = 9582152462158625
            };

            _token = new Token(1, 2586, 30);
            _token.Card = card;

            _expiredToken = new Token(1, 2586, -5);
            _expiredToken.Card = card;
        }


        [TestCase(5, 2586, 162)]
        public void TestValidateToken_Valid(int customerId, long token, int cvv)
        {
            var validationDTO = new TokenValidationDTO()
            {
                CustomerId = customerId,
                Token = token,
                CVV = cvv
            };
            var isValid = _token.ValidateToken(validationDTO);
            Assert.IsTrue(isValid);
        }

        [TestCase(5, 2586, 162)]
        public void TestValidateToken_Expired(int customerId, long token, int cvv)
        {
            var validationDTO = new TokenValidationDTO()
            {
                CustomerId = customerId,
                Token = token,
                CVV = cvv
            };
            var isValid = _expiredToken.ValidateToken(validationDTO);
            Assert.IsFalse(isValid);
        }

        [TestCase(3, 2586, 162)]
        public void TestValidateToken_WrongCustomer(int customerId, long token, int cvv)
        {
            var validationDTO = new TokenValidationDTO()
            {
                CustomerId = customerId,
                Token = token,
                CVV = cvv
            };
            var isValid = _token.ValidateToken(validationDTO);
            Assert.IsFalse(isValid);
        }

        [TestCase(5, 8625, 162)]
        public void TestValidateToken_WrongToken(int customerId, long token, int cvv)
        {
            var validationDTO = new TokenValidationDTO()
            {
                CustomerId = customerId,
                Token = token,
                CVV = cvv
            };
            var isValid = _token.ValidateToken(validationDTO);
            Assert.IsFalse(isValid);
        }
    }
}
