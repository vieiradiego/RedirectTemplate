using Microsoft.AspNetCore.Mvc;
using RedirectTemplate.Service;
using Swashbuckle.AspNetCore.Annotations;

namespace RedirectTemplate.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// GERAR a URL para redirecionamento.
        /// </summary>
        /// <remarks>
        /// Retorna a URL de redirecionamento
        /// </remarks>
        /// <returns>O retorno é a URL conforme o parâmetro informado</returns>
        /// <param name="code"></param>
        /// <param name="rack"></param>
        [HttpGet]
        [SwaggerResponse(301)] //Permanent Redirect
        [SwaggerResponse(400)] //BadRequest
        public IActionResult Racks([FromQuery] string code, string rack)
        {
            if ((string.IsNullOrWhiteSpace(code)) || (string.IsNullOrWhiteSpace(rack))) return BadRequest();
            return RedirectPermanent(_productService.Racks(code, rack));
        }
    }
}
