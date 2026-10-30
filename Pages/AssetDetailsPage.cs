using Microsoft.Playwright;

namespace Global360.QAAssessment.Pages;

public class AssetDetailsPage
{
    private readonly IPage _page;

    public AssetDetailsPage(IPage page)
    {
        _page = page;
    }

    public async Task OpenHistoryTabAsync()
    {
        await _page
            .Locator("a[data-original-title='History']")
            .ClickAsync();
    }
    public async Task VerifyCreateHistoryAsync()
    {
        var createRow = _page
            .Locator("#history")
            .Locator("tr")
            .Filter(new() { HasText = "create new" });

        await Assertions
            .Expect(createRow)
            .ToBeVisibleAsync();
    }

    public async Task VerifyCheckoutHistoryAsync()
    {
        var checkoutRow = _page
            .Locator("#history")
            .Locator("tr")
            .Filter(new() { HasText = "checkout" });

        await Assertions
            .Expect(checkoutRow)
            .ToBeVisibleAsync();
    }

    public async Task VerifySerialAsync(string serial)
    {
        await Assertions
            .Expect(_page.GetByText(serial, new() { Exact = true }))
            .ToBeVisibleAsync();
    }

    public async Task VerifyModelAsync(string model)
    {
        await Assertions
            .Expect(_page.GetByRole(AriaRole.Link, new() { Name = model, Exact = true }))
            .ToBeVisibleAsync();
    }
}