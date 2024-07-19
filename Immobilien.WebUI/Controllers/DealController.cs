using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.DealDtos;
using Immobilien.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Immobilien.WebUI.Controllers
{
    public class DealController : Controller
    {

        private readonly IDealService _dealService;
        private readonly IMapper _mapper;

        public DealController(IDealService dealService, IMapper mapper)
        {
            _dealService = dealService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var datas = await _dealService.TGetListAsync();
            var dealList = _mapper.Map<List<ResultDealDto>>(datas);
            return View(dealList);
        }

        public async Task<IActionResult> DeleteDeal(ObjectId id)
        {
            await _dealService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateDeal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeal(CreateDealDto createDealDto)
        {
            var newDeal = _mapper.Map<Deal>(createDealDto);
            await _dealService.TCreateAsync(newDeal);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateDeal(ObjectId id)
        {
            var datas = await _dealService.TGetByIdAsync(id);
            var deal = _mapper.Map<UpdateDealDto>(datas);
            return View(deal);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDeal(UpdateDealDto updateDealDto)
        {
            var deal = _mapper.Map<Deal>(updateDealDto);
            await _dealService.TUpdateAsync(deal);
            return RedirectToAction("Index");
        }

    }
}
