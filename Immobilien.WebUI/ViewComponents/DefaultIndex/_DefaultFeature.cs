using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultFeature : ViewComponent
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public _DefaultFeature(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = await _featureService.TGetListAsync();
            var featureList = _mapper.Map<List<ResultFeatureDto>>(datas);
            return View(featureList);
        }
    }
}
