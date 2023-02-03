using System;
using System.Text;
using Helper;
using Helper.FilePackage;

namespace Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


            var filePackage = new FilePackage();

            filePackage.Open("/Users/nooo/Downloads/pw156/element/configs.pck");
            var current = filePackage.Pcks[0];

            Console.WriteLine("Hello World!");
        }
    }
}

