using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        var newsChannel = new NewsChannel();

        var subscriber1 = new Subscriber("Иван");
        var subscriber2 = new Subscriber("Анна");

        newsChannel.Subscribe(subscriber1);
        newsChannel.Subscribe(subscriber2);

        newsChannel.AddNews("Запуск нового смартфона!");

        newsChannel.Unsubscribe(subscriber1);

        newsChannel.AddNews("Новая версия приложения доступна для загрузки!");
    }
}
public interface ISubscriber
{
    void Update(string news);
}
public interface IPublisher
{
    void Subscribe(ISubscriber subscriber);
    void Unsubscribe(ISubscriber subscriber);
    void Notify(string news);
}
public class NewsChannel : IPublisher
{
    private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
        Console.WriteLine("Подписчик был добавлен.");
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
        Console.WriteLine("Подписчик был удален.");
    }

    public void Notify(string news)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(news);
        }
    }

    public void AddNews(string news)
    {
        Console.WriteLine($"Новая новость: {news}");
        Notify(news);
    }
}
public class Subscriber : ISubscriber
{
    private readonly string _name;

    public Subscriber(string name)
    {
        _name = name;
    }

    public void Update(string news)
    {
        Console.WriteLine($"Подписчик {_name} получил новость: {news}");
    }
}
