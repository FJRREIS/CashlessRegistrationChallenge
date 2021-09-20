using CashlessTokenChallenge.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashlessRegistrationChallenge.Tests.TestFixtures
{
    [TestFixture]
    class CardTests
    {
        [TestCase(403, 78952145263, 2635)]
        [TestCase(1, 1234, 4123)]
        [TestCase(361, 1, 1000)]
        public void TestGenerateToken_Valid(int cvv, long cardNumber, long expectedToken)
        {
            var card = new Card();
            card.CVV = cvv;
            card.CardNumber = cardNumber;
            var token = card.GenerateToken();
            Assert.AreEqual(token, expectedToken);
        }
    }
}
