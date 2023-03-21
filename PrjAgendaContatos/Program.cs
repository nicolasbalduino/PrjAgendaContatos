using System.ComponentModel.Design;
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
            Contact newContact = CreatContact();
            if (newContact != null)
            {
                phonebook.Add(newContact);
            }
            break;

        case 2:
            string choice;
            char? choiceLetter;

            Console.WriteLine("\nAperte ENTER para imprimir toda lista de contatos ou Digite uma letra para imprimir contatos com tal inicial: ");
            choice = Console.ReadLine();

            if (char.TryParse(choice, out char letter))
                choiceLetter = letter;
            else
                choiceLetter = null;

            Console.WriteLine();
            PrintPhoneBook(phonebook, choiceLetter);
            Console.WriteLine();
            Console.WriteLine("Precione uma tecla para continuar...");
            Console.ReadKey();
            break;

        case 3:
            EditContact();
            break;

        case 4:
            int contactIndex = 0;
            List<Contact> contactToRemove = SearchContact(null, null);
            if (contactToRemove.Count > 0)
            {
                for (int i = 0; i < contactToRemove.Count; i++)
                {
                    Console.WriteLine($"{i+1} - {contactToRemove[i].Name}: {contactToRemove[i].Phone}");
                }
                Console.WriteLine("Qual deseja remover? Digite o numero antes do traço");
                contactIndex = int.Parse(Console.ReadLine());
                phonebook.Remove(contactToRemove[contactIndex-1]);
            }
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
    int contactIndex = 0;
    List<Contact> listFinded = SearchContact(null, null);
    if (listFinded.Count == 0)
        return;

    for (int i = 0; i < listFinded.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {listFinded[i].Name}: {listFinded[i].Phone}");
    }
    Console.WriteLine("Qual deseja editar? Digite o numero antes do traço");
    contactIndex = int.Parse(Console.ReadLine());
    Contact finded = listFinded[contactIndex - 1];

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

        List<Contact> alreadyExists = SearchContact("", phone);

        if ((alreadyExists .Count > 0))
        {
            Console.WriteLine("\nJá existe um contato com este número! Nome do contato: " + alreadyExists[0].Name);
            Console.WriteLine("\n\nPrecione uma tecla para continuar...");
            Console.ReadKey();
            return;
        }

        if (name != "")
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

List<Contact> SearchContact(string? name, string? phone)
{
    List<Contact> listFinded = null;
    if(name == null)
    {
        Console.WriteLine("Informe o nome: ");
        name = Console.ReadLine();
    }

    if(phone != null)
    {
        listFinded = phonebook.FindAll(x => x.Phone == phone);
        return listFinded;
    }
    else
    {
        listFinded = phonebook.FindAll(x => x.Name == name);
        return listFinded;
    }
    

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

    List<Contact> alreadyExists;
    alreadyExists = SearchContact(n, t);

    if ((alreadyExists.Count > 0))
    {
        Console.WriteLine("\nJá existe um contato com este número! Nome do contato: " + alreadyExists[0].Name);
        Console.WriteLine("\n\nPrecione uma tecla para continuar...");
        Console.ReadKey();
        return null;
    }

    Contact contact = new Contact(n, t);
    return contact;

}

void PrintPhoneBook(List<Contact> l, char? letter)
{
    if (phonebook.Count == 0)
        Console.WriteLine("Lista de contatos vazia.");

    foreach (var item in phonebook)
    {
        if (letter is not null) 
        { 
            if (item.Name[0] == letter) 
            {
                Console.WriteLine(item);
            } 
        }
        else Console.WriteLine(item);
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
