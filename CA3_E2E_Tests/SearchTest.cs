using Microsoft.Playwright;
using Xunit;

public class SearchTests
{
    [Fact]
    public async Task Search_For_The_ShowsResults()
    {
        using var pw = await Playwright.CreateAsync();
        var browser = await pw.Chromium.LaunchAsync(new() { Headless = true });
        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://afarrelly90.github.io/CA3_WebApp_X00203931/");
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

        await page.GotoAsync("https://afarrelly90.github.io/CA3_WebApp_X00203931/");
        await page.WaitForSelectorAsync("text=Search for a TV show");
        await page.GetByLabel("Search for a TV Show").FillAsync("the wire");
        await page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

        await page.Locator(".show-card").First.WaitForAsync();
        await page.Locator(".show-card").First.ClickAsync();

        // wait for details page content
        await page.WaitForSelectorAsync(".show-title");

        Assert.True(true);
    }

}
