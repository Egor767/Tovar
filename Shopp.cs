using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class Good
    {
        public string name;
        public string dataizgot;
        public string srokgodn;
        public string proizvoditel;
        public string[] dannyeoprodaje1 = new string[3];
        public int[] dannyeoprodaje2 = new int[3];
        public string kolvo;
        public Good(string n, string da, string s, string p, string[] d1, int[] d2, string c) { name = n; dataizgot = da; srokgodn = s; proizvoditel = p; dannyeoprodaje1 = d1; dannyeoprodaje2 = d2; kolvo = c; }

        public void Print()
        {
            Console.WriteLine(name);
            Console.WriteLine(dataizgot);
            Console.WriteLine(srokgodn);
            Console.WriteLine(proizvoditel);
            Console.WriteLine("{0} - {1}\n{2} - {3}\n{4} - {5}", dannyeoprodaje1[0], dannyeoprodaje2[0], dannyeoprodaje1[1], dannyeoprodaje2[1], dannyeoprodaje1[2], dannyeoprodaje2[2]);
            Console.WriteLine(kolvo);
            Console.WriteLine();
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            string a, b, c, d, e, f;
            int i = 0;
            List<object> Namelist = new List<object>();
            string h = "1234567891";
            
            //FullSale(ref Namelist); 
            string[] e1 = new string[3]{"20.12.2022","21.12.2022","22.12.2022"};
            int[] e2 = new int[3]{60,60,67};
            Good Milk = new Good("Молоко", "20.12.2022", "20", "OOO Milk",e1, e2, "350");
            
            string[] e3 = new string[3]{"12.12.2011","13.12.2011","14.12.2022"};
            int[] e4 =new int[3]{40,45,50};
            Good Bread = new Good("Хлеб", "12.12.2022", "10", "Hrust",e3, e4, "200");
            
            string[] e5 = new string[3]{"19.12.2022", "20.12.2022","21.12.2022"};
            int[] e6 = new int[3]{10, 30, 20};
            Good Coffe = new Good("Кофе", "18.12.2022", "90", "Nescaffe", e5, e6,"60");
            
            string[] e7 = new string[3]{"16.12.2022", "17.12.2022", "14.18.2022"};
            int[] e8 = new int[3]{60, 50, 40};
            Good Eggs = new Good("Яйца", "15.12.2022", "30", "Zavod",e7,e8, "150");
            
            string[] e9 = new string[3]{"16.12.2022", "17.12.2022", "18.18.2022"};
            int[] e11 = new int[3]{50, 50, 60};
            Good Chiken = new Good("Курица", "15.12.2022", "40", "Troekurovo", e9,e11,"200"); 
            
            Namelist.Add(Milk);
            Namelist.Add(Bread);
            Namelist.Add(Coffe);
            Namelist.Add(Eggs);
            Namelist.Add(Chiken);

            while (true)
            { 
                Console.WriteLine("База данных");
                Console.WriteLine("1. Вывести все наименования товаров");
                Console.WriteLine("2. Ввести новый товар");
                Console.WriteLine("3. Вывести просроченный товар");
                Console.WriteLine("4. Вывести полностью проданный товар");
                Console.WriteLine("5. Выборка товара по производителю");
                Console.WriteLine("6. Вывод остатка товара");
                Console.WriteLine("7. Выход");
                Console.WriteLine("");
                while (!int.TryParse(Console.ReadLine(), out int v))
                {
                    Console.WriteLine("Ошибка ввода!");
                    break;
                }
                Console.Clear();
                
                if (v==1)
                {
                    foreach (Good k in Namelist)
                    {
                        k.Print();
                    }
                    Console.ReadKey();
                }
                
                else if (v == 2)
                {
                    int x=0;
                    while(x!=2)
                    {
                        Console.WriteLine("Введите данные о товаре");
                        Console.WriteLine();
                        Console.WriteLine("Введите имя");
                        a = Console.ReadLine();
                        Console.WriteLine("Введите дату изготов");
                        b = Console.ReadLine();
                        Console.WriteLine("Введите срок годности");
                        c = Console.ReadLine();
                        Console.WriteLine("Введите производителя");
                        d = Console.ReadLine();
                        Console.WriteLine("Введите данные о продаже");
                        for (int l = 0; l < 3; l++)
                        {
                            Console.WriteLine("Введите дату");
                            e1[l] = Console.ReadLine();
                            Console.WriteLine("Введите количество проданных");
                            e2[l] = int.Parse(Console.ReadLine());
                            
                        }
                        
                        
                        Console.WriteLine("Введите данные о количестве на складе");
                        f=Console.ReadLine();
                        Console.WriteLine();
                        Good meat = new Good(a, b, c, d, e1,e2, f);
                        meat.Print();
                        Namelist.Add(meat);
                        Console.WriteLine("1 - Еще товар\n2 - Меню");
                        x = int.Parse(Console.ReadLine());
                    }
                }
                
                else if (v==3)
                {
                    Console.WriteLine("Просроченный товар");
                    Console.WriteLine();
                    Console.Write("Введите текущую дату: ");
                    h=Console.ReadLine();
                    string h1= "" + h[0]+h[1];
                    string h2= "" + h[3]+h[4];
                    string h3= "" + h[6]+h[7]+h[8]+h[9];
                    //01.34.6789
                    foreach (Good y in Namelist)
                    {
                        int srok=int.Parse(y.srokgodn);
                        string u=y.dataizgot;
                        string u1= "" + u[0]+u[1];
                        string u2= "" + u[3]+u[4];
                        string u3= "" + u[6]+u[7]+u[8]+u[9];
                        
                        int y1=int.Parse(u1);
                        int y2=int.Parse(u2);
                        int y3=int.Parse(u3);
                        
                        
                        int r=srok/30;
                        y2+=r;
                        if (y1+srok%30>30)
                        {
                            y2+=1;
                            y1=y1+srok%30-30;
                        }
                        else
                        {
                            y1=y1+srok%30;
                        }
                        if (y2>12)
                        {
                            y3+=1;
                            y2=y2%12;
                        }
                        if ((int.Parse(h1)>y1) || (int.Parse(h2)>y2) || (int.Parse(h3)>y3))
                        {
                            Console.WriteLine("{0} - {1}.{2}.{3}",y.name,y1,y2,y3);
                        }
                    }
                    string jj=Console.ReadLine();
                    
                }
                else if (v == 4)
                {
                    int s=0;
                    Console.WriteLine("Полностью проданный товар:");
                    foreach (Good k in Namelist)
                    {
                        string sel=k.kolvo;
                        int sell=int.Parse(sel);
                        int sum=0;
                        for (int m=0;m<3;m++)
                        {
                            s=k.dannyeoprodaje2[m];
                            sum+=s;
                        }
                        if (sell==sum)
                        {
                            Console.WriteLine(k.name);
                        }
                    }
                    string o=Console.ReadLine();
                }
                else if (v==5)
                {
                    Console.WriteLine("Выбрать товар по производителю\n");
                    Console.Write("Введите производителя: ");
                    string w =Console.ReadLine();
                    Console.WriteLine("");
                    foreach (Good k in Namelist)
                    {
                        if (k.proizvoditel==w)
                        {
                            Console.WriteLine(k.name);
                        }
                    }
                    Console.ReadLine();
                }
                else if (v==6)
                {
                    int m=0;
                    Console.WriteLine("Остаток товара\n");
                    foreach (Good k in Namelist)
                    {
                        string sel=k.kolvo;
                        int sell=int.Parse(sel);
                        int sum=0;
                        for (m=0;m<3;m++)
                        {
                            int s=k.dannyeoprodaje2[m];
                            sum+=s;
                        }
                        Console.WriteLine("{0} - {1} шт",k.name,sell-sum);
                    }
                    string o=Console.ReadLine();
                }
                else if (v==7)
                {
                    break;
                }
                Console.Clear();
            }
        }
    }
}


/*имеется класс "товары", к-ый хар-зуется полями:
-наименование
- дата изгот
- срок годн
- производитель
- данные о продаже(дата/кол-во)

нада реализовать следующ функции:
-ввод данных
- выборка просроченного
- выборка товара полность проданного
- выборка товаров по произв
- вывод остатка товара

меню, где будут перечислены функции
предусмотреть, шобы выборку товаров мы не производили пока не заполнили даннные
можна предварительно просить кол-во товара
string h=Console.ReadLine();
                    string h1=h[0]+h[1];
                    string h2=h[3]+h[4];
                    string h3=h[6]+h[7]+h[8]+h[9];
                    //01.34.6789
                    foreach (Good y in Namelist)
                    {
                        int srok=int.Parse(y.srokgodn);
                        string u=y.dataizgot;
                        string u1=u[0]+u[1];
                        string u2=u[3]+u[4];
                        string u3=u[6]+u[7]+u[8]+u[9];
                        if ((int.Parse(h1)<int.Parse(u1)) & (int.Parse(h2)<int.Parse(u2)) & (int.Parse(h3)<int.Parse(u3)))
                        {
                            Console.WriteLine(y.name);
                        }
                    }*/

