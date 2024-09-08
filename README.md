# DataSerializer
A library for serializing and deserializing objects of arbitrary classes into CSV format using reflection in C#. The project demonstrates the capabilities of reflection for working with data of any type, and also provides a comparison of the performance of a custom solution with popular standard serialization mechanisms such as Newtonsoft.Json.

## Результаты замеров сериализации

| Сериализатор               | Операция         | Количество итераций | Время (мс) |
|----------------------------|------------------|---------------------|------------|
| **Custom serialization**   | Сериализация     | 100000              | 94         |
| **Custom serialization**   | Десериализация   | 100000              | 127        |
| **Newtonsoft.Json**        | Сериализация     | 100000              | 260        |
| **Newtonsoft.Json**        | Десериализация   | 100000              | 123        |
| **Custom serialization**   | Сериализация     | 10000               | 49         |
| **Custom serialization**   | Десериализация   | 10000               | 24         |
| **Newtonsoft.Json**        | Сериализация     | 10000               | 210        |
| **Newtonsoft.Json**        | Десериализация   | 10000               | 24         |
| **Custom serialization**   | Сериализация     | 1000                | 1          |
| **Custom serialization**   | Десериализация   | 1000                | 4          |
| **Newtonsoft.Json**        | Сериализация     | 1000                | 147        |
| **Newtonsoft.Json**        | Десериализация   | 1000                | 21         |