using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

class erro
{
    public void Erro() //Chama este campo quando o usuario digita algo incorreto.
    {
        Console.WriteLine("Não foi possivel localizar este item. Tente novamente.");
        Thread.Sleep(500);
    }

}

class ganharDinheiro
{
    public void GanharDinheiro() //Método de fazer o usuario ganhar dinheiro. Não disponível até esta versão do programa.
    {

    }
}

class programa
{
    erro erro1 = new erro();
    loja loja1 = new loja();
    banco banco1 = new banco();
    public void Programa() //Menu do programa.
    {
        while (true)
        {
            Console.WriteLine("O que deseja fazer? \nLoja\nBanco\nGanhar Dinheiro");
            string tecla1 = Console.ReadLine();
            if (tecla1 == "loja" || tecla1 == "LOJA")
            {
                loja1.Loja();
            }
            else if (tecla1 == "banco" || tecla1 == "BANCO")
            {
                banco1.Banco();
            }
            else
            {
                erro1.Erro();
            }
        }
    }
}

class loja
{
    erro erro1 = new erro();
    banco banco1 = new banco();
    Dictionary<string, int> produtos = new Dictionary<string, int>() //Dicionario que armazena o Nome do produto e o Valor.
    {
        { "Biscoito", 5 },
        { "Jogo", 50},
        { "SSD", 200 },
    };
    public void Loja()
    {
        while (true)
        {
            Console.WriteLine("O que voce deseja comprar?\n");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"{produto.Key}: {produto.Value}");
            }
            string tecla1 = Console.ReadLine();
            if (produtos.ContainsKey(tecla1))
            {
                Compra(tecla1);
            }
            else if (tecla1 == "sair")
            {
                break;
            }
            else
            {
                erro1.Erro();
            }
        }
    }
    public void Compra(string produtoNome) //Método para realizar a operação de compra.
    {
        int dinheiro = banco.dinheiro;
        if (dinheiro >= produtos[produtoNome])
        {
            banco.dinheiro -= produtos[produtoNome];
            Console.WriteLine($"Saldo: {dinheiro}");
            Thread.Sleep(500);
        }
        else if (banco.dinheiro < produtos[produtoNome])
        {
            Console.WriteLine("Voce nao possui saldo suficiente");
            Thread.Sleep(500);
        }
    }

}

class banco
{
    public static int dinheiro = 500;
    public void Banco() //Usuario verifica quanto dinheiro ele tem. Valor padrão é 500.
    {
        Console.WriteLine($"Saldo: {banco.dinheiro}");
        Thread.Sleep(500);
    }
}

class main
{
    static void Main()
    {
        programa programa1 = new programa();
        programa1.Programa();
    }
}