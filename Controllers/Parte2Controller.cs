using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	
	[ApiController]
	[Route("[controller]")]
	public class Parte2Controller :  ControllerBase
	{
		/// <summary>
		/// Precisamos fazer algumas alterações:
		/// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
		/// ok 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
		/// ok 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
		/// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
		/// 
		/// </summary>
		TestDbContext _ctx;
		CustomerService _CustomerService;
        public Parte2Controller(TestDbContext ctx, CustomerService customerService)
		{
			_ctx = ctx;
			_CustomerService = customerService;
		}
	
		[HttpGet("products")]
		public ProductList ListProducts(int page)
		{
			var productService = new ProductService(_ctx);
			return productService.ListProducts(page);
		}

		[HttpGet("customers")]
		public CustomerList ListCustomers(int page)
		{
			return _CustomerService.ListCustomers(page);
		}
	}
}
