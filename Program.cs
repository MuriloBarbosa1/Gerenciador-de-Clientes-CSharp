using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

class Program
{

    enum Menu { Listagem = 1, Adicionar = 2, Remover = 3, Sair = 4 }

    [System.Serializable]
    struct Client
    {
        public string name;
        public string email;
        public string cpf;
    }
    static List<Client> clientes = new List<Client>();

    private static void Main(string[] args)
    {
        Carregar();
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("Sistema de clientes - Bem vindo");
            Console.WriteLine("1- Listagem\n2- Adicionar\n3- Remover\n4- Sair");
            var intOP = int.Parse(Console.ReadLine());
            Menu option = (Menu)intOP;


            switch (option)
            {
                case Menu.Listagem:
                    Listagem();
                    break;
                case Menu.Adicionar:
                    Adicionar();
                    break;
                case Menu.Remover:
                    Remover();
                    break;
                case Menu.Sair:
                    sair = true;
                    break;
            }
            Console.Clear();
        }

    }
    static void Adicionar()
    {
        Console.Clear();
        Client clientAdc = new Client();
        Console.WriteLine("Cadastro de clientes");
        Console.WriteLine("Nome do cliente:");
        clientAdc.name = Console.ReadLine();
        Console.WriteLine("Email: ");
        clientAdc.email = Console.ReadLine();
        Console.WriteLine("CPF");
        clientAdc.cpf = Console.ReadLine();

        clientes.Add(clientAdc);
        Salvar();

        Console.WriteLine("Cadastro concluído, aperte enter para sair");
        Console.ReadLine();
    }
    static void Listagem()
    {
        Console.Clear();
        if (clientes.Count >= 0)
        {
            Console.WriteLine("Listagem de cliente: ");
            int i = 0;
            foreach (Client cliente in clientes)
            {
                Console.WriteLine($"ID: {i}");
                Console.WriteLine($"Nome: {cliente.name}");
                Console.WriteLine($"Email: {cliente.email}");
                Console.WriteLine($"CPF: {cliente.cpf}");
                Console.WriteLine("==============");
                i++;
            }
        }
        else
        {
            Console.WriteLine("Cliente não cadastrado.");
        }

        Console.WriteLine("");
        Console.ReadLine();
    }

    static void Remover()
    {
        Listagem();
        Console.WriteLine("Operação remover");

        Console.WriteLine("Digite o Id do cliente que deseja remover");

        int id = int.Parse(Console.ReadLine());
        if (id >= 0 && id < clientes.Count)
        {
            clientes.RemoveAt(id);
            Salvar();
        }
        else
        {
            Console.WriteLine("Id invalido, tente novamente");
            Console.ReadLine();
        }
    }
    static void Salvar()
    {
        var json = JsonConvert.SerializeObject(clientes);
        File.WriteAllText("cliente.json", json);


    }
    
    static void Carregar()
    {
        
        try
        {
            StreamReader leitor = new StreamReader(@"C:\\Users\\mubar\\OneDrive - EDU - Organização Educacional Barão de Mauá\\Documentos\\Programação\\Visual Studio 2022\\GestorDeCliente\\bin\\Debug\\net7.0\\cliente.json");
            clientes = JsonConvert.DeserializeObject<List<Client>>(leitor.ReadToEnd());
            leitor.Close();

        }
        catch (Exception e) 
        {
            
        }

    }
}

    
    
