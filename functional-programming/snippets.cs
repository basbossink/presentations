#region Type inference

var list = new List<double>()

#endregion

#region Function composition

public static Func<T, V> Compose<T, V>(this Func<U,V> f, Func<T, U> g)
{
    return x => f(g(x));
}

var r = f.Compose(g)(x)

#endregion

#region Anonymous functions

public static IEnumerable<T> Cubes(IEnumerable<T> source) > 
{
    return source.Select(x => x * x * x);
}

#endregion

