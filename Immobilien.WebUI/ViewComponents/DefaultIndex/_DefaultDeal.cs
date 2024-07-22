using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.DealDtos;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultDeal : ViewComponent
    {
        private readonly IDealService _dealService;
        private readonly IMapper _mapper;
        public _DefaultDeal(IDealService dealService, IMapper mapper)
        {
            _dealService = dealService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = await _dealService.TGetListAsync();
            var dealList = _mapper.Map<List<ResultDealDto>>(datas);
            return View(dealList);
        }
    }
}
