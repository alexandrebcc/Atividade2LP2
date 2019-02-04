using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Atividade2EFCore
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public int Idade { get; set; }

        public void Atualizar(Conta conta, Cliente cliente, BancoContext context)
        {
            var clienteAtualizado = context.Set<Cliente>().First(p => p.Id == cliente.Id);
            var contaAtualizada = context.Set<Conta>().First(p => p.Id == conta.Id);
            //INTERFACE
            int opcao = 1;
            for (; opcao != 0;)
            {
                Console.WriteLine("ATUALIZAR");
                Console.WriteLine("NOME ------------------ 1");
                Console.WriteLine("IDADE ----------------- 2");
                Console.WriteLine("CPF ------------------- 3");
                Console.WriteLine("SAIR ------------------ 0");
                //VERIFICANDO RETUNDÂNCIA
                try
                {
                    opcao = Int32.Parse(Console.ReadLine());
                }
                catch (Exception erro)
                {
                    erro.ToString();
                    opcao = 100;
                }
                //OPÇÕES
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("DIGITE O NOVO NOME");
                        string nome = Console.ReadLine();
                        clienteAtualizado.Nome = nome;
                        context.SaveChanges();
                        contaAtualizada.Titular = nome;
                        context.SaveChanges();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("DIGITE A NOVA IDADE");
                        int idade;
                        try
                        {
                            idade = Int32.Parse(Console.ReadLine());
                            clienteAtualizado.Idade = idade;
                            context.SaveChanges();
                        }
                        catch (Exception erro)
                        {
                            Console.Clear();
                            erro.ToString();
                            Console.WriteLine("IDADE INVÁLIDA");
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("DIGITE O NOVO CPF");
                        string cpf = Console.ReadLine();
                        var checkCpf = context.Clientes.Where(b => b.Cpf == cpf)
                                                       .FirstOrDefault();

                        if (checkCpf != null)
                        {
                            Console.Clear();
                            Console.WriteLine("CPF DIGITADO JÁ EXISTE");
                            Console.WriteLine(" ");
                            break;
                        }
                        clienteAtualizado.Cpf = cpf;
                        context.SaveChanges();

                        break;

                    case 0:
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("OPÇÃO INVÁLIDA");
                        Console.WriteLine("VOLTANDO AO MENU ");
                        break;

                }
            }
        }
    }
}


