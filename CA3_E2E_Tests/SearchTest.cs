using Microsoft.Playwright;
using Xunit;

public class SearchTests
{
    private const string BaseUrl = "https://afarrelly90.github.io/CA3_WebApp_X00203931/";

    [Fact]
    public async Task Search_For_The_ShowsResults()
    {
        using var pw = await Playwright.CreateAsync();
        var browser = await pw.Chromium.LaunchAsync(new() { Headless = true });
        var page = await browser.NewPageAsync();

        await page.GotoAsync(BaseUrl);
        // find tv show search input and search for 'the wire'
        await page.WaitForSelectorAsync("text=Search for a TV show");
        await page.GetByLabel("Search for a TV Show").FillAsync("the wire");
        await page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();


        // confirm the page loads and shows atleast 1 show
        await page.Locator(".show-card").First.WaitForAsync();
        // test completed
        Assert.True(true);
    }

    [Fact]
    public async Task ShowDetails_PageLoads()
    {
        using var pw = await Playwright.CreateAsync();
        var browser = await pw.Chromium.LaunchAsync(new() { Headless = true });
        var page = await browser.NewPageAsync();

        await page.GotoAsync(BaseUrl);

        // find tv show search input and search for 'the wire'
        await page.WaitForSelectorAsync("text=Search for a TV show");
        await page.GetByLabel("Search for a TV Show").FillAsync("the wire");
        await page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

        // confirm the page loads and shows atleast 1 show
        await page.Locator(".show-card").First.WaitForAsync();
        await page.Locator(".show-card").First.ClickAsync();

        // wait for details page content
        await page.WaitForSelectorAsync(".show-title");
        // test completed
        Assert.True(true);
    }

    [Fact]
    public async Task EmptySearch_ShowsValidationMessage()
    {
        using var pw = await Playwright.CreateAsync();
        var browser = await pw.Chromium.LaunchAsync(new() { Headless = true });
        var page = await browser.NewPageAsync();

        await page.GotoAsync(BaseUrl);

        await page.WaitForSelectorAsync("text=Search for a TV show");
        // leave input empty and click Search
        await page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();
        // find error message
        await page.WaitForSelectorAsync("text=Please enter something to search.");
        // test completed
        Assert.True(true);
    }
}
