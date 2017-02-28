using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            //password to decrypt messages. The default password is "secret" encoded into a string in byte form.
            string password = "c2VjcmV0";
            int[] id = new[] { 0, 1, 2, 3, 4 };
            string[] messages = new string[] { " ", " ", " ", " ", " " };
            while (true)
            {
                Console.WriteLine("Do you want to (s)tore a message, (r)etrieve a message, (l)ist message, or e(x)it?");
                string toDo = Console.ReadLine();

                if (toDo == "s")
                {
                    Console.WriteLine("There are only 5 memory slots. Enter a number 0 - 4");
                    int i = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter your message:");
                    string toEncrypt = Console.ReadLine();
                    //converts string to byte
                    byte[] encrypt = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncrypt);
                    //converts byte back to string for storage
                    messages[i] = System.Convert.ToBase64String(encrypt);
                }
                else if (toDo == "r")
                {
                    Console.WriteLine("Type in the message number you'd like to read");
                    Console.WriteLine("Enter the Message # You'd Like to Read.");
                    int messNum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("What is the password?");
                    string tempPass = Console.ReadLine();
                    byte[] encrypt = System.Text.ASCIIEncoding.ASCII.GetBytes(tempPass);
                    tempPass = System.Convert.ToBase64String(encrypt);
                    if (tempPass == password)
                    {
                        string encodedData = messages[messNum];
                        byte[] decrypt = System.Convert.FromBase64String(encodedData);
                        string newMessage = System.Text.ASCIIEncoding.ASCII.GetString(decrypt);
                        messages[messNum] = newMessage;
                        Console.WriteLine(messages[messNum]);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry your password is incorrect! Encrypted Messages: {messages[messNum]}");
                    }
                }
                else if (toDo == "l")
                {
                    Console.WriteLine("Listing Saved Messages:");
                    Console.WriteLine("What is the password?");
                    string tempPass = Console.ReadLine();
                    byte[] encrypt = System.Text.ASCIIEncoding.ASCII.GetBytes(tempPass);
                    tempPass = System.Convert.ToBase64String(encrypt);
                        if (tempPass == password)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            string encodedData = messages[i];
                            byte[] decrypt = System.Convert.FromBase64String(encodedData);
                            string newMessage = System.Text.ASCIIEncoding.ASCII.GetString(decrypt);
                            messages[i] = newMessage;
                            Console.WriteLine(messages[i]);
                        }

                    }
                    if (tempPass != password)
                    {
                        Console.WriteLine("Wrong! Here are your encrytped messages.");
                        for (int i = 0; i < 5; i++)
                            Console.WriteLine($"Message {i}: {messages[i]}");
                    }
                }
                else if (toDo == "x")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("That is not an option!");
                }
            }
        }
    }
}


