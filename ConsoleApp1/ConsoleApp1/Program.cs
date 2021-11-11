/* 
    Шейбак Дарья, гр3 курс 2, ИСИТ
   
    1) Создать заданный в варианте класс. Определить в классе необходимые методы, конструкторы, индексаторы и заданные перегруженные операции. 
    Написать программу тестирования, в которой проверяется использование перегруженных операций.
    2) Добавьте в свой класс вложенный объект Owner, который содержит Id, имя и организацию создателя. Проинициализируйте его.
    3) Добавьте в свой класс вложенный класс Date (дата создания). Проинициализируйте.
    4) Создайте статический класс StatisticOperation, содержащий 3 метода для работы с вашим классом (по варианту п.1): сумма, разница между максимальным и минимальным, подсчет количества элементов. 
    5) Добавьте к классу StatisticOperation методы расширения для типа string и вашего типа из задания№1. См. задание по вариантам.
    
    в.22
    Класс - очередь Queue. Дополнительно перегрузить следующие операции: 
    / - добавить элемент; 
    ++ - извлечь элемент; 
    false - проверка, на содержание четных элементов в очереди; 
    явный int() - количество положительных элементов в очереди;

Методы расширения:
1) Выделение первого числа, содержащегося в строке
2) Обнуление отрицательных элементов очереди

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            // протестируем клаcc Queue

            Queue MyQueue = new Queue();

            /* тестируем неперегруженный функционал - стандартные методы
            MyQueue.pushQueue(194);
            MyQueue.pushQueue(-8);
            MyQueue.pushQueue(21);
            MyQueue.pushQueue(505);

            MyQueue.printQueue(); // выведем очередь на консоль

            if (MyQueue.PresenceEven()) Console.WriteLine("В очереди есть четные элементы");
            else Console.WriteLine("В очереди нет четных элементов");

            Console.WriteLine("Количество положительных элементов в очереди : {0}", MyQueue.CulcPos());

            Console.WriteLine("Извлечем из очереди элемент очереди : {0}", MyQueue.popQueue());
            Console.WriteLine("Извлечем из очереди элемент очереди : {0}", MyQueue.popQueue());

            MyQueue.printQueue(); // выведем очередь на консоль
            */

            MyQueue = MyQueue / 194;
            MyQueue = MyQueue / -8;
            MyQueue = MyQueue / 21;
            MyQueue = MyQueue / 505;

            MyQueue.printQueue(); // выведем очередь на консоль

            if (MyQueue) Console.WriteLine("В очереди есть четные элементы");
            else Console.WriteLine("В очереди нет четных элементов");

            Console.WriteLine("Количество положительных элементов в очереди : {0}", (int)MyQueue);

            Console.WriteLine("\n-- извлечем из очереди два элемента");
            MyQueue = MyQueue++;
            MyQueue = MyQueue++;

            MyQueue.printQueue(); // выведем очередь на консоль

            if (MyQueue) Console.WriteLine("В очереди есть четные элементы");
            else Console.WriteLine("В очереди нет четных элементов");

            Console.WriteLine("Количество положительных элементов в очереди : {0}", (int)MyQueue);

            Console.WriteLine("\n-- извлечем из очереди оставшиеся два элемента");
            MyQueue = MyQueue++;
            MyQueue = MyQueue++;

            MyQueue.printQueue(); // выведем очередь на консоль

            // протестируем дату создания и владельца очереди

            Console.WriteLine("Очередь создана (дата) : {0}", MyQueue.CreationDate.day);
            Console.WriteLine("Информация о владельце очереди : ID {0} {1} {2}", MyQueue.qowner.ID, MyQueue.qowner.name, MyQueue.qowner.organisation);

            // протестируем статический класс StatisticOperation
            Console.WriteLine("\n-- протестируем статический класс StatisticOperation - занесем в очередь четыре элемента");
            MyQueue = MyQueue / 8;
            MyQueue = MyQueue / -2;
            MyQueue = MyQueue / 11;
            MyQueue = MyQueue / 9;
            MyQueue = MyQueue / 23;

            MyQueue.printQueue(); // выведем очередь на консоль
            Console.WriteLine("Сумма значений элементов : {0}", StatisticOperation.QSUM(MyQueue));
            Console.WriteLine("Разница между максимальным и минимальным значением элементов : {0}", StatisticOperation.DIFF_MAX_MIN(MyQueue));
            Console.WriteLine("Количество элементов : {0}", StatisticOperation.QPOWER(MyQueue));
            //
            String someStr = "This building will have 5 or 9 or  levels";
            int first_number = someStr.firstNumber(MyQueue);
            if (first_number == -1) Console.WriteLine("Ни один из элементов очереди не содержится в строке '{0}'", someStr);
            else Console.WriteLine("Первое число (элемент очереди), содержащееся в строке '{0}' : {1}", someStr, first_number);
            //
            Console.WriteLine("\n-- при помощи метода расширения обнулим отрицательные элементы очереди");
            someStr.zeroNegatives(MyQueue);
            MyQueue.printQueue(); // выведем очередь на консоль


            Console.ReadKey();

        }
    }
}
