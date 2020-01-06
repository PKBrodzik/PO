# Introduction to lesson 12

To discuss the decorator pattern we will  again use a coffee machine example.
There are many ideas for designing an application architecture to simulate a coffee machine without the decorator pattern, but let's take the following approach as a base.

The machine has a list of defined drinks (coffee, cappuccino, chocolate, etc) and a number of additives (milk, sugar (maybe double), etc.).

Let's assume that our base class for drinks will be an abstract base class Napoj, which may look like this:


```csharp
public abstract class Napoj
    {
		 // beverage description
        public string Opis { get { return this._opis; } }
		 // beverage cost
        public double Koszt { get { return this._koszt; } }
        protected string _opis;
        protected double _koszt;

        public Napoj(string opis, double koszt)
        {
            this._opis = opis;
            this._koszt = koszt;
        }
    }
```
There are no additives in this example that can be stored in the form of boolean fields (e.g. withMilk, decaffeinated, etc.):

```csharp
public abstract class Napoj
    {
        public string Opis { get { return this._opis; } }
        public double Koszt { get { return this._koszt; } }
        protected string _opis;
        protected double _koszt;
		// milk
        protected bool mleko = false;
		// sugar
        protected bool cukier = false;
        // etc...
    }
```
The implementation of specific drink classes can look like this:
```csharp
class Espresso : Napoj
    {
        public Espresso()
        {
            this._opis = "Italian espresso!";
            this._koszt = 1.50;
        }
    }

	// coffee with milk
    class KawaZMlekiem : Napoj
    {
        public KawaZMlekiem()
        {
            this._opis = "Classic coffee with milk";
            this.mleko = true;
            this._koszt = 2.00;
			// now we need to calculate the overall cost with all the optional additives
			// it could be a good idea to move it to a separate method
            if (this.mleko)
            {
                this._koszt += 0.50;
            }
            else if (this.cukier)
            {
                this._koszt += 0.10;
            }
        }
    }
```
Now we can create one drink to test the code:
```csharp
class Program
    {
        static void Main(string[] args)
        {
            Napoj kawa = new KawaZMlekiem();
            Console.WriteLine(kawa.Opis + " costs: " + $"{kawa.Koszt}");
            Console.ReadKey();
        }
    }
```

Let's draw conclusions from above solution:
1. The number of classes that we will have to define will be very large (the so-called "class explosion" effect), where almost all combinations of drinks and additives will have to be taken into account (e.g. BlackCoffeeWithSugar, CoffeeWithMilkAndSugar, etc.).
2. If a new addition is needed, e.g. chocolate, cane sugar or lactose-free milk, we will have to modify the code in each drink class!
3. Changing the price of the additive will require the modification of a large amount of code.
4. Additives can be stored using a collection, but this would require a defined name  and the price of the additive. Here we could
create a new abstract class "Addition", which would include its name and price, which would significantly reduce the cost of maintaining the code and the scope of changes needed when new additions appear. 

# 1. Open-closed principle (OCP)

This is one of the most important rules for designing applications using object-based techniques.
This rule is a part of the set of rules that are found under the acronym SOLID.
You can read more here:

* [About SOLID rules](https://www.samouczekprogramisty.pl/solid-czyli-dobre-praktyki-w-programowaniu-obiektowym/)
* [OPEN-CLOSED - about "O" from SOLID acronym](https://blog.helion.pl/mnemonik-solid-o-openclosed-principle/)
* [More about an OPEN-CLOSED rule](https://www.modestprogrammer.pl/solid-open-closed-principle-ocp-wszystko-co-powinienes-wiedziec-o-zasadzie-otwarte-zamkniete)

"Classes should be open for expansion, but closed for modification." It's about expanding the classes by adding new behaviors, but without having to modify their code.
It is not possible in practice to apply this rule to every area of the application and probably also too time-consuming and therefore expensive. However, there are areas where
this rule very quickly gives  measurable benefits for designers and coders working on the project.


# 2. The Decorator pattern

The pattern took its name from the way a subsequent objects are added to the final, decorated object.
Subsequent objects "decorate" previous objects in the chain - starting with the base drink and ending with all subsequent additions.
Using the delegation mechanism, we complete the cost of the drink from the cost of the base drink and all additions.
For example, the base object Coffee is decorated with the Milk object, then with the Chocolate object and we get the final decorated object.
An important element of the pattern is that the decorators are objects of the same type as the objects that are decorated.

We start by defining the Napoj class, slightly modified from the previous version:

```csharp
public abstract class Napoj
    {
        public abstract double Koszt();
        public abstract string GetOpis();
    }
```

A specific drink may look like this:

```csharp
public class Kawa : Napoj
    {
        public override double Koszt()
        {
            return 2.00;
        }

        public override string GetOpis()
        {
            return "Czarna kawa";
        }
    }
```

Now it's time for a basic class for decorators (also inherited from the same type):

```csharp
public abstract class NapojDekorator : Napoj
    {
        protected Napoj napoj;
        public NapojDekorator(Napoj _napoj)
        {
            napoj = _napoj;
        }

        public override string GetOpis()
        {
            return napoj.GetOpis();
        }

        public override double Koszt()
        {
            return napoj.Koszt();
        }
    }
```

And a specific decorator:

```csharp
// milk class
class Mleko : NapojDekorator
    {
        public Mleko(Napoj _napoj):base(_napoj)
        {
        }

         // we are changing the way that the price is calculated
        public override double Koszt()
        {
            return 0.50 + napoj.Koszt();
        }

        // and the description
        public override string GetOpis()
        {
            return napoj.GetOpis() + ", Mleko";
        }
    }

// chocolate class
class Czekolada : NapojDekorator
    {

        public Czekolada(Napoj _napoj):base(_napoj)
        {
        }

        // we are changing the way that the price is calculated
        public override double Koszt()
        {
            return 0.80 + napoj.Koszt();
        }

        // and the description
        public override string GetOpis()
        {
            return napoj.GetOpis() + ", Czekolada";
        }
    }
```

Note the overload of Koszt() and GetOpis() methods for drinks and decorators.
Time to test the code.

```csharp
Napoj nowaKawa = new Kawa();
Console.WriteLine(nowaKawa.GetOpis() + " costs: " + $"{nowaKawa.Koszt()}");

// adding some milk
nowaKawa = new Mleko(nowaKawa);
Console.WriteLine(nowaKawa.GetOpis() + " costs: " + $"{nowaKawa.Koszt()}");

// and chocolate
nowaKawa = new Czekolada(nowaKawa);
Console.WriteLine(nowaKawa.GetOpis() + " costs: " + $"{nowaKawa.Koszt()}");
```

Console output is as follows:

```console
Czarna kawa costs: 2
Czarna kawa, Mleko costs: 2,5
Czarna kawa, Mleko, Czekolada costs: 3,3
```

