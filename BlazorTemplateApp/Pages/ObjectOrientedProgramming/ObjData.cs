using System.Collections.ObjectModel;

namespace BlazorTemplateApp.Pages.ObjectOrientedProgramming
{

    public static class ObjData
    {
        public static ObservableCollection<string> consoleEmulator = new();
        static Puma puma { get; set; } = new(); // Ny Puma
        static List<Ko> koListe { get; set; } = new(); // Ny liste af typen "Ko"

        public static void MainMethod()
        {
            consoleEmulator = new(); // Reset Emulator
            koListe = new(); // Reset KoListe
            puma = new(); // Reset puma

            for (int i = 0; i < 4; i++)
            {
                koListe.Add(new Ko() { Name = $"Ko{i}" }); // Tilføjelse af ny Ko med navn "Ko" + i (Tal "i" i for løkken)
            }

            puma.Name = "Albert"; // Sætter name
            puma.InterfaceTestMethod("Puma Done!"); // Interface test metode
            consoleEmulator.Add($"Dyr {puma.GetId()} ({puma.GetDyrType()} - {puma.GetType().Name}) har navn: {puma.Name} og farve: {puma.Color}");


            for (int i = 125; i < 127; i++) // Tilføjelse af køer hvor navnet er "ko" + 125 til 130
            {
                koListe.Add(new Ko() { Name = $"Ko{i}" }); // Tilføjelse af ny Ko med navn "Ko" + i (Tal "i" i for løkken)
            }

            foreach (var ko in koListe)
            {
                consoleEmulator.Add($"Dyr {ko.GetId()} ({ko.GetDyrType()}) har navn: {ko.Name}");
            }
        }
    }

    internal class Ko : DyrBase<Ko>
    {
        public string? KoOnly { get; set; }
    }


    internal class Puma : Feline
    {
        public Color Color { get; } = Color.Beige;
    }
    internal class Feline : DyrBase<Feline>
    {
        public string? FelineOnly { get; set; }
    }

    abstract class DyrBase<T> : ITestInterface<string>
    {
        static int IdRef; // Static Reference til Id af "Dyr" (Bruges til "auto increment")

        protected DyrBase() // Constructor
        {
            Id = Interlocked.Increment(ref IdRef); // Id der bliver "auto incremented"

            //Type = this.GetType().Name; // Sætter Type til Navnet af classen der har nedarvet denne instance
            Type = typeof(T).Name; // Sætter Type til typen af T der er brugt i nedarvningen

            Name = String.Empty; // Default Value
        }
        private readonly int Id; // (Kun sat og hentet i denne klasse!)

        public string Name { get; set; }
        private string Type { get; set; } // Private (Kun sat og hentet i denne klasse!)

        public int GetId() => Id; // Get DyrBase Id (Tilgængelig alle steder)
        public string GetDyrType() => Type ?? "N/A"; // Get DyrBase Type (Sat a constructor) ("Unknown" hvis Type == null) (Tilgængelig alle steder)

        public void InterfaceTestMethod(string value)
        {
            Console.WriteLine(value);
        }
    }
}