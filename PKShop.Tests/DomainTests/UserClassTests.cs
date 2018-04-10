using PKShop.Core.Exceptions;
using Xunit;
using PKShop.Core.Domain.Identity;

namespace PKShop.Tests.DomainTests
{
    public class UserClassTests
    {
        User userClass = new User();

        [Fact]
        public void get_email_invalid_argument_check_throws_custom_exceptions()
        {
            Assert.Throws<PKShopException>(() => userClass.SetEmail("something.com"));
            Assert.Throws<PKShopException>(() => userClass.SetEmail("any_where.com"));
            Assert.Throws<PKShopException>(() => userClass.SetEmail(""));
        }

        [Fact]
        public void get_name_invalid_argument_check_throws_custom_exceptions()
        {
            Assert.Throws<PKShopException>(() 
                => userClass.SetUsername("interestingHowLongIsItFiftyCharactersString?BecauseIWantToMakeError"));
            Assert.Throws<PKShopException>(() => userClass.SetUsername(""));
        }

        [Fact]
        public void get_role_invalid_argument_check_throws_custom_exceptions()
        {
            Assert.Throws<PKShopException>(() => userClass.SetRole("AnyRole"));
            Assert.Throws<PKShopException>(() => userClass.SetRole(""));
        }
    }
}
