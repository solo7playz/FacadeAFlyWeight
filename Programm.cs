using System;
using System.Collections.Generic;
public class FlowerType
{
    public string Name { get; }
    public string PetalColor { get; }
    public string LeafTexture { get; }

    public FlowerType(string name, string petalColor, string leafTexture)
    {
        Name = name;
        PetalColor = petalColor;
        LeafTexture = leafTexture;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Flower: {Name}, Petal Color: {PetalColor}, Leaf Texture: {LeafTexture}");
    }
}
public class FlowerFactory
{
    private readonly Dictionary<string, FlowerType> _flowerTypes = new Dictionary<string, FlowerType>();

    public FlowerType GetFlowerType(string name, string petalColor, string leafTexture)
    {
        string key = $"{name}-{petalColor}-{leafTexture}";

        if (!_flowerTypes.TryGetValue(key, out var flowerType))
        {
            flowerType = new FlowerType(name, petalColor, leafTexture);
            _flowerTypes[key] = flowerType;
            Console.WriteLine($"Создан новый тип цветка: {key}");
        }
        else
        {
            Console.WriteLine($"Используется существующий тип цветка: {key}");
        }

        return flowerType;
    }
}
public class Flower
{
    public float X { get; }
    public float Y { get; }
    public float Height { get; }
    public FlowerType FlowerType { get; }

    public Flower(float x, float y, float height, FlowerType flowerType)
    {
        X = x;
        Y = y;
        Height = height;
        FlowerType = flowerType;
    }

    public void Display()
    {
        Console.WriteLine($"Flower at ({X}, {Y}), Height: {Height}");
        FlowerType.DisplayInfo();
    }
}
public class Garden
{
    public static void Main(string[] args)
    {
        FlowerFactory flowerFactory = new FlowerFactory();
        Flower rose1 = new Flower(1.0f, 2.0f, 15.0f, flowerFactory.GetFlowerType("Rose", "Red", "Smooth"));
        Flower rose2 = new Flower(1.5f, 2.5f, 16.0f, flowerFactory.GetFlowerType("Rose", "Red", "Smooth"));
        Flower tulip1 = new Flower(2.0f, 3.0f, 10.0f, flowerFactory.GetFlowerType("Tulip", "Yellow", "Rough"));
        Flower daisy1 = new Flower(3.0f, 4.0f, 8.0f, flowerFactory.GetFlowerType("Daisy", "White", "Soft"));
        rose1.Display();
        rose2.Display();
        tulip1.Display();
        daisy1.Display();
    }
}