using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Очередь - одномерная структура данных, для которой загрузка и извлечение элементов осуществляется
 с помо-щью указателей начала извлечения (head) и конца (tail) очереди в соответствии с правилом 
 FIFO ("FIFO" - "первым введен, первым выведен"), т. е. включение производится с одного, а исключение – с другого конца.

*/

public class Queue
{
    // вложенный класс
    public class Date   
    {

        private DateTime date;

        public Date() // конструктор
        {
            date = DateTime.Today; // присваиваем текущую дату
        }

        // определим для члена date специальные методы доступа - Свойства - они обеспечивают простой доступ к полям классов и структур, позволяют узнать их значение или выполнить их установку
        public DateTime day      // свойство для даты
        {

            get { return date; }

            set { date = value; }

        }

    }

    // вложенный объект 
    public struct Owner
    {
        public int ID;         // ID создателя очереди
        public String name;    // Имя создателя очереди
        public String organisation;    // Организация создателя очереди
    };

    // реализация очереди

    public class QNode    // элемент очереди
    {
        public int value;   // данные элемента очереди                               
        public QNode next;  // следующий элемент очереди
    };

    public QNode head;  // вершина очереди
    public int QueueSize; // текущая размерность очереди (кол-во элементов очереди)
    public Date CreationDate; // дата создания очереди
    public Owner qowner; // информация о владельце очереди

    public Queue() // конструктор
    {
        // инициализируем члены-данные Очереди
        head = null;
        QueueSize = 0;
        // отмечаем дата создания очереди
        CreationDate = new Date();
        // заносим информацию о владельце очереди
        qowner = new Owner();
        qowner.ID = 100;
        qowner.name = "Шейбак Дарья";
        qowner.organisation = "БГТУ, ФИТ";
    }

    public void pushQueue(int ival)
    {
        /* постановка элемента в конец очереди */

        if (head == null) // очередь пуста - новый элемент становится первым элементом очереди
        {

            head = new QNode(); // создаем новый элемент

            head.value = ival;

            head.next = null;
        }

        else // очередь непуста
        {

            // переходим на последний элемент очереди:
            QNode tailnode = head;
            while (tailnode.next != null) tailnode = tailnode.next;

            // присоединяем новый элемент
            tailnode.next = new QNode(); // создаем новый элемент
            tailnode.next.value = ival;
            tailnode.next.next = null;

        }

        QueueSize++; // инкрементируем счетчик количества элементов очереди
    }

    public int popQueue()
    {
        /* извлечение элемента с начала очереди */

        int ret_val;

        if (head == null) // очередь пуста
        {

            ret_val = 0; // всегда возвращаем 0 в случае пустой очереди

        }

        else // очередь непуста
        {

            ret_val = head.value; // возвращаемое значение начального элемента

            // смещаем вершину очереди
            if (head.next == null) head = null; // в очереди был ровно один элемент - опустошили очередь

            else
            {
                head = head.next; // вычитали элемент - смещаем вершину очереди

            }

        }

        QueueSize--; // декрементируем счетчик количества элементов очереди

        return ret_val;
    }

    public int getQueueSize()
    {
        /* возвращает размерность очереди (кол-во элементов очереди) */

        return QueueSize;

    }

    public void printQueue()
    {
        /* вывод элементов очереди на консоль */

        Console.WriteLine();

        if (getQueueSize() == 0) Console.Write("Очередь пуста.");

        else // очередь непуста
        {

            // проходим от начала до конца очереди, выводя ее элементы:
            QNode tailnode = head;

            do
            {
                Console.Write("{0} ", tailnode.value);

                tailnode = tailnode.next;

            } while (tailnode != null);

        } // очередь непуста

        Console.WriteLine();

    }

    public bool PresenceEven()
    {
        /* проверка на содержание четных элементов в очереди */

        bool ret_val = false;

        if (getQueueSize() == 0) ret_val = false; // очередь пуста

        else // очередь непуста
        {

            // проходим от начала до конца очереди, выводя ее элементы:
            QNode tailnode = head;

            do
            {
                if (tailnode.value % 2 == 0)
                {

                    ret_val = true;

                    break; // from while()

                }

                tailnode = tailnode.next;

            } while (tailnode != null);

        } // очередь непуста

        return ret_val;

    }

    public int CulcPos()
    {
        /* подсчет количества положительных элементов в очереди */

        int qpos = 0; // счетчик количества положительных элементов в очереди

        if (getQueueSize() == 0) qpos = 0; // очередь пуста

        else // очередь непуста
        {

            // проходим от начала до конца очереди, выводя ее элементы:
            QNode tailnode = head;

            do
            {
                if (tailnode.value >= 0) qpos++;

                tailnode = tailnode.next;

            } while (tailnode != null);

        } // очередь непуста


        return qpos;

    }

    /* перегрузим требуемые в условии задания операторы

    / - добавить элемент; 
    ++ - извлечь элемент; 
    false - проверка, на содержание четных элементов в очереди;
    приведение типа - явный int () - количество положительных элементов в очереди;

    */

    public static Queue operator /(Queue x, int y)
    {
        // добавить элемент 

        x.pushQueue(y);

        return x;
    }

    public static Queue operator ++(Queue x)
    {
        // извлечь элемент

        x.popQueue();

        return x;
    }

    public static bool operator false(Queue x)
    {
        // проверка на содержание четных элементов в очереди

        // возврат логического значения true (в очереди есть четные элементы) или false (в очереди нет четных элементов)

        return x.PresenceEven();
    }

    public static bool operator true(Queue x)
    {
        // проверка на содержание четных элементов в очереди

        // возврат логического значения true (в очереди есть четные элементы) или false (в очереди нет четных элементов)

        return x.PresenceEven();
    }


    public static implicit operator int(Queue x)
    {
        // подсчет количества положительных элементов в очереди

        return x.CulcPos();
    }

}

public static class StatisticOperation
{

    /* создадим статический класс StatisticOperation, содержащий 3 метода для работы с классом Queue :
       - сумма значений элементов;
       - разница между максимальным и минимальным значением элементов;
       - подсчет количества элементов.
    */

    /* В сравнении с нестатическим классом, статический класс имеет следующие свойства(отличия) :
       - нельзя создавать объекты статического класса;
       - статический класс должен содержать только статические члены.
    */


    public static int QSUM(Queue q)
    {
        /* возвращает сумма значений элементов очереди */

        int ret_val = 0;

        if (q.getQueueSize() == 0) return ret_val; // очередь пуста

        // проходим от начала до конца очереди :
        Queue.QNode tailnode = q.head;

        do
        {
            ret_val = ret_val + tailnode.value;

            tailnode = tailnode.next;

        } while (tailnode != null);

        return ret_val;

    }

    public static int DIFF_MAX_MIN(Queue q)
    {
        /* возвращает разницe между максимальным и минимальным значением элементов */

        int ret_val = 0;

        if (q.getQueueSize() == 0) return ret_val; // очередь пуста

        int max_val = q.head.value, min_val = q.head.value; // инициализируем значением первого элемента очереди

        // проходим от начала до конца очереди :
        Queue.QNode tailnode = q.head;

        do
        {
            if (tailnode.value > max_val) max_val = tailnode.value;
            if (tailnode.value < min_val) min_val = tailnode.value;

            tailnode = tailnode.next;

        } while (tailnode != null);

        ret_val = max_val - min_val;

        return ret_val;

    }

    public static int QPOWER(Queue q)
    {
        /* возвращает количество элементов очереди */

        return q.getQueueSize();

    }

    /* Методы расширения:
       - выделение первого числа, содержащегося в строке
       - обнуление отрицательных элементов очереди
    */

    public static int firstNumber ( this String st, Queue q)
    {
        /* метод расширения: выделение первого числа, содержащегося в строке, -1 - таких чисел нет */

        int ret_val = -1;

        if (q.getQueueSize() == 0) return ret_val; // очередь пуста

        // проходим от начала до конца очереди, проверяя ее элементы на присутствие в строке:
        Queue.QNode tailnode = q.head;

        do
        {

            for (int i = 0; i < st.Length; i++)
            {
                if (tailnode.value == (int)Char.GetNumericValue(st[i]))
                {
                    return tailnode.value;
                }
            }

        tailnode = tailnode.next;

        } while (tailnode != null);

        return ret_val;

    }

    public static void zeroNegatives(this String st, Queue q)
    {
        /* метод расширения: обнуление отрицательных элементов очереди */

        if (q.getQueueSize() == 0) return ; // очередь пуста

        // проходим от начала до конца очереди :
        Queue.QNode tailnode = q.head;

        do
        {
            if (tailnode.value < 0) tailnode.value = 0;
            
            tailnode = tailnode.next;

        } while (tailnode != null);

    }

}
