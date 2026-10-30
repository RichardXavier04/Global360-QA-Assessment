using Microsoft.Playwright;

namespace Global360.QAAssessment.Pages;

public class CheckoutPage
{
    private readonly IPage _page;

    public CheckoutPage(IPage page)
    {
        _page = page;
    }

    public async Task<string> SelectRandomUserAsync()
    {
        // Open the User dropdown
        await _page
            .Locator("#select2-assigned_user_select-container")
            .ClickAsync();

        // Get all currently available users
        var users = _page
            .Locator("#select2-assigned_user_select-results")
            .Locator("[role='option']")
            .Filter(new() { HasNotText = "Loading" });

        var userCount = await users.CountAsync();

        if (userCount == 0)
        {
            throw new Exception("No users were available in the User dropdown.");
        }

        // Pick a random user
        var randomIndex = Random.Shared.Next(userCount);

        var selectedUser = users.Nth(randomIndex);

        // Remember the user's visible name
        var selectedUserName = (await selectedUser.InnerTextAsync()).Trim();

        // Click that user
        await selectedUser.ClickAsync();

        return selectedUserName;
    }

    public async Task AcceptInPlaceAsync()
    {
        await _page
            .Locator("#sign_in_place")
            .CheckAsync();
    }

    public async Task CheckoutAsync()
    {
        await _page.Locator("#submit_button").ClickAsync();
    }
}