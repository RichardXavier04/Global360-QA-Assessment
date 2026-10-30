using Global360.QAAssessment.Pages;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit.v3;

namespace Global360.QAAssessment.Tests;

public class CheckoutTests : PlaywrightTest
{
    [Fact]
    public async Task CheckoutExistingAsset_ShouldSucceed()
    {
        await using var browser = await Playwright.Chromium.LaunchAsync(new()
        {
            Channel = "chrome",
            Headless = false,
            SlowMo = 300
        });

        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        // Login
        var loginPage = new LoginPage(page);
        await loginPage.LoginAsync("admin", "password");

        // Open Assets
        var assetsListPage = new AssetsListPage(page);
        await assetsListPage.OpenAssetsPageAsync();

        // Search for the asset we already created
        await assetsListPage.SearchAssetAsync("SERIAL-12345");

        await assetsListPage.OpenCheckoutAsync("SERIAL-12345");

        var checkoutPage = new CheckoutPage(page);

        var selectedUser = await checkoutPage.SelectRandomUserAsync();

        await checkoutPage.AcceptInPlaceAsync();

        await checkoutPage.CheckoutAsync();
        // Temporary pause so we can see the result
        await page.WaitForTimeoutAsync(4000);
    }
}