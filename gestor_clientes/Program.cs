using gestor_clientes;

DbClientes db = new DbClientes();

//db.NovoUsuario("thiago", "thiago@gmail.com", 333222555, 333222555);

//db.NovaCompra(1, 100.2, "pedro");

//Inner join
dynamic data = db.ComprasCliente("pedro");
foreach (dynamic a in data)
{
    Console.WriteLine("Nome: "+a.nome);
    Console.WriteLine("Id produto: "+a.idproduto.ToString());
    Console.WriteLine("Quantidade: "+a.quantidade.ToString());
    Console.WriteLine("Preco: "+a.preco.ToString());
    Console.WriteLine("--------------------------");
}

dynamic media = db.MediaVendas();
Console.WriteLine("Media: " + media[0]);

dynamic total = db.TotalCaixa();
Console.WriteLine("Total: " + total[0]);