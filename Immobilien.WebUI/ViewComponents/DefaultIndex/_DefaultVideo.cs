using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.VideoDtos;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultVideo : ViewComponent
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public _DefaultVideo(IMapper mapper, IVideoService videoService)
        {
            _mapper = mapper;
            _videoService = videoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = await _videoService.TGetListAsync();
            var videoList = _mapper.Map<List<ResultVideoDto>>(datas);
            return View(videoList);
        }
    }
}

