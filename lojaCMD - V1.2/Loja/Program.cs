using System;
using System.Threading;
using System.Collections.Generic;

class Programa
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("O que você deseja fazer?\nLoja\nBanco\nGanhar Dinheiro");
            string tecla1 = Console.ReadLine().ToUpper();
            if (tecla1 == "LOJA")
            {
                Console.WriteLine('\n');
                Loja loja = new Loja();
                loja.LojaPrincipal();
            }
            else if (tecla1 == "BANCO")
            {
                Console.WriteLine('\n');
                Banco Banco = new Banco();
                Banco.BancoPrincipal();
            }
            else if (tecla1 == "GANHAR DINHEIRO" || tecla1 == "GANHAR" || tecla1 == "DINHEIRO")
            {
                Console.WriteLine('\n');
                GanharDinheiro ganharDinheiro = new GanharDinheiro();
                ganharDinheiro.GanharDinheiroPrincipal();
            }
            else { }
        }
    }
}

class Produto
{
    public string nome;
    public int preco;
    public Produto(string nome, int preco)
    {
        this.nome = nome;
        this.preco = preco;
    }

    public static void Mostrar(List<Produto> produtoList)
    {
        foreach (var item in produtoList)
        {
            Console.Write(item.nome);
            Console.Write(" R$");
            Console.WriteLine(item.preco);
        }
    }
}

class Loja
{
    public static List<Produto> produtoList = new List<Produto>()
    {
        new Produto("Biscoito", 5),
        new Produto("Software", 55),
        new Produto("Jogo", 200),
    };
    public void LojaPrincipal()
    {
        Console.WriteLine("O que você deseja comprar?");
        Produto.Mostrar(produtoList);
        string tecla1 = Console.ReadLine().ToUpper();
        bool achou = false;

        if (tecla1 == "SAIR")
        {
        }

        foreach (var item in produtoList)
        {
            if (item.nome.ToUpper() == tecla1)
            {
                achou = true;
                int quantidade;
                Console.WriteLine("Quantos itens você quer comprar?");
                quantidade = Convert.ToInt32(Console.ReadLine());

                if (Comprar(item.preco, quantidade) == 0)
                {
                    Console.WriteLine("Você não tem dinheiro.");
                }
                else
                {
                    Console.WriteLine($"Saldo: {Banco.Dinheiro}");
                }
                Thread.Sleep(1000);
                break;
            }
        }

        if (achou != true)
        {
            Console.WriteLine("Este produto não existe na lista. Tente novamente");
            Thread.Sleep(1000);
        }
    }

    private int Comprar(int preco, int quantidade)
    {
        foreach (var item in produtoList)
        {
            
            preco *= quantidade;
            if (Banco.Dinheiro >= preco)
            {
                return Banco.Dinheiro -= preco;
            }
            else
            {
                return 0;
            }
        }
        return 0;
    }
}

class GanharDinheiro
{
    public void GanharDinheiroPrincipal()
    {
        Console.WriteLine("Para gerar dinheiro, basta apertar/escrever qualquer coisa, exceto sair.");
        Console.WriteLine("Pressione qualquer tecla para continuar..");
        while (true)
        {
            string tecla1 = Console.ReadLine().ToUpper();
            if (tecla1 == "SAIR")
            {
                Console.Clear();
                break;
            }
            else
            {
                Console.WriteLine($"Você ganhou {SomarDinheiro(20)}. Seu saldo é de {Banco.Dinheiro}");
            }
        }
    }

    private int SomarDinheiro(int quantidade)
    {
        return Banco.Dinheiro += quantidade;
    }
}

class Banco
{
    public static int Dinheiro = 500;
    public void BancoPrincipal()
    {
        Console.WriteLine($"O seu saldo é de {Saldo()}.\n");
        Thread.Sleep(500);
    }
    private int Saldo()
    {
        return Dinheiro;
    }
}
