namespace MediaCollection.API.Testing.ControllerTests.AccountControllerTests;

[ExcludeFromCodeCoverage]
public class AccountControllerTestBase
{
    internal static AccountController BuildAccountController(IAccountService? accountService = null)
    {
        AccountController accountController = new(accountService ?? Mock.Of<IAccountService>());

        return accountController;
    }
}
