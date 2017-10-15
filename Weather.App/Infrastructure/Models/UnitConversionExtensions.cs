namespace Weather.App.Infrastructure.Models
{
    public static class UnitConversionExtensions
    {
        public static double FahrenheitToCelcius(this double fahrenheit)
        {
            double magicNumber = 0.5556d;
            return (fahrenheit - 32) * magicNumber;
        }
    }
}
