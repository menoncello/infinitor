namespace Infinitor
{
    public interface IRandomFactory<out T>
        where T: class
    {
        T Generate(int randomValue);
    }
}