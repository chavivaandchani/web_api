using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _IProductService;
        public readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService IProductService, IMapper mapper, ILogger<ProductsController> logger)
        {
            _IProductService = IProductService;
            _mapper = mapper;
            _logger = logger;
        }
       

    // GET: api/<ProductsController>
    [HttpGet]
        public async Task<List<ProductDto>>getProducts([FromQuery]string? name, [FromQuery] int?[] categoryIds, [FromQuery] int? minPrice, [FromQuery] int? maxPrice)
                                
        {
           // int a = 0;
           // int b = 100 / a;
 

          // return await _IProductService.getProducts( name,categoryIds, minPrice, maxPrice);
             List<Product> products= await _IProductService.getProducts(name, categoryIds, minPrice, maxPrice);
            List<ProductDto> productsDTO=_mapper.Map<List<Product> , List<ProductDto> >(products);
          return productsDTO;
        }

        /*    // GET api/<ProductsController>/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
            }

            // POST api/<ProductsController>
            [HttpPost]
            public void Post([FromBody] string value)
            {
            }

            // PUT api/<ProductsController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<ProductsController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }*/
    }
}
