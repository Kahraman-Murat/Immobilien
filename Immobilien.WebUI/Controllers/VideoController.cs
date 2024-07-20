using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Business.Validators;
using Immobilien.Dto.Dtos.VideoDtos;
using Immobilien.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Immobilien.WebUI.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public VideoController(IVideoService videoService, IMapper mapper)
        {
            _videoService = videoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var datas = await _videoService.TGetListAsync();
            var videoList = _mapper.Map<List<ResultVideoDto>>(datas);
            return View(videoList);
        }

        public async Task<IActionResult> DeleteVideo(ObjectId id)
        {
            await _videoService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideoDto createVideoDto)
        {
            ModelState.Clear();
            var newVideo = _mapper.Map<Video>(createVideoDto);
            var validator = new VideoValidator();
            var result = validator.Validate(newVideo);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.TryAddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _videoService.TCreateAsync(newVideo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateVideo(ObjectId id)
        {
            var datas = await _videoService.TGetByIdAsync(id);
            var video = _mapper.Map<UpdateVideoDto>(datas);
            return View(video);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(UpdateVideoDto updateVideoDto)
        {
            ModelState.Clear();
            var video = _mapper.Map<Video>(updateVideoDto);
            var validator = new VideoValidator();
            var result = validator.Validate(video);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.TryAddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _videoService.TUpdateAsync(video);
            return RedirectToAction("Index");
        }
    }
}
