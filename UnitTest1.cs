using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightTests
{
    public class Tests
    {
        [Test]
        public async Task GoogleTitleShouldContainGoogle()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.google.com");
            var title = await page.TitleAsync();
            Assert.That(title, Does.Contain("Google"));
        }
    }
}
