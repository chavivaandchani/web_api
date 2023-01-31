using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class CategorysController : ControllerBase
    {
        private readonly ICategoryService _ICategoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<CategorysController> _logger;

        public CategorysController(ICategoryService ICategoryService, IMapper mapper,ILogger<CategorysController>logger)
        {
            _ICategoryService = ICategoryService;
            _mapper = mapper;
            _logger = logger;
        }
        // GET: api/<ValuesController>
        [HttpGet]
       // public async Task<IEnumerable<Category>> getCategories()
       // {
           // return await _ICategoryService.getCategories();   
                
             //   }
        public async Task<IEnumerable<CategoryDTO>> getCategories()
        {
            _logger.LogInformation("im in categories");
            IEnumerable<Category> categories = await _ICategoryService.getCategories();
            IEnumerable<CategoryDTO> res = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return res;

        }

    } 
}
