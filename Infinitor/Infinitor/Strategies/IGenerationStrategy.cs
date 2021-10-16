namespace Infinitor.Strategies
{
    public interface IGenerationStrategy<out T>
    {
        T Generate(int randomNumber);
    }
}