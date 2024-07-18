using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.FeatureDtos;
using Immobilien.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Immobilien.WebUI.Controllers
{
    public class FeatureController : Controller
    {

        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var datas = await _featureService.TGetListAsync();
            var featureList = _mapper.Map<List<ResultFeatureDto>>(datas);
            return View(featureList);
        }

        public async Task<IActionResult> DeleteFeature(ObjectId id)
        {
            await _featureService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateFeature(ObjectId id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var newFeature = _mapper.Map<Feature>(createFeatureDto);
            await _featureService.TCreateAsync(newFeature);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFeature(ObjectId id)
        {
            var datas = await _featureService.TGetByIdAsync(id);
            var feature = _mapper.Map<UpdateFeatureDto>(datas);
            return View(feature);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            await _featureService.TUpdateAsync(feature);
            return RedirectToAction("Index");
        }
    }
}
