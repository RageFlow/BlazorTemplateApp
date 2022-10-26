namespace BlazorTemplateApp.Pages.ObjectOrientedProgramming
{
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