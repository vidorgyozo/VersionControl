using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // arrange
            var accountController = new AccountController();

            // act
            var actualResult = accountController.ValidateEmail(email);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [
            Test,
            TestCase("abcdEFGH", false),
            TestCase("1234EFGH", false),
            TestCase("abcd1234", false),
            TestCase("aB3", false),
            TestCase("abc123AÁ", false),
            TestCase("a2Cd5FAA", true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            var accountController = new AccountController();

            var actualResult = accountController.ValidatePassword(password);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [
            Test,
            TestCase("asdfhong@gmail.com", "Abcd2134"),
            TestCase("smaanKol@gmail.com", "Rakmaz1turulostarsoly")
        ]
        public void TestRegisterHappyPath(string email, string password)
        {
            var accountController = new AccountController();

            var actualResult = accountController.Register(email, password);

            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }

        [
            Test,
            TestCase("asdfhong@gmail.com", "Abcd213"),
            TestCase("smaanKol@gmail.com", "Rakmaz1turÚlostarsoly"),
            TestCase("smaanKol@gmail.com", "aaaaaaaaaaaaaaaa"),
            TestCase("asdfhonggmail.com", "Abcd2134")
        ]
        public void TestRegisterValidateException(string email, string password)
        {
            var accountController = new AccountController();

            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOf<ValidationException>(e);
            }

        }
    }
}
