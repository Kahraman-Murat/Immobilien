using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultProduct : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public _DefaultProduct(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = await _productService.TGetListAsync();
            var productList = _mapper.Map<List<ResultProductDto>>(datas);
            return View(productList);
        }
    }
}
