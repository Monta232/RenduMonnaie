// Cashback method
void Cashback(int moneyback)
{
    int[] COINS = new int[] { 10, 5, 2 };
    int i = 0;

    //If there is no combinations possible with thoose type of Coins to get back
    if (moneyback <= 1)
    {
        Console.Write(-1);
    }

    //If there is combinations 
    while (moneyback > 1)
    {
        // Current type of COINS is greater than moneyBack
        if (COINS[i] > moneyback)
        {
            Console.Write(0 + " ");
            i++; 
        }
        else
        {
            if(moneyback >= COINS[i])
            {
                // Val = how much COINS to back from one type (10 , 5 , 2)
                int val = moneyback / COINS[i];
                int rest = moneyback % COINS[i];

                // If the cashback contains only one type of COINS
                //Only 10 or Only 5 or Only 2
                //rest equals 0 => there is no rest
                if(rest < 1)
                {
                    Console.Write(val + " ");
                    moneyback -= COINS[i] * val;
                    if ((moneyback == 0) && (i < COINS.Length)){
                        for(int j = i; j < COINS.Length -1 ; j++)
                        {
                            Console.Write(0 + " ");
                        }
                    }
                }

                // If the cashback contains more than one type of COINS to back
                // rest > 0 => r=there is rest to back 
                else 
                {
                    //If there is no more type of Coins to get back
                    //rest equals 0 => there is no more combination
                    if (rest % COINS[i] < 1)
                    {
                        Console.Write(val + " ");
                        moneyback -= COINS[i] * val;
                        i++;
                    }
                    //If there is more types of Coins to get back
                    //rest > 0 => there is more combination
                    else
                    {
                        try
                        {
                            //RestofTheRest to see next value
                            //It can generate an OutOfRange exception 
                            //In our case that's mean that we didn't have any combination possible 
                            int restOfTheRest = rest % COINS[i + 1];

                            if (restOfTheRest == 0)
                            {
                                Console.Write(val + " ");
                                moneyback -= COINS[i] * val;
                                i++;
                            }
                            else if (restOfTheRest == 1)
                            {
                                // If the rest still superior of the next value 
                                // We have to get back the VAL
                                if(rest > COINS[i + 1])
                                {
                                    Console.Write(val + " ");
                                    moneyback -= COINS[i] * val;
                                    i++;
                                }
                                else
                                // If the rest is inferior of the next value
                                // We have to get back the VAL - 1 and discount from money the (VAL - 1 * Type of coin {10, 5, 2})
                                // To ensure the optimal cashback
                                {
                                    Console.Write(val - 1 + " ");
                                    moneyback -= COINS[i] * (val - 1);
                                    i++;
                                }
                            }
                            else
                            {
                                Console.Write(val + " ");
                                moneyback -= COINS[i] * (val);
                                i++;
                            }
                        }
                        catch (Exception)
                        {
                            ClearCurrentConsoleLine();
                            Console.Write(-1);
                            break;
                        }
                           
                        
                    }
                    
                }
              

            }
  
        }
    }
    //For good display of values in the console
    Console.WriteLine("");

}


//This method to clear only one specific line from the console
static void ClearCurrentConsoleLine()
{
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, currentLineCursor);
}

//Some tests with random values
Console.Write("\nSome tests with random values\n");
Console.WriteLine("cashback : 15");
Cashback(15);
Console.WriteLine("************************");

Console.WriteLine("cashback : 1");
Cashback(1);
Console.WriteLine("************************");

Console.WriteLine("cashback : 11");
Cashback(11);
Console.WriteLine("************************");

Console.WriteLine("cashback : 55");
Cashback(55);
Console.WriteLine("************************");

Console.WriteLine("cashback : 3");
Cashback(3);
Console.WriteLine("************************");
Console.Write("\n End of default tests \n");
//End of tests 


//
Console.WriteLine("\nNow you can use it with a value of your choice:\n");
Console.WriteLine("\nPlease enter the value of the cashback, followed by <Enter>:\n");
try
{
    string value = Console.ReadLine();
    if ((value != null) && (value != String.Empty))
    {
        int moneyback = Int32.Parse(value);
        Console.WriteLine("Calculating cashback : ");
        Cashback(moneyback);
        Console.Write("\nPress any key to continue... \n ");
        Console.ReadKey();
    }
}
catch (Exception)
{
    Console.Write("\nPlease enter a correct number...\n ");
    Console.ReadKey();

}


