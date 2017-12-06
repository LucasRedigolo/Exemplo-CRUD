using System;
using System.Collections.Generic;

namespace ExemploCrud {
    class Program {
        static void Main (string[] args) {
            Categoria cat = new Categoria ();
            BancoDados bd = new BancoDados ();
            int opcao;

            do {
                //Mostra um menu de opções para o usuário
                Console.WriteLine ("Digite a opção");
                Console.WriteLine ("1 - Cadastrar 'Categoria':");
                Console.WriteLine ("2 - Consultar Categoria por ID:");
                Console.WriteLine ("3 - Consultar Categoria por titulo:");
                Console.WriteLine ("4 - Atualizar uma Categoria:");
                Console.WriteLine ("5 - APAGAR UMA CATEGORIA:");
                Console.WriteLine ("9 - Sair");
                opcao = Int16.Parse (Console.ReadLine ());

                //Recebe opção do usuário
                switch (opcao) {
                    case 1:
                        System.Console.WriteLine ("---- Bem vindo ao modulo de cadastro de CATEGORIA ----");
                        System.Console.WriteLine ("Insira o nome da categoria a ser cadastrada: ");
                        cat.Titulo = Console.ReadLine ();
                        if (bd.Adicionar (cat)) {
                            System.Console.WriteLine ("Categoria cadastrada com sucesso!\n");
                        } else {
                            System.Console.WriteLine ("OCORREU UM ERRO NO CADASTRO, TENTE NOVAMENTE\n");
                        }
                        break;

                    case 2:
                        System.Console.WriteLine ("Insira o ID da categoria desejada: ");
                        cat.IDCategoria = Convert.ToInt32 (Console.ReadLine ());
                        List<Categoria> listaID = bd.ListarCategorias (cat.IDCategoria);

                        foreach (var item in listaID) {
                            System.Console.WriteLine (item.IDCategoria + " ; " + item.Titulo);
                        }
                        break;

                    case 3:
                        System.Console.WriteLine ("Insira o titulo da Categoria desejada:");
                        cat.Titulo = Console.ReadLine ();
                        List<Categoria> listaTIT = bd.ListarCategorias (cat.Titulo);
                        foreach (var item in listaTIT) {
                            System.Console.WriteLine ("ID: "+ item.IDCategoria + " ; " + "TITULO: "+ item.Titulo);
                        }
                        System.Console.WriteLine("\n");
                        break;

                    case 4:
                        System.Console.WriteLine ("Qual o ID do item a ser atualizado?");
                        cat.IDCategoria = Convert.ToInt32 (Console.ReadLine ());
                        System.Console.WriteLine ("Qual vai ser o novo nome da Categoria?");
                        cat.Titulo = Console.ReadLine ();
                        if (bd.Atualizar (cat)) {
                            System.Console.WriteLine ("Cadastro Atualizado!\n");
                        } else {
                            System.Console.WriteLine ("OCORREU UM ERRO NA ATUALIZAÇÃO, TENTE NOVAMENTE\n");
                        }
                        break;

                    case 5:
                        System.Console.WriteLine ("Você está iniciando o modulo de apagamento de categoria, as alterações são irreversíveis então prossiga com cautela: ");
                        System.Console.WriteLine ("------------------------\n");
                        System.Console.WriteLine ("Insira o ID da categoria a ser apagada:");
                        cat.IDCategoria = Convert.ToInt32 (Console.ReadLine ());
                        if (bd.Apagar (cat)) {
                            System.Console.WriteLine ("Categoria Apagada!\n");
                        } else {
                            System.Console.WriteLine ("Erro ao tentar apagar categoria, tente novamente!\n");
                        }
                        break;
                }
            } while (opcao != 9);
        }
    }
}