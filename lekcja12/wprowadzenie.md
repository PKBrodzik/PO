# Wstęp do lekcji 12

Dla omówienia wzorca dekorator wykorzystany zostanie ponownie przykład z automatem do kawy.
Pomysłów na zaprojektowanie architektury aplikacji symulującej pracę takiego automatu bez wykorzystania wzorca dekorator jest wiele, ale przyjmijmy poniższe podejście jako bazowe.

Automat posiada listę zdefiniowanych napojów (kawa, cappuccino, czekolada) oraz szereg dodatków (mleko, cukier (może podwójny), itp.).

Przyjmijmy, że naszą klasą bazową dla napojów będzie abstrakcyjna klasa bazowa Napój, która może wyglądać tak:

```csharp
public abstract class Napoj
    {
        public string Opis { get { return this._opis; } }
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
Nie ma tutaj uwzględnionych dodatków, które można przechowywać w postaci pól boolowskich (np. zMlekiem, bezkofeinowa itp.):

```csharp
public abstract class Napoj
    {
        public string Opis { get { return this._opis; } }
        public double Koszt { get { return this._koszt; } }
        protected string _opis;
        protected double _koszt;
        protected bool mleko = false;
        protected bool cukier = false;
        // itd...
    }
```
Implementacja konkretnych klas napojów może wyglądać tak:
```csharp
class Espresso : Napoj
    {
        public Espresso()
        {
            this._opis = "Espresso w stylu włoskim!";
            this._koszt = 1.50;
        }
    }

    class KawaZMlekiem : Napoj
    {
        public KawaZMlekiem()
        {
            this._opis = "Klasyczna kawa z mlekiem";
            this.mleko = true;
            this._koszt = 2.00;
            // teraz trzeba by policzyć koszt napoju uwzględniając wszystkie dodatki
			// widać, że dobrym pomysłem byłoby przeniesienie obliczania kosztu do oddzielnej metody
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
Teraz możemy stworzyć testowo jeden napój:
```csharp
class Program
    {
        static void Main(string[] args)
        {
            Napoj kawa = new KawaZMlekiem();
            Console.WriteLine(kawa.Opis + " kosztuje: " + $"{kawa.Koszt}");
            Console.ReadKey();
        }
    }
```

Wyciągnijmy wnioski z takiego rozwiązania:
1. Ilość klas, które będziemy musieli zdefiniować będzie bardzo duża (tzw. efekt "eksplozji klas"), gdzie trzeba będzie wziąć pod uwagę prawie wszystkie kombinacje napojów i dodatków (np. KawaCzarnaZCukrem, KawaZMlekiemICukrem).
2. Jeżeli pojawi się nowy dodatek, np. czekolada, albo cukier trzcinowy czy mleko bez laktozy, trzeba będzie dokonać modyfikacji kodu w każdej klasie napoju !
3. Zmiana ceny dodatku spowoduje konieczność modyfikacji dużej ilości kodu.
4. Dodatki można przechowywać w klasach dziedziczących po klasie Napoj w kolekcji, ale to wymagałoby zdefiniowana w jakiś sposób nazwy dodatku, ceny. Tutaj moglibyśmy
stworzyć nową klasę abstrakcyjną Dodatek, która zawierałaby jego nazwę i cenę co znacznie zmniejszyłoby koszt utrzymania kodu i zakres zmian niezbędnych do wprowadzenia w kodzie
przy pojawieniu się nowych dodatków. 

# 1. Reguła otwarte-zamknięte (Open-closed principle, akronim OCP)

Jest to jedna z najważniejszych reguł projektowania aplikacji z wykorzystaniem technik obiektowych.
Ta reguła jest częścią zbioru reguł występujących pod akronimem SOLID.
Więcej można doczytać m.in. tu:

* [O zbiorze reguł SOLID](https://www.samouczekprogramisty.pl/solid-czyli-dobre-praktyki-w-programowaniu-obiektowym/)
* [Reguła OPEN-CLOSED czyli "O" z reguł SOLID](https://blog.helion.pl/mnemonik-solid-o-openclosed-principle/)
* [Jeszcze trochę o OPEN-CLOSED](https://www.modestprogrammer.pl/solid-open-closed-principle-ocp-wszystko-co-powinienes-wiedziec-o-zasadzie-otwarte-zamkniete)

"Klasy powinny być otwarte na rozbudowę, ale zamknięte na modyfikacje." Chodzi tutaj o rozbudę wklas poprzez dodanie im nowych zachowań, ale bez konieczności modyfikacji ich kodu.
Nie jest w praktyce możliwe zastosowanie tej reguły dla każdego obszaru aplikacji i zapewne też zbyt czasochłonne i co za tym idzie kosztowne. Są jednak takie obszary, gdzie
ta reguła daje bardzo szybko wymierne korzyści dla projektantów i koderów pracujących nad projektem.


# 2. Wzorzec dekorator

Wzorzec przyjął swoją nazwę od sposobu w jaki kolejne obiekty są dodawane, aż do momentu osiągnięcia finalnego, udekorowanego obiektu.
Kolejne dodawane obiekty "dekorują" poprzednie obiekty w łańcuchu - poczynając od napoju bazowego porzez wszystkie kolejne dodatki.
Korzystając z mechanizmu delegacji kompletujemy koszt napoju z kosztu napoju bazowego oraz wszystkich dodatków.
Np. obiekt bazowy Kawa dekorowany jest obiektem Mleko, następnie obiektem Czekolada i otrzymujemy finalny udekorowany obiekt.
Ważnym elementem wzorca jest to, że dokoratory są obiektami tego samego typu co obiekty, które są dekorowane.

Zaczynamy od zdefiniowania klasy Napoj, trochę zmodyfikowanej względem poprzedniej wersji:

```csharp
public abstract class Napoj
    {
        public abstract double Koszt();
        public abstract string GetOpis();
    }
```

Konkretny napój może wyglądać następująco:

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

Teraz pora na bazową klasę dla dekoratorów (też dziedziczący po tym samym typie):

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

I konkretny dekorator:

```csharp
class Mleko : NapojDekorator
    {
        public Mleko(Napoj _napoj):base(_napoj)
        {
        }

        // zmieniamy sposób obliczania kosztu
        public override double Koszt()
        {
            return 0.50 + napoj.Koszt();
        }

        // oraz opis
        public override string GetOpis()
        {
            return napoj.GetOpis() + ", Mleko";
        }
    }

class Czekolada : NapojDekorator
    {

        public Czekolada(Napoj _napoj):base(_napoj)
        {
        }

        // zmieniamy sposób obliczania kosztu
        public override double Koszt()
        {
            return 0.80 + napoj.Koszt();
        }

        // oraz opis
        public override string GetOpis()
        {
            return napoj.GetOpis() + ", Czekolada";
        }
    }
```

Zwróć uwagę na przeciążenie metod Koszt() oraz GetOpis() dla napojów oraz dekoratorów.
Pora na przetestowanie kodu.

```csharp
// teraz przykład z wykorzystaniem wzorca dekorator
Napoj nowaKawa = new Kawa();
Console.WriteLine(nowaKawa.GetOpis() + " kosztuje: " + $"{nowaKawa.Koszt()}");

// dodajemy mleko
nowaKawa = new Mleko(nowaKawa);
Console.WriteLine(nowaKawa.GetOpis() + " kosztuje: " + $"{nowaKawa.Koszt()}");

// i czekoladę
nowaKawa = new Czekolada(nowaKawa);
Console.WriteLine(nowaKawa.GetOpis() + " kosztuje: " + $"{nowaKawa.Koszt()}");
```

A wynik w konsoli wygląda następująco:

```console
Czarna kawa kosztuje: 2
Czarna kawa, Mleko kosztuje: 2,5
Czarna kawa, Mleko, Czekolada kosztuje: 3,3
```

