namespace Examples.Variance;

// For more info, see below pages
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/creating-variant-generic-interfaces

interface ICovariant<out R>
{
    // void AsTypeConstraint<T>() where T : R; // not possible 
    R MethodReturnTypeDirectly();
    void MethodArgumentTypeAsActionInputType(Action<R> callback);

    Func<R> MethodReturnTypeAsFunctionReturnType();
    // void MethodArgumentTypeDirectly(R arg); // not possible
    // void MethodArgumentTypeAsFunctionReturnType(Func<R> action); // not possible
    // Action<R> MethodReturnTypeAsActionInputType(); // not possible
}

interface IContravariant<in A>
{
    void AsTypeConstraint<T>() where T : A;

    // A MethodReturnTypeDirectly(); // not possible
    // void MethodArgumentTypeAsActionInputType(Action<A> callback); // not possible
    // Func<A> MethodReturnTypeAsFunctionReturnType(); // not possible
    void MethodArgumentTypeDirectly(A arg);
    void MethodArgumentTypeAsFunctionReturnType(Func<A> action);
    Action<A> MethodReturnTypeAsActionInputType();
}