using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Terminal
{
    class Program
    {
        static async void ReceiveCycle()
        {
            while (true)
            {
                await Comunicator.Receive();
            }
        }


        static async Task TransmitCycle()
        {
            while (true)
            {
                var atCommnad = Console.ReadLine();
                if (atCommnad.ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye :) ...");
                    break;
                }
                else if (atCommnad.ToLower() == "cls".ToLower())
                {
                    Console.Clear();
                }
                else
                {
                    await Comunicator.SendString(atCommnad);

                }

            }
        }
        static async Task Main(string[] args)
        {



            Comunicator.InitPort();
            Comunicator.ShowPortInfo();

            ReceiveCycle();
            await Task.Run(TransmitCycle);

            Comunicator.Close();

        }
    }
}
