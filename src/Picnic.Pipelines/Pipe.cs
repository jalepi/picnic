namespace Picnic.Pipelines;

public static class Pipe
{
    public static IPipe<T, T> Of<T>() => new FuncPipe<T, T>(static x => x);

    public static IPipe<T, S> Connect<T, R, S>(this IPipe<T, R> source, Func<R, S> func)
    {
        return new FuncPipe<T, S>(x => x.Pipe(source.Send).Pipe(func));
    }

    private sealed class FuncPipe<T, R> : IPipe<T, R>
    {
        private readonly Func<T, R> _func;
        public FuncPipe(Func<T, R> func) => _func = func;
        public R Send(T input) => _func(input);
    }
}

public interface IPipe<in T, out R>
{
    R Send(T input);
}
