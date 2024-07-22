using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.CounterDtos;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultCounter : ViewComponent
    {
        private readonly ICounterService _counterService;
        private readonly IMapper _mapper;

        public _DefaultCounter(ICounterService counterService, IMapper mapper)
        {
            _counterService = counterService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = await _counterService.TGetListAsync();
            var counterList = _mapper.Map<List<ResultCounterDto>>(datas);
            return View(counterList);
        }

    }
}
