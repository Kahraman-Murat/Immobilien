using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Business.Validators;
using Immobilien.Dto.Dtos.QuestDtos;
using Immobilien.Dto.Dtos.SubHeaderDtos;
using Immobilien.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Immobilien.WebUI.Controllers
{
    public class SubHeaderController : Controller
    {
        private readonly ISubHeaderService _subHeaderService;
        private readonly IMapper _mapper;

        public SubHeaderController(ISubHeaderService subHeaderService, IMapper mapper)
        {
            _subHeaderService = subHeaderService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var datas = await _subHeaderService.TGetListAsync();
            var subHeaderList = _mapper.Map<List<ResultSubHeaderDto>>(datas);
            return View(subHeaderList);
        }

        public async Task<IActionResult> DeleteSubHeader(ObjectId id)
        {
            await _subHeaderService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateSubHeader()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubHeader(CreateSubHeaderDto createSubHeaderDto)
        {
            ModelState.Clear();
            var newSubHeader = _mapper.Map<SubHeader>(createSubHeaderDto);
            var validator = new SubHeaderValidator();
            var result = validator.Validate(newSubHeader);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.TryAddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _subHeaderService.TCreateAsync(newSubHeader);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateSubHeader(ObjectId id)
        {
            var datas = await _subHeaderService.TGetByIdAsync(id);
            var subHeader = _mapper.Map<UpdateSubHeaderDto>(datas);
            return View(subHeader);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubHeader(UpdateSubHeaderDto updateSubHeaderDto)
        {
            ModelState.Clear();
            var subHeader = _mapper.Map<SubHeader>(updateSubHeaderDto);
            var validator = new SubHeaderValidator();
            var result = validator.Validate(subHeader);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.TryAddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _subHeaderService.TUpdateAsync(subHeader);
            return RedirectToAction("Index");
        }
    }
}
