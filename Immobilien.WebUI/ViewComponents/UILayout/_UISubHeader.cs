using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.SubHeaderDtos;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.UILayout
{
    public class _UISubHeader: ViewComponent
    {
        private readonly ISubHeaderService _subHeaderService;
        private readonly IMapper _mapper;
        public _UISubHeader(ISubHeaderService subHeaderService, IMapper mapper)
        {
            _subHeaderService = subHeaderService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = await _subHeaderService.TGetListAsync(); 
            var subHeaderList = _mapper.Map<List<ResultSubHeaderDto>>(datas);
            return View(subHeaderList);

        }
    }
}
