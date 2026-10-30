using Microsoft.Playwright;

namespace Global360.QAAssessment.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }
    public async Task LoginAsync(string username, string password)
    {
        await _page.GotoAsync("https://demo.snipeitapp.com/login");

        await _page.GetByLabel("Username").FillAsync(username);
        await _page.GetByPlaceholder("Password").FillAsync(password);

        await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
    }
}