using System;
using System.Globalization;

class SovietUnivermagQueue
{

    public string[] queue; // массив, содержащий очередь


    public SovietUnivermagQueue(int size)
    {
        queue = new string[size]; // распределить память для стека

    }
    // Поместить бабушек в очередь.
    public string[] Enter()
    {
        string name;

        for (int i = 0; i <= queue.Length; i++)
        {
            Console.WriteLine("Введите имя бабушки, которую вы хотите поставить на " + (i+1) + " место в очереди?(пишите в именительном падеже).\nЕсли не хотите больше добавлять бабушек, напишите 'конец'");

            if (i == queue.Length)
                Console.WriteLine("Очередь заполненна");
            else if (queue[i] != null)
                continue;
            else
            {
                try
                {
                    name = (Console.ReadLine());
                    if (name == "конец")
                        return queue;
                    else
                        queue[i] = name;

                }
                catch (Exception)
                {
                    Console.WriteLine("Введите имя бабушки");
                }

            }

        }
        QueueConstruct(queue);
        return queue;
    }
    // Извлечь Бабушку из очереди.
    public string[] AutoEnter()
    {
        

        for (int i = 0; i <= queue.Length; i++)
        {
            Random random = new Random();

            int index;

            string[] babyshka = new string[10] { "Зина", "Валя", "Галя", "Тома", "Рая", "Нина", "Варя", "Ираида", "Глаша", "Маруся" };

            if (i == queue.Length)
                Console.WriteLine("Очередь заполненна");
            else if (queue[i] != null)
                continue;
            else
            {
                index = random.Next(9);
                queue[i] = babyshka[index];
            }

        }
        return queue;
    }
    static string[] QueueConstruct(string[] queue)//преобразует исколеченный массив в очередь
    {
        int count = 0;
        for (int i = 0; i < queue.Length; i++)
        {
            if (queue[i] == null)
                continue;
            else
            {
                queue[count] = queue[i];
                queue[i] = null;
                count++;
            }
        }
        return queue;
    }


    public string[] Leave()
    {

        string answer;

        for (int i = 0; i < queue.Length; i++)
        {
            if (queue[i] == null)
            {
                Console.WriteLine("Очередь пустая");

                return queue;
            }
            else
            {
                Console.WriteLine("Бабушка " + queue[i] + " купила что ей нужно и ушла. Продолжить?(да/нет)");

                queue[i] = null;

                try
                {
                    answer = Console.ReadLine();

                    if (answer == "да")
                        continue;
                    else if (answer == "нет")
                        break;
                    else
                    {
                        Console.WriteLine("Просил же писать 'да' или 'нет', ну раз так...");

                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите 'да' или 'нет'");
                }
            }
        }

        QueueConstruct(queue);
        return queue;
    }

    public string[] AutoLeave(int count)
    {

        string answer;

        for (int i = 0; i < count; i++)
        {
            if (queue[i] == null)
            {
                Console.WriteLine("Очередь пустая");

                return queue;
            }
            else
            {
               
                queue[i] = null;
               
            }
        }

        QueueConstruct(queue);
        return queue;
    }

    public string[] SwitchQueue(string[] queue2)
    {
        
        for (int i = 0; i < queue.Length; i++)
        {

            Console.WriteLine("Хотите перевести бабушку " + queue[i] + " в очередь в другую очередь ? (если хотите остановитсья напишите 'нет')");
            string answer = Console.ReadLine();

            if (answer == "нет")
                return queue2;
            else
            {
                int count = 0;
                

                if (queue[^1] != null)
                {
                    Console.WriteLine("Очередь " + queue + " заполнена");
                    return queue;


                }
                else if (queue[i] != null)
                    continue;
                else
                {
                    if (queue2[count] == null)
                    {
                        Console.WriteLine("Очередь " + queue2 + " пустая");
                        return queue;
                    }
                    else
                    {
                        queue[i] = queue2[count];
                        queue2[count] = null;
                        count++;
                    }
                }
            }
            
        }
        int count2 = 0;
        for (int j = 0; j < queue2.Length; j++)
        {   
            if (queue2[j] == null)
                continue;
            else
            {
                queue2[count2] = queue2[j];
                queue2[j] = null;
                count2++;
            }
        }
        return queue;

    }

    public void QueueCheck()
    {
        
        Console.Write("В этой очереди стоят бабушк(и/а): ");
        for (int i = 0; i < queue.Length; i++)
        {
            if (queue[0] == null)
            {
                Console.Write("а не стоят, пусто...");
                break;
            }
            else if (queue[i] == null)
                break;
            else
                Console.Write(queue[i] + " ");

        }
        Console.WriteLine();
    }
    public string[] Queue()
    { return queue; }

}


    class UnivermagIvent
    {
      static void Main()
      {
            SovietUnivermagQueue queueformilk = new(5);
            SovietUnivermagQueue queueforbread = new(5);
            SovietUnivermagQueue queueforvodka = new(5);

        Console.WriteLine("Очереди создаются хардкодом да и вообще все в коде че мне еще тут писать");
        Console.ReadLine();
            //попробуем вручную завести трех бабушек
            queueformilk.Enter();
            //остальные очереди заполним автоматически 
            queueforbread.AutoEnter();
            queueforvodka.AutoEnter();

        Console.WriteLine();
        Console.ReadLine();
            //смотрим на бабушек в наших очередях
            queueformilk.QueueCheck();
            queueforbread.QueueCheck();
            queueforvodka.QueueCheck();

        Console.WriteLine();
        Console.ReadLine();
        //заставим вручную уйти двух бабушек
        queueformilk.AutoLeave(4);
            //из этой выведем бабушек автоматически
        queueforbread.Leave();

        //переведем бабушек из очереди за хлебом в очередь за молоком
        queueforbread.SwitchQueue(queueformilk.Queue());
        //теперь заполним очередь за молоком людьми из очереди за водкой
        queueforvodka.SwitchQueue(queueformilk.Queue());
        Console.WriteLine();
        Console.ReadLine();
        //посмотрим что в очередях еще раз
            queueformilk.QueueCheck();
            queueforbread.QueueCheck();
            queueforvodka.QueueCheck();

        Console.ReadLine();
      }
    }

    
