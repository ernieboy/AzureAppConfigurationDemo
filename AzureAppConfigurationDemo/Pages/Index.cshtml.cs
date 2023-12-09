using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace AzureAppConfigurationDemo.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(IOptionsMonitor<AzureAppConfigurationDemoSettings> optionsMonitor)
        {
            AzureAppConfigurationDemoSettings = optionsMonitor.CurrentValue;
        }

        public void OnGet()
        {
            
        }

        public AzureAppConfigurationDemoSettings AzureAppConfigurationDemoSettings { get; set; }
    }
}
