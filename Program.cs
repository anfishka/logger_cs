/*
Создать класс Logger с методом Start() (пишет в файл каждую секундку своей жизни) до тех пор пока создан его экземпляр

Предусмотреть ввод пользователем пути сохранения лог-файла / Предоставить удобное меню с выбором вариантов по пути (или стандартный или пользовательский)
при старте ПО

Разбить проект на 2 логгера в отдельных пространствах имен ( по пути)
 */

using  LoggerNamespace1;
using  LoggerNamespace2;


LoggerNamespace1.Logger1 sysLog = null;
Thread sysThread = null;
LoggerNamespace2.Logger2 customLog = null;
Thread customThread = null;


Console.WriteLine("Select log file path option -> ");
Console.WriteLine("1. Use default path");
Console.WriteLine("2. Enter custom path");

string choice  = Console.ReadLine();
string logFilePath;


if (choice == "1")
{
    sysLog = new Logger1();
    sysThread = new Thread(() => sysLog.Start("Thread 1"));
    sysThread.Start();
}
else if (choice == "2")
{
    Console.WriteLine("Enter custom log file path ->");
    logFilePath = Console.ReadLine();
    customLog = new Logger2(logFilePath);
    customThread = new Thread(() => customLog.Start("Thread 2"));
    customThread.Start();
}
else
{
    Console.Write("Error!");
}

Console.WriteLine("Prress any key to stop logger");
Console.ReadKey();

customLog?.Stop();
sysLog?.Stop();
customThread?.Join();
sysThread?.Join();
