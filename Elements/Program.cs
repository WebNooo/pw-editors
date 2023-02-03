using System;
using System.Text;
using Helper;
using Helper.Pck;

namespace Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


            var pck = new Pck();

            pck.Open("/Users/nooo/Downloads/pw156/element/configs.pck");
            var current = pck.Pcks[0];

            Console.WriteLine("Hello World!");
        }
    }
}

