using System;

namespace lekcja4
{
    interface IObservable
    {
        void RegisterObserver(IObserver observer);
        void UnregisterObserver(IObserver observer);
        void NotifyObservers();
    }
}
