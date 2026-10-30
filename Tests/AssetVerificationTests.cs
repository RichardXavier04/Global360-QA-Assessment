using Global360.QAAssessment.Pages;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit.v3;

namespace Global360.QAAssessment.Tests;

public class AssetVerificationTests : PlaywrightTest
{
    [Fact]
    public async Task VerifyCreatedAsset_ShouldSucceed()
    {
        await using var browser = await Playwright.Chromium.LaunchAsync(new()
        {
            Channel = "chrome",
            Headless = false,
            SlowMo = 300
        });

        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        var loginPage = new LoginPage(page);
        await loginPage.LoginAsync("admin", "password");

        var assetsListPage = new AssetsListPage(page);

        await assetsListPage.OpenAssetsPageAsync();

        await assetsListPage.SearchAssetAsync("SERIAL-12345");

        await assetsListPage.VerifyAssetIsVisibleAsync("SERIAL-12345");

        // Only after verification, open the asset
        await assetsListPage.OpenAssetDetailsAsync("SERIAL-12345");
        var assetDetailsPage = new AssetDetailsPage(page);
        await assetDetailsPage.VerifySerialAsync("SERIAL-12345");

        await assetDetailsPage.VerifyModelAsync("Macbook Pro 13\"");

        await assetDetailsPage.OpenHistoryTabAsync();

        await assetDetailsPage.VerifyCreateHistoryAsync();

        await assetDetailsPage.VerifyCheckoutHistoryAsync();

        await page.WaitForTimeoutAsync(3000);


    }
}
