using System.Runtime.InteropServices;
using PrjAgendaContatos;

List<Contact> phonebook = new List<Contact>();


int op;
do
{
    op = Menu();

    switch (op)
    {
        case 1:
            phonebook.Add(CreatContact());
            break;

        case 2:
            Console.WriteLine();
            PrintPhoneBook(phonebook);
            Console.WriteLine();
            Console.WriteLine("Precione uma tecla para continuar...");
            Console.ReadKey();
            break;

        case 3:
            EditContact();
            break;

        case 4:
            phonebook.Remove(SearchContact());
            break;

        case 5:
            System.Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Opção Invalida.");
            break;
    }

} while (op != 5);

void EditContact()
{
    Contact finded = SearchContact();
    if (finded != null)
    {
        string name, phone, street, city, state, postalCode, country;
        Console.WriteLine("Informe o novo nome: ");
        name = Console.ReadLine();
        Console.WriteLine("Informe o novo telefone: ");
        phone = Console.ReadLine();
        Console.WriteLine("Informe o novo logradouro: ");
        street = Console.ReadLine();
        Console.WriteLine("Informe a nova cidade: ");
        city = Console.ReadLine();
        Console.WriteLine("Informe o novo estado: ");
        state = Console.ReadLine();
        Console.WriteLine("Informe o novo CEP: ");
        postalCode = Console.ReadLine();
        Console.WriteLine("Informe o novo país: ");
        country = Console.ReadLine();
        
        if(name != "")
            finded.Name = name;
        if (phone != "")
            finded.Phone = phone;
        if (street != "")
            finded.Address.EditStreet(street);
        if (city != "")
            finded.Address.EditCity(city);
        if (state != "")
            finded.Address.EditState(state);
        if (postalCode != "")
            finded.Address.EditPostalCode(postalCode);
        if (country != "")
            finded.Address.EditCountry(country);
    }
}

Contact SearchContact()
{
    Console.WriteLine("Informe o nome: ");
    var n = Console.ReadLine();

    foreach (var item in phonebook)
        if (item.Name.Equals(n))
            return item;

    return null;
}

Contact DeleteContact()
{
    Console.WriteLine("Informe o nome: ");
    var n = Console.ReadLine();

    foreach (var item in phonebook)
        if (item.Name.Equals(n))
            return item;

    return null;
}

Contact CreatContact()
{
    Console.WriteLine("Informe o nome: ");
    string n = Console.ReadLine();
    Console.WriteLine("Informe o telefone: ");
    string t = Console.ReadLine();

    Contact contact = new Contact(n, t);

    return contact;
}

void PrintPhoneBook(List<Contact> l)
{
    if(phonebook.Count == 0)
        Console.WriteLine("Lista de contatos vazia.");
    foreach (var item in phonebook)
    {
        Console.WriteLine(item);
    }
}

int Menu()
{
    Console.Clear();
    Console.WriteLine("MENU DE OPÇOES" +
                        "\n1 - Insere Contato" +
                        "\n2 - Imprimir Lista de Contatos" +
                        "\n3 - Editar Contato" +
                        "\n4 - Remover Contato" +
                        "\n5 - Sair" +
                        "\n\nEscolha uma opção:");
    
    var xpto = int.Parse(Console.ReadLine());
    return xpto;
}
