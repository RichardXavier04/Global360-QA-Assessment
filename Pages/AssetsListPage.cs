using Microsoft.Playwright;

namespace Global360.QAAssessment.Pages;

public class AssetsListPage
{
    private readonly IPage _page;

    public AssetsListPage(IPage page)
    {
        _page = page;
    }
    public async Task OpenAssetsPageAsync()
    {
        await _page.Locator("a[data-title='Assets']").ClickAsync();

        await _page.WaitForTimeoutAsync(2000);
    }
    public async Task OpenCreateAssetPageAsync()
    {
        await _page.Locator("[data-original-title='Create New']").ClickAsync();

        await _page.WaitForTimeoutAsync(2000);
    }
    public async Task SearchAssetAsync(string serial)
    {
        var searchBox = _page.Locator("input.search-input[aria-label='Search']");

        await searchBox.ClickAsync();

        await searchBox.PressSequentiallyAsync(serial);

        await searchBox.PressAsync("Enter");

        await _page.WaitForTimeoutAsync(3000);
    }
    public async Task OpenCheckoutAsync(string serial)
    {
        var assetRow = _page
            .Locator("tr")
            .Filter(new() { HasText = serial });


        await assetRow
            .Locator("a.btn-checkout")
            .ClickAsync();
    }

    public async Task OpenAssetDetailsAsync(string serial)
    {
        var assetRow = _page
            .Locator("tr")
            .Filter(new() { HasText = serial });

        await assetRow
            .Locator("td")
            .Nth(1)
            .GetByRole(AriaRole.Link)
            .ClickAsync();
    }
    public async Task VerifyAssetIsVisibleAsync(string serial)
    {
        var assetRow = _page
            .Locator("tr")
            .Filter(new() { HasText = serial });

        await Assertions
            .Expect(assetRow)
            .ToBeVisibleAsync();
    }
}
