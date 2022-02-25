using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWebAssemblyGetIpAddress.Pages
{
    public class IndexBase : ComponentBase
    {
        public string IpAddress { get; set; } = string.Empty;

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetMyIpAddress();
        }

        public async Task<string> GetMyIpAddress()
        {
            IpAddress = await JsRuntime.InvokeAsync<string>("getIpAddress")
                .ConfigureAwait(true);

            return IpAddress;
        }
    }
}