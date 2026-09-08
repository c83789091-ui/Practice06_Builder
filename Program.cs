// Подключаем стандартную библиотеку System.
// Она нужна, чтобы пользоваться Console.WriteLine, Console.ReadKey и другими базовыми командами C#.
using System;

// Выводим на экран название практической, паттерна и выбранного варианта.
Console.WriteLine("Практическая 6. Builder. Вариант 1 - сборка компьютера.");

// Пустая строка для красоты вывода в консоли.
Console.WriteLine();

// Создаем игровой компьютер.
// new GamingPCBuilder() - это конкретный строитель, который знает комплектующие игрового ПК.
// BuildComputer(...) вызывает у строителя все шаги сборки и возвращает готовый объект Computer.
Computer gamingPc = BuildComputer(new GamingPCBuilder());

// Создаем офисный компьютер.
// Здесь используется другой строитель, поэтому комплектующие будут уже офисные.
Computer officePc = BuildComputer(new OfficePCBuilder());

// Создаем серверный компьютер.
// Здесь используется строитель серверного ПК.
Computer serverPc = BuildComputer(new ServerPCBuilder());

// Выводим заголовок для игрового компьютера.
Console.WriteLine("Игровой компьютер:");

// Выводим сам объект gamingPc.
// C# автоматически вызовет метод ToString() из класса Computer.
Console.WriteLine(gamingPc);
Console.WriteLine();

// Выводим офисный компьютер.
Console.WriteLine("Офисный компьютер:");
Console.WriteLine(officePc);
Console.WriteLine();

// Выводим серверный компьютер.
Console.WriteLine("Серверный компьютер:");
Console.WriteLine(serverPc);
Console.WriteLine();

// Сообщаем пользователю, что программа закончила работу.
Console.WriteLine("Нажмите любую клавишу для выхода...");

// Ждем нажатия клавиши, чтобы окно консоли не закрылось сразу.
Console.ReadKey();

// Это общий метод сборки компьютера.
// Он принимает не конкретный GamingPCBuilder или OfficePCBuilder, а интерфейс IComputerBuilder.
// Поэтому сюда можно передать любого строителя, если он умеет выполнять нужные шаги.
static Computer BuildComputer(IComputerBuilder builder)
{
    // Первый шаг сборки - поставить процессор.
    builder.SetProcessor();

    // Второй шаг - поставить оперативную память.
    builder.SetRam();

    // Третий шаг - поставить видеокарту.
    builder.SetVideoCard();

    // Четвертый шаг - поставить накопитель.
    builder.SetStorage();

    // После всех шагов забираем у строителя готовый компьютер.
    return builder.GetComputer();
}

// Класс Computer описывает готовый компьютер.
// Это как анкета, где хранятся характеристики компьютера.
class Computer
{
    // Поле Processor хранит название процессора.
    public string Processor = "";

    // Поле Ram хранит информацию об оперативной памяти.
    public string Ram = "";

    // Поле VideoCard хранит название видеокарты.
    public string VideoCard = "";

    // Поле Storage хранит информацию о диске или накопителе.
    public string Storage = "";

    // Метод ToString отвечает за то, как объект Computer будет выглядеть при выводе в консоль.
    // Без этого метода Console.WriteLine(computer) вывел бы не характеристики, а название класса.
    public override string ToString()
    {
        // Склеиваем все характеристики в один текст.
        // Символ \n означает переход на новую строку.
        return "Процессор: " + Processor + "\n" +
               "Оперативная память: " + Ram + "\n" +
               "Видеокарта: " + VideoCard + "\n" +
               "Жесткий диск: " + Storage;
    }
}

// Интерфейс IComputerBuilder - это общий план для всех строителей компьютеров.
// Он не говорит, какие именно детали ставить.
// Он говорит только, какие действия обязан уметь любой строитель.
interface IComputerBuilder
{
    // Метод для установки процессора.
    void SetProcessor();

    // Метод для установки оперативной памяти.
    void SetRam();

    // Метод для установки видеокарты.
    void SetVideoCard();

    // Метод для установки накопителя.
    void SetStorage();

    // Метод для получения готового компьютера.
    Computer GetComputer();
}

// GamingPCBuilder - строитель игрового компьютера.
// Он реализует интерфейс IComputerBuilder, поэтому обязан иметь все методы из интерфейса.
class GamingPCBuilder : IComputerBuilder
{
    // Внутри строителя создается пустой компьютер.
    // Потом методы ниже постепенно заполняют его деталями.
    private Computer computer = new Computer();

    // Для игрового ПК ставим мощный процессор.
    public void SetProcessor() { computer.Processor = "Intel Core i7"; }

    // Для игрового ПК ставим много быстрой оперативной памяти.
    public void SetRam() { computer.Ram = "32 GB DDR5"; }

    // Для игрового ПК ставим отдельную мощную видеокарту.
    public void SetVideoCard() { computer.VideoCard = "NVIDIA GeForce RTX 4070"; }

    // Для игрового ПК ставим быстрый SSD.
    public void SetStorage() { computer.Storage = "1 TB SSD"; }

    // Возвращаем готовый игровой компьютер.
    public Computer GetComputer() { return computer; }
}

// OfficePCBuilder - строитель офисного компьютера.
// Он собирает компьютер попроще, потому что для офиса обычно не нужна мощная видеокарта.
class OfficePCBuilder : IComputerBuilder
{
    // Создаем пустой компьютер для офисной сборки.
    private Computer computer = new Computer();

    // Ставим простой процессор.
    public void SetProcessor() { computer.Processor = "Intel Core i3"; }

    // Ставим обычный объем оперативной памяти.
    public void SetRam() { computer.Ram = "8 GB DDR4"; }

    // Для офиса достаточно встроенной графики.
    public void SetVideoCard() { computer.VideoCard = "Integrated graphics"; }

    // Ставим SSD среднего объема.
    public void SetStorage() { computer.Storage = "512 GB SSD"; }

    // Возвращаем готовый офисный компьютер.
    public Computer GetComputer() { return computer; }
}

// ServerPCBuilder - строитель серверного компьютера.
// Серверу важны надежность, память и большой объем хранения данных.
class ServerPCBuilder : IComputerBuilder
{
    // Создаем пустой компьютер для серверной сборки.
    private Computer computer = new Computer();

    // Ставим серверный процессор.
    public void SetProcessor() { computer.Processor = "AMD EPYC"; }

    // Ставим большой объем надежной серверной памяти.
    public void SetRam() { computer.Ram = "128 GB ECC"; }

    // Серверу не нужна игровая видеокарта, поэтому ставим простую графику.
    public void SetVideoCard() { computer.VideoCard = "Basic server adapter"; }

    // Ставим большое хранилище, как обычно делают на серверах.
    public void SetStorage() { computer.Storage = "4 TB RAID storage"; }

    // Возвращаем готовый серверный компьютер.
    public Computer GetComputer() { return computer; }
}
