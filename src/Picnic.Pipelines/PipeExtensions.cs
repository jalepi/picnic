namespace Picnic.Pipelines;

public static class PipeExtensions
{
    public static R Pipe<T, R>(this T source, Func<T, R> func)
    {
        return func(source);
    }
}