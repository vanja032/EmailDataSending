using System;
using System.Net;
using System.Net.Mail;

namespace SendDataToEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input");
            int n = int.Parse(Console.ReadLine());
            int[,] coords = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                string[] coord = s.Split(' ');
                for (int j = 0; j < 2; j++)
                {
                    coords[i, j] = Convert.ToInt32(coord[j]);
                }
            }
            Console.WriteLine("Output");

            string message = "n= " + Convert.ToString(n) + "    coordinate>> ";
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    { message += Convert.ToString(coords[i, j]) + "_"; }
                    else
                    {
                        message += Convert.ToString(coords[i, j]);
                    }

                }
                message += " / ";
            }
            SmtpClient cv = new SmtpClient("smtp.gmail.com", 587);
            cv.Credentials = new NetworkCredential("<sender email addrees>", "<sender password>");
            cv.EnableSsl = true;
            cv.Send("<sender email addrees>", "<receiver email addrees>", "Some title", message);
            Console.WriteLine("-1");

            Console.ReadLine();

        }
    }
}
