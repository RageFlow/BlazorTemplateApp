namespace BlazorTemplateApp.Pages.ObjectExample
{
    internal interface ITestInterface<T>
    {
        void InterfaceTestMethod(T value);
    }

    internal enum Color
    {
        White,
        Black,
        Gray,
        Silver,
        Red,
        Blue,
        Brown,
        Green,
        Beige,
        Orange,
        Gold,
        Yellow,
        Purple
    }
}