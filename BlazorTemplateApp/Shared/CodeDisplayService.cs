using PSC.Blazor.Components.CodeSnippet;

namespace BlazorTemplateApp.Shared
{
    public class CodeDisplayService
    {
        public CodeDisplayService()
        {
            Files = new();
        }

        public Style codeSnippetStyle { get; set; } = Style.DefaultStyle;

        public List<string> Files { get; private set; }
        private List<string>? NewFiles { get; set; }

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        public async Task UpdateFiles(List<string> codeFiles)
        {
            NewFiles = codeFiles; // Sætter Files til den korrekte UI Page

            await Task.CompletedTask;
        }

        public async Task RefreshFiles() // Brugt til at opdatere CodeDisplay Section med nye værdier
        {
            if (Files.Count > 0) // Sørge for at Files ikke er en tom liste
            {
                var localFiles = Files; // Sætter Files til en lokal variable
                //await UpdateFiles(new List<string>()); // Update files med tom liste og opdaterer UI
                //await UpdateUI();

                //await Task.Delay(1000); // Venter for at lade UI'en opdatere med den tomme liste

                await UpdateFiles(localFiles); // Opdatere Files med de originale filer
                await UpdateUI();
            }
        }

        public async Task UpdateUI()
        {
            if (NewFiles != null)
            {
                Files = new();
                Files = NewFiles;
                NewFiles = null;
            }
            else
            {
                Files = new();
            }
            NotifyStateChanged();

            await Task.CompletedTask;
        }
    }
}
