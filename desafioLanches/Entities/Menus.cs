using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace desafioLanches
{
    public static class Menus
    {
        public static void MainMenu(List<Lanches> lanches)
        {
            Console.WriteLine("");
            Console.WriteLine("1 - Comprar");
            Console.WriteLine("2 - Acessar o estoque");
            Console.WriteLine("3 - Cancelar");
            Console.WriteLine("Por favor, digite o número da opção que você deseja acessar.");

            int convertedUserAnswer= Navigation.AnswerTest("1", "2", "3");
            
            switch (convertedUserAnswer)
            {
                case 1:
                    PurchaseMenu(lanches);
                    break;
                case 2:
                    StockMenu(lanches);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void StockMenu(List<Lanches> lanches)
        {
            foreach (Lanches item in lanches)
            {
                Console.WriteLine("");
                Console.WriteLine($"Nome: {item.Name}\nPreço: R$ {item.Price}\nTipo: {item.Type}\nQuantidade em estoque: {item.Amount}\nID: {item.ID}");
            }

            Console.WriteLine("");
            Console.WriteLine("1 - Adicionar Produto");
            Console.WriteLine("2 - Remover Produto");
            Console.WriteLine("3 - Adicionar ao estoque");
            Console.WriteLine("4 - Retornar ao menu inicial");
            Console.WriteLine("5 - Cancelar");
            Console.WriteLine("Por favor, digite o número da opção que você deseja acessar.");

            int convertedUserAnswer = Navigation.AnswerTest("1", "2", "3","4","5");

            switch (convertedUserAnswer)
            {
                case 1:
                    AddProduct(lanches);
                    break;
                case 2:
                    RemoveProduct(lanches);
                    break;
                case 3:
                    AddStock(lanches);
                    break;
                case 4:
                    MainMenu(lanches);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void PurchaseMenu(List<Lanches> lanches)
        {
            Console.WriteLine("");
            Console.WriteLine("1 - Mostrar todos os produtos existentes");
            Console.WriteLine("2 - Mostrar apenas as comidas");
            Console.WriteLine("3 - Mostrar apenas as bebidas");
            Console.WriteLine("4 - Retornar ao menu inicial");
            Console.WriteLine("5 - Cancelar");
            Console.WriteLine("Por favor, digite o número da opção que você deseja acessar.");

            int convertedUserAnswer = Navigation.AnswerTest("1", "2", "3", "4", "5");

            switch (convertedUserAnswer)
            {
                case 1:
                    foreach (Lanches item in lanches)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Nome: {item.Name}\nPreço: {item.Price}\nTipo: {item.Type}\nQuantidade em estoque: {item.Amount}\nID: {item.ID}");
                    }

                    Console.WriteLine("Qual o ID do item que você deseja comprar?");
                    string toBePurchasedItemID = Console.ReadLine();

                    bool toBePurchasedItemIDTest = int.TryParse(toBePurchasedItemID, out int convertedToBePurchasedItemID);
                    Lanches toBePurchasedItem = lanches.Find(item => item.ID == convertedToBePurchasedItemID);

                    while (toBePurchasedItem == null || toBePurchasedItemIDTest == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Não existe nenhum item cadastrado com esse ID. Por favor, insira um ID válido");

                        toBePurchasedItemID = Console.ReadLine();
                        toBePurchasedItemIDTest = int.TryParse(toBePurchasedItemID, out convertedToBePurchasedItemID);
                        toBePurchasedItem = lanches.Find(item => item.ID == convertedToBePurchasedItemID);
                    }

                    Console.WriteLine("Quantos itens você deseja adquirir?");
                    string toBePurchasedItemAmount = Console.ReadLine();

                    bool toBePurchasedItemAmountTest = int.TryParse(toBePurchasedItemAmount, out int convertedToBePurchasedItemAmount);

                    while (toBePurchasedItemAmountTest == false || convertedToBePurchasedItemAmount> toBePurchasedItem.Amount)
                    {
                        Console.WriteLine("Não foi possível efetuar a compra. Por favor, insira uma quantidade de itens menor ou igual a em estoque");
                        Console.WriteLine($"Nome: {toBePurchasedItem.Name}\nQuantidade em estoque: {toBePurchasedItem.Amount}");

                        toBePurchasedItemAmount = Console.ReadLine();
                        toBePurchasedItemAmountTest = int.TryParse(toBePurchasedItemAmount, out convertedToBePurchasedItemAmount);
                    }

                    toBePurchasedItem.Amount -= convertedToBePurchasedItemAmount;

                    string fileName = "desafiolanches.json";
                    string path = Path.Combine(Environment.CurrentDirectory, fileName);
                    File.WriteAllText(path, JsonConvert.SerializeObject(lanches));
                        
                    Console.WriteLine("");
                    Console.WriteLine("Parabéns! Compra realizada com sucesso.");

                    PurchaseMenu(lanches);
                    break;

                case 2:
                    foreach (Lanches item in lanches)
                    {
                        if (item.Type == "Comida")
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"Nome: {item.Name}\nPreço: R$ {item.Price}\nQuantidade em estoque: {item.Amount}\nID: {item.ID}");
                        }
                    }

                    Console.WriteLine("Qual o ID do item que você deseja comprar?");
                    toBePurchasedItemID = Console.ReadLine();

                    toBePurchasedItemIDTest = int.TryParse(toBePurchasedItemID, out convertedToBePurchasedItemID);

                    toBePurchasedItem = lanches.Find(item => item.ID == convertedToBePurchasedItemID);
                    while (toBePurchasedItem == null || toBePurchasedItemIDTest == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Não existe nenhum item cadastrado com esse ID. Por favor, insira um ID válido");

                        toBePurchasedItemID = Console.ReadLine();
                        toBePurchasedItemIDTest = int.TryParse(toBePurchasedItemID, out convertedToBePurchasedItemID);
                        toBePurchasedItem = lanches.Find(item => item.ID == convertedToBePurchasedItemID);
                    }

                    Console.WriteLine("Quantos itens você deseja adquirir?");

                    toBePurchasedItemAmount = Console.ReadLine();

                    toBePurchasedItemAmountTest = int.TryParse(toBePurchasedItemAmount, out convertedToBePurchasedItemAmount);

                    while (toBePurchasedItemAmountTest == false || convertedToBePurchasedItemAmount > toBePurchasedItem.Amount)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Não foi possível efetuar a compra. Por favor, insira uma quantidade de itens menor ou igual a em estoque");
                        Console.WriteLine($"Nome: {toBePurchasedItem.Name}\nQuantidade em estoque: {toBePurchasedItem.Amount}");

                        toBePurchasedItemAmount = Console.ReadLine();
                        toBePurchasedItemAmountTest = int.TryParse(toBePurchasedItemAmount, out convertedToBePurchasedItemAmount);
                    }

                    toBePurchasedItem.Amount -= convertedToBePurchasedItemAmount;

                    fileName = "desafiolanches.json";
                    path = Path.Combine(Environment.CurrentDirectory, fileName);
                    File.WriteAllText(path, JsonConvert.SerializeObject(lanches));

                    Console.WriteLine("");
                    Console.WriteLine("Parabéns! Compra realizada com sucesso.");

                    PurchaseMenu(lanches);
                    break;

                case 3:
                    foreach (Lanches item in lanches)
                    {
                        if (item.Type == "Bebida")
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"Nome: {item.Name}\nPreço: R$ {item.Price}\nQuantidade em estoque: {item.Amount}\nID: {item.ID}");
                        }
                    }

                    Console.WriteLine("Qual o ID do item que você deseja comprar?");
                    toBePurchasedItemID = Console.ReadLine();

                    toBePurchasedItemIDTest = int.TryParse(toBePurchasedItemID, out convertedToBePurchasedItemID);

                    toBePurchasedItem = lanches.Find(item => item.ID == convertedToBePurchasedItemID);
                    while (toBePurchasedItem == null || toBePurchasedItemIDTest == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Não existe nenhum item cadastrado com esse ID. Por favor, insira um ID válido");

                        toBePurchasedItemID = Console.ReadLine();
                        toBePurchasedItemIDTest = int.TryParse(toBePurchasedItemID, out convertedToBePurchasedItemID);
                        toBePurchasedItem = lanches.Find(item => item.ID == convertedToBePurchasedItemID);
                    }

                    Console.WriteLine("Quantos itens você deseja adquirir?");
                    toBePurchasedItemAmount = Console.ReadLine();

                    toBePurchasedItemAmountTest = int.TryParse(toBePurchasedItemAmount, out convertedToBePurchasedItemAmount);

                    while (toBePurchasedItemAmountTest == false || convertedToBePurchasedItemAmount > toBePurchasedItem.Amount)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Não foi possível efetuar a compra. Por favor, insira uma quantidade de itens menor ou igual a em estoque");
                        Console.WriteLine($"Nome: {toBePurchasedItem.Name}\nQuantidade em estoque: {toBePurchasedItem.Amount}");

                        toBePurchasedItemAmount = Console.ReadLine();
                        toBePurchasedItemAmountTest = int.TryParse(toBePurchasedItemAmount, out convertedToBePurchasedItemAmount);
                    }

                    toBePurchasedItem.Amount -= convertedToBePurchasedItemAmount;

                    fileName = "desafiolanches.json";
                    path = Path.Combine(Environment.CurrentDirectory, fileName);
                    File.WriteAllText(path, JsonConvert.SerializeObject(lanches));

                    Console.WriteLine("");
                    Console.WriteLine("Parabéns! Compra realizada com sucesso.");

                    PurchaseMenu(lanches);
                    break;

                case 4:
                    MainMenu(lanches);
                    break;

                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void AddProduct(List<Lanches> lanches)
        {
            Console.WriteLine("");
            Console.WriteLine("Você deseja mesmo adicionar um novo produto?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");

            int convertedUserAnswer = Navigation.AnswerTest("1", "2");

            switch (convertedUserAnswer)
            {
                case 1:
                    Console.WriteLine("Qual o nome do produto que você deseja adicionar?");
                    string newItemName = Console.ReadLine();
                    bool newItemNameTest = string.IsNullOrWhiteSpace(newItemName);

                    foreach (Lanches item in lanches)
                    {
                        while (item.Name == newItemName || newItemNameTest)
                        {
                            Console.WriteLine("Esse nome já está cadastrado no sistema ou é inválido. Por favor, insira um nome válido");
                            newItemName = Console.ReadLine();
                            newItemNameTest = string.IsNullOrWhiteSpace(newItemName);
                        }
                    }

                    newItemName = (newItemName.Length == 1 ? Convert.ToString(char.ToUpper(newItemName[0])) : newItemName = char.ToUpper(newItemName[0]) + newItemName[1..]);
                    
                    Console.WriteLine("Qual o tipo do produto que você deseja adicionar?");
                    Console.WriteLine("1 - Comida");
                    Console.WriteLine("2 - Bebida");

                    convertedUserAnswer = Navigation.AnswerTest("1", "2");

                    string newItemType = (convertedUserAnswer == 1 ? "Comida" : "Bebida");

                    Console.WriteLine("Qual o preço do produto que você deseja adicionar?");
                    string newItemPrice = (Console.ReadLine());

                    bool newItemPriceTest = Double.TryParse(newItemPrice, out double convertedNewItemPrice);

                    while (newItemPriceTest == false || convertedNewItemPrice < 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor, digite um preço válido para o produto.");
                        newItemPrice = Console.ReadLine();
                        newItemPriceTest = Double.TryParse(newItemPrice, out convertedNewItemPrice);
                    }

                    Console.WriteLine("Qual o ID do produto que você deseja adicionar?");
                    string newItemID = Console.ReadLine();

                    bool newItemIDTest = int.TryParse(newItemID, out int convertedNewItemID);

                    foreach (Lanches item in lanches)
                    {
                        while (item.ID == convertedNewItemID || newItemIDTest == false || convertedNewItemID < 1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Esse ID já está cadastrado no sistema ou é inválido. Por favor, insira um ID válido");

                            newItemID = (Console.ReadLine());
                            newItemIDTest = int.TryParse(newItemID, out convertedNewItemID);
                        }
                    }
                    
                    Console.WriteLine("Quantas unidades você deseja adicionar ao estoque desse produto?");
                    string newItemAmount = Console.ReadLine();

                    bool newProductAmountTest = int.TryParse(newItemAmount, out int convertedNewItemAmount);

                    while (newProductAmountTest == false || convertedNewItemAmount < 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor, digite uma quantidade válida para adicionar ao estoque");

                        newItemAmount = (Console.ReadLine());
                        newProductAmountTest = int.TryParse(newItemAmount, out convertedNewItemAmount);
                    }

                    Console.WriteLine("");
                    Console.WriteLine($"Nome: {newItemName}\nPreço: R$ {convertedNewItemPrice}\nTipo: {newItemType}\nQuantidade em estoque: {convertedNewItemAmount} unidades\nID: {convertedNewItemID}");
                    Console.WriteLine("Os dados estão corretos?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");

                    convertedUserAnswer = Navigation.AnswerTest("1", "2");

                    switch (convertedUserAnswer)
                    {
                        case 1:
                            Lanches item = new(newItemName, convertedNewItemPrice, newItemType, convertedNewItemAmount, convertedNewItemID);
                            lanches.Insert(convertedNewItemID-1, item);

                            string fileName = "desafiolanches.json";
                            string path = Path.Combine(Environment.CurrentDirectory, fileName);
                            File.WriteAllText(path, JsonConvert.SerializeObject(lanches));

                            Console.WriteLine("Produto adicionado com sucesso");

                            MainMenu(lanches);
                            break;
                        case 2:
                            AddProduct(lanches);
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("1 - Retornar à etapa anterior");
                    Console.WriteLine("2 - Retornar ao menu inicial");
                    Console.WriteLine("3 - Cancelar");
                    Console.WriteLine("Por favor, digite o número da opção que você deseja acessar.");

                    convertedUserAnswer = Navigation.AnswerTest("1", "2", "3");

                    switch (convertedUserAnswer)
                    {
                        case 1:
                            StockMenu(lanches);
                            break;
                        case 2:
                            MainMenu(lanches);
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                    break;
            }
        }
        public static void RemoveProduct(List<Lanches> lanches)
        {
            Console.WriteLine("");
            Console.WriteLine("Você deseja mesmo remover um produto?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");

            int convertedUserAnswer = Navigation.AnswerTest("1", "2");

            switch (convertedUserAnswer)
            {
                case 1:
                    foreach (Lanches item in lanches)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Nome: {item.Name}\nID: {item.ID}");
                    }


                    Console.WriteLine("Qual o ID do produto que você deseja remover?");
                    string toBeRemovedItemID = Console.ReadLine();
                   
                    bool toBeRemovedItemIDTest = int.TryParse(toBeRemovedItemID, out int convertedToBeRemovedItemID);

                    Lanches toBeRemovedItem = lanches.Find(item => item.ID == convertedToBeRemovedItemID);

                    while (toBeRemovedItem == null || toBeRemovedItemIDTest == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Não existe nenhum item cadastrado com esse ID. Por favor, insira um ID válido");

                        toBeRemovedItemID = Console.ReadLine();
                        toBeRemovedItemIDTest = int.TryParse(toBeRemovedItemID, out convertedToBeRemovedItemID);
                        toBeRemovedItem = lanches.Find(item => item.ID == convertedToBeRemovedItemID);
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Você está prestes a remover o produto {toBeRemovedItem.Name}, cujo ID é {toBeRemovedItem.ID}.");
                    Console.WriteLine("Você tem certeza?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");

                    convertedUserAnswer = Navigation.AnswerTest("1", "2");

                    switch (convertedUserAnswer)
                    {
                        case 1:
                            lanches.Remove(toBeRemovedItem);

                            Console.WriteLine("Produto removido com sucesso");

                            string fileName = "desafiolanches.json";
                            string path = Path.Combine(Environment.CurrentDirectory, fileName);
                            File.WriteAllText(path, JsonConvert.SerializeObject(lanches));

                            MainMenu(lanches);
                            break;
                        case 2:
                            RemoveProduct(lanches);
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("");
                    Console.WriteLine("1 - Retornar à etapa anterior");
                    Console.WriteLine("2 - Retornar ao menu inicial");
                    Console.WriteLine("3 - Cancelar");
                    Console.WriteLine("Por favor, digite o número da opção que você deseja acessar.");

                    convertedUserAnswer = Navigation.AnswerTest("1", "2", "3");

                    switch (convertedUserAnswer)
                    {
                        case 1:
                            StockMenu(lanches);
                            break;
                        case 2:
                            MainMenu(lanches);
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                    break;
            }
        }
        public static void AddStock(List<Lanches> lanches)
        {
            Console.WriteLine("");
            Console.WriteLine("Você deseja mesmo adicionar estoque à algum produto?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");

            int convertedUserAnswer = Navigation.AnswerTest("1", "2");

            switch (convertedUserAnswer)
            {
                case 1:
                    foreach (Lanches item in lanches)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Nome: {item.Name}\nID:{item.ID}");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Qual o ID do produto que você deseja adicionar estoque?");
                    string toBeAddedStockItemID = Console.ReadLine();
                   
                    bool toBeAddedStockItemIDTest = int.TryParse(toBeAddedStockItemID, out int convertedToBeAddedStockItemID);

                    Lanches toBeAddedStockItem = lanches.Find(item => item.ID == convertedToBeAddedStockItemID);

                    while (toBeAddedStockItem == null || toBeAddedStockItemIDTest == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Não existe nenhum item cadastrado com esse ID. Por favor, insira um ID válido");

                        toBeAddedStockItemID = Console.ReadLine();
                        toBeAddedStockItemIDTest = int.TryParse(toBeAddedStockItemID, out convertedToBeAddedStockItemID);
                        toBeAddedStockItem = lanches.Find(lanches => lanches.ID == convertedToBeAddedStockItemID);
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Quantas unidades você deseja adicionar ao produto {toBeAddedStockItem.Name}?");
                    string amountToBeAdded = Console.ReadLine();

                    bool amountToBeAddedTest = int.TryParse(amountToBeAdded, out int convertedAmountToBeAdded);

                    while (convertedAmountToBeAdded <= 0 || amountToBeAddedTest == false)
                    {
                        Console.WriteLine("Por favor, insira uma quantidade válida");
                        amountToBeAdded = Console.ReadLine();
                        amountToBeAddedTest = int.TryParse(amountToBeAdded, out convertedAmountToBeAdded);
                    }

                    toBeAddedStockItem.Amount += convertedAmountToBeAdded;

                    string fileName = "desafiolanches.json";
                    string path = Path.Combine(Environment.CurrentDirectory, fileName);
                    File.WriteAllText(path, JsonConvert.SerializeObject(lanches));

                    Console.WriteLine("");
                    Console.WriteLine("Estoque adicionado com sucesso");

                    MainMenu(lanches);
                    
                    break;
                case 2:
                    Console.WriteLine("");
                    Console.WriteLine("1 - Retornar à etapa anterior");
                    Console.WriteLine("2 - Retornar ao menu inicial");
                    Console.WriteLine("3 - Cancelar");
                    Console.WriteLine("Por favor, digite o número da opção que você deseja acessar.");

                    convertedUserAnswer = Navigation.AnswerTest("1", "2", "3");

                    switch (convertedUserAnswer)
                    {
                        case 1:
                            StockMenu(lanches);
                            break;
                        case 2:
                            MainMenu(lanches);
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                    break;
            }
        }
    }
}
