using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultBanner : ViewComponent
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;
        public _DefaultBanner(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = await _bannerService.TGetListAsync();
            var bannerList = _mapper.Map<List<ResultBannerDto>>(datas);
            return View(bannerList);
        }
    }
}
