using Global360.QAAssessment.Pages;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit.v3;

namespace Global360.QAAssessment.Tests;

public class CreateAssetTests : PlaywrightTest
{
    [Fact]
    public async Task CreateMacbookAsset_ShouldSucceed()
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
        await assetsListPage.OpenCreateAssetPageAsync();
        var createAssetPage = new CreateAssetPage(page);
        await createAssetPage.EnterSerialAsync("SERIAL-12345");
        await createAssetPage.SelectModelAsync();
        await createAssetPage.SelectStatusAsync();
        await createAssetPage.EnterNotesAsync("Automation Testing");
        await createAssetPage.SaveAsync();

        //await assetsListPage.OpenCreateAssetPageAsync();

        await page.WaitForTimeoutAsync(4000);

        // Find the same asset we just created

        Assert.DoesNotContain(
            "/login",
            page.Url,
            StringComparison.OrdinalIgnoreCase);
    }
}
