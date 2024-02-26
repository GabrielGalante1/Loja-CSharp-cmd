using System;
using System.Threading;
using static loja;

class erro
{
    public void Erro() //Esta função é chamada quando o usuario digita um item que não existe.
    {
        Console.WriteLine("Não foi possivel localizar este item. Tente novamente."); 
        Thread.Sleep(500);
    }

}

class ganharDinheiro
{
    int dinheiro = banco.dinheiro;
    erro erro1 = new erro();
    List<string> comecarVar = new List<string> {"Começar", "começar", "Comecar", "comecar"};
    public void GanharDinheiro()
    {
        Console.WriteLine("Cada enter clicado equivale a 5 pontos. \nPara começar, apenas escreva COMECAR.");
        string tecla1 = Console.ReadLine();
        if (comecarVar.Contains(tecla1))
        {
            while (true) //Loop para o usuario ganhar dinheiro até ele escrever "sair"
            {
                string tecla2 = Console.ReadLine();
                if (tecla2 == "ADM" || tecla2 == "adm")
                {
                    GanharDinheiroADM();
                }
                else if (tecla2 == "sair")
                {
                    break;
                }
                else
                {
                    GanharDinheiroUser();
                }
            }
        }
        else
        {
            erro1.Erro();
        }
    }
    void GanharDinheiroUser() //Método para ganhar dinheiro
    {
        banco.dinheiro += 5;
        Console.WriteLine($"\nVoce ganhou $5!\nSaldo: {banco.dinheiro}");
    }
    void GanharDinheiroADM() //Método especial para desenvolvedores
    {
        dinheiro += 5;
        Console.WriteLine($"\n------ADM-----\nVoce ganhou $500!\nSaldo: {banco.dinheiro}");
    }
}

class programa
{
    erro erro1 = new erro();
    loja loja1 = new loja();
    banco banco1 = new banco();
    ganharDinheiro ganharDin1 = new ganharDinheiro();
    public void Programa() //Menu de seleção.
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
            else if (tecla1 == "ganhar dinheiro")
            {
                ganharDin1.GanharDinheiro();
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
    internal class produtos2
    {
        public int valor;
        public String[] variacoes;

        public produtos2(int Valor, String[] Variacoes)
        {
            valor = Valor;
            variacoes = Variacoes;
        }
    }

    //Caso você esteja se perguntando o que são todas essas Lists abaixo, são os produtos. As arrays dentro da List significa variações que o usuario pode digitar.
    public static produtos2 biscoito = new produtos2(5, new string[] {"Biscoito", "biscoito", "1"});
    public static produtos2 cs2 = new produtos2(55, new string[] { "Cs2", "cs2", "2" });
    public static produtos2 fortnite = new produtos2(200, new string[] { "Fortnite", "fortnite", "3" });

    erro erro1 = new erro();
    banco banco1 = new banco();
    List<produtos2> produtos = new List<produtos2>
    {
        biscoito,
        cs2,
        fortnite,
    };
    public void Loja()
    {
        while (true)
        {
            Console.WriteLine("O que voce deseja comprar?\n");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"{produto.variacoes[0]}: {produto.valor}");
            }
            string tecla1 = Console.ReadLine();
            var produto3 = produtos.FirstOrDefault(p => p.variacoes.Contains(tecla1));
            if (produtos.Any(produto => produto.variacoes.Contains(tecla1)))
            {
                Compra(tecla1, produto3.valor);
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
    public void Compra(string produtoNome, int preco)
    {
        if (banco.dinheiro >= preco)
        {
            banco.dinheiro -= preco;
            Console.WriteLine($"Você comprou {produtoNome}");
            Console.WriteLine($"Saldo: {banco.dinheiro}\n");
            Thread.Sleep(500);
        }
        else if (banco.dinheiro < preco)
        {
            Console.WriteLine("Voce nao possui saldo suficiente");
            Thread.Sleep(500);
        }
    }
}

class banco
{
    public static int dinheiro = 500;
    public void Banco()
    {
        Console.WriteLine($"\nSaldo: {banco.dinheiro}\n");
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