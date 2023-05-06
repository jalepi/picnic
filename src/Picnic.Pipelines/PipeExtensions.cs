namespace Picnic.Pipelines;

public static partial class PipeExtensions
{
    public static R Pipe<T, R>(this T source, Func<T, R> func)
    {
        return func(source);
    }
}