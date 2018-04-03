using CompanyCars.Core.Domain;
using CompanyCars.Core.Exceptions;
using Xunit;

namespace CompanyCars.Tests.DomainTests
{
    public class UserClassTests
    {
        User userClass = new User();

        [Fact]
        public void get_email_invalid_argument_check_throws_custom_exceptions()
        {
            Assert.Throws<CompanyCarsException>(() => userClass.SetEmail("something.com"));
            Assert.Throws<CompanyCarsException>(() => userClass.SetEmail("any_where.com"));
            Assert.Throws<CompanyCarsException>(() => userClass.SetEmail(""));
        }

        [Fact]
        public void get_name_invalid_argument_check_throws_custom_exceptions()
        {
            Assert.Throws<CompanyCarsException>(() 
                => userClass.SetUsername("interestingHowLongIsItFiftyCharactersString?BecauseIWantToMakeError"));
            Assert.Throws<CompanyCarsException>(() => userClass.SetUsername(""));
        }

        [Fact]
        public void get_fullname_invalid_argument_check_throws_custom_exceptions()
        {
            Assert.Throws<CompanyCarsException>(()
                => userClass.SetFullName(@"interestingHowLongIsItFiftyCharactersString?BecauseIWantToMakeError
                   WeNeedMoreCharacterToCheckACustomErrorForFullnameFieldButWeHaveAChanceToDoIt"));
        }

        [Fact]
        public void get_role_invalid_argument_check_throws_custom_exceptions()
        {
            Assert.Throws<CompanyCarsException>(() => userClass.SetRole("AnyRole"));
            Assert.Throws<CompanyCarsException>(() => userClass.SetRole(""));
        }
    }
}
