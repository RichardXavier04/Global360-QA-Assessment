using Microsoft.Playwright;

namespace Global360.QAAssessment.Pages;

public class CreateAssetPage
{
    private readonly IPage _page;

    public CreateAssetPage(IPage page)
    {
        _page = page;
    }

    public async Task EnterSerialAsync(string serial)
    {
        await _page.Locator("#serial_1").FillAsync(serial);
    }

    public async Task SelectModelAsync()
    {
        await _page
            .GetByText("Select a Model", new() { Exact = true })
            .ClickAsync();

        await _page
            .GetByText("Macbook Pro 13\"", new() { Exact = false })
            .ClickAsync();
    }

    public async Task SelectStatusAsync()

    {
        await _page
            .Locator("#select2-status_select_id-container")
            .ClickAsync();

        await _page
            .GetByRole(
                AriaRole.Option,
                new() { Name = "Ready to Deploy", Exact = true })
            .ClickAsync();
    }

    public async Task EnterNotesAsync(string notes)
    {
        await _page
            .Locator("#notes")
            .FillAsync(notes);
    }

    public async Task SaveAsync()
    {
        await _page.Locator("button[name='submit']").ClickAsync();
    }
}
