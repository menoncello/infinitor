namespace Infinitor.Factories
{
    public interface IRandomFactory<out T>
    {
        T Generate(int randomValue);
    }
}