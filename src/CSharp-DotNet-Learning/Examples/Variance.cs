namespace Examples;

public class Variance
{
    public void Examples()
    {
        // 1. rule of substitutability
        var cat = new Cat();
        var animal = new Animal();
        animal = cat; // all cats are animals
        // cat = animal; // impossible! not all animals are cats -- only cats are cats!

        // 2. rule of covariance
        IEnumerable<Cat> listOfCats = new List<Cat>();
        IEnumerable<Animal> listOfAnimals = new List<Animal>();
        listOfAnimals = listOfCats; // a list of animals, can include cats
        // listOfCats = listOfAnimals; // impossible! we cannot add any kind of animal to the list of cats -- only cats!

        // 3. rule of contra-variance
        var playWithCat = new Action<Cat>(c => c.Mew());
        var playWithAnimal = new Action<Animal>(_ => { });
        playWithCat = playWithAnimal; // who can play with a cat, knows how to play with an animal too!
        // playWithAnAnimal = playWithACat; // impossible! not all animals can mew like a cat, for instance!

        // 4. rule of substitutability
        playWithCat(cat);
        // playWithCat(animal); // not all animals are cats -- cats are cats!
        playWithAnimal(animal);
        playWithAnimal(cat); // all cats are animals

        // 5. rule of contra-variance
        PlayWithCat(playWithCat);
        PlayWithCat(playWithAnimal); // who can play with an animal (playWithAnimal), plays with a cat like an animal!
        // PlayWithAnimal(playWithCat); // impossible! a cat player (playWithCat) might ask an animal to mew!
        PlayWithAnimal(playWithAnimal);
    }

    public void PlayWithCat(Action<Cat> catAction) => catAction(new Cat());

    public void PlayWithAnimal(Action<Animal> animalAction) => animalAction(new Animal());

    public class Animal;

    public class Cat : Animal
    {
        public void Mew()
        {
        }
    }

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
}