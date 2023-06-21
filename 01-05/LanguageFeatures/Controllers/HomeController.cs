namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ViewResult> Index()
        {
            List<string> output = new();
            await foreach (long? len in MyAsyncMethods.GetPageLengths(output, "apress.com", "microsoft.com", "amazon.com", "news.ycombinator.com"))
            {
                output.Add($"Page length: {len}");
            }
            return View(output);
        }
    }
}
