using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Robo.File;
using Robo.Service;

namespace Robo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string opcaoMenu;

            do
            {
                Console.Clear();
                opcaoMenu = Menu();
                switch(opcaoMenu)
                {
                    case "1":
                        InserirDadosApiRobo.InserirDadosApi();
                        break;
                        case "2": Console.WriteLine("{0}", BuscarDadosApi.BuscarPrecoBaseApi());
                            Console.ReadKey();
                        break;
                }
            } while (opcaoMenu != "0");

        }
        static string Menu()
        {
            Console.WriteLine("***** MENU *****");
            Console.WriteLine("[1]Inserir dados Api via robo");
            Console.WriteLine("[2]Gerar relatorio Preco Base");
            Console.WriteLine("[3]Gerar relatorio de passagens");            
            Console.WriteLine("[0]Sair");
            return Console.ReadLine();
        }
        
    }
}

