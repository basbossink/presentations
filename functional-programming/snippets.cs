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

public static Func<int, Func<int,int> > Adder(int n) 
{
    return m => m + n;
}

public static Add37(int m) { return Adder(37); }

#endregion

#region Higher order functions

IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

#endregion

#region Monads

PetOwner[] petOwners = 
                    { new PetOwner { Name="Higa, Sidney", 
                          Pets = new List<string>{ "Scruffy", "Sam" } },
                      new PetOwner { Name="Ashkenazi, Ronen", 
                          Pets = new List<string>{ "Walker", "Sugar" } },
                      new PetOwner { Name="Price, Vernette", 
                          Pets = new List<string>{ "Scratches", "Diesel" } } };

IEnumerable<string> query1 = petOwners.SelectMany(petOwner => petOwner.Pets);
//alternative
IEnumerable<string> query2 = from petOwner in petOwners
                             from pet in petOwner.Pets
                             select pet
