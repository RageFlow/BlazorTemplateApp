using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BlazorTemplateApp.Shared
{
    public partial class MainLayout : IDisposable
    {
        private async void LocationChanged(object sender, LocationChangedEventArgs e) => await codeDisplayService.UpdateUI();

        protected override void OnInitialized()
        {
            navigationManager.LocationChanged += LocationChanged;
            
            base.OnInitialized();
        }

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                await codeDisplayService.UpdateUI();
            }
        }

        public void Dispose()
        {
            navigationManager.LocationChanged -= LocationChanged;
        }
    }
}