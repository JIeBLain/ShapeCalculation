# Задание от Mindbox
## 1. Внешняя библиотека для расчёта площади фигур
Создан интерфейс `IShape`, который имеет контракт на вычисление площади фигуры `CalculateArea` и получения её названия `Name`.
Он реализован в моделях: `Circle` и `Triangle` и соответственно устанавливает логику расчёта площади конкретной фигуры.
В классе `Triangle` реализовано свойство `IsRight`, которое проверяет является ли текущий треуголник - прямоугольным.
Также в конструкторе данного класса есть проверка на корректность введённых сторон треугольника и сообщение об ошибке,
если это не так, путем выброса исключения `InvalidTriangleException`.

Для подсчёта площади конкретной фигуры, можно вызвать метод через её объект.
```csharp
var triangle = new Triangle(3, 4, 5);
var triangleArea = triangle.CalculateArea();
```
Если же мы хотим вычислить площадь фигуры без знания её типа, нам необходимо использовать интерфейс `IShape`.
Например:
```csharp
var shapes = new List<IShape>
{
    new Triangle(3, 4, 5),
    new Circle(10),
    new Circle(5),
    new Triangle(8, 8, 9)
};

foreach (var shape in shapes)
{
    var area = shape.CalculateArea();
    Console.WriteLine($"{shape.Name} area is {area}");
}
```

## 2. SQL запрос для выбора всех пар "Имя продукта - Имя категории"
```sql
SELECT p.Name AS 'Product', c.Name AS 'Category'
FROM Products p
LEFT JOIN ProductCategories pc ON  p.Id = pc.ProductId
LEFT JOIN Categories c ON c.Id = pc.CategoryId
```