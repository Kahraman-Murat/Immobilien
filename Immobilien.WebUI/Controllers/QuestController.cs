using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Business.Validators;
using Immobilien.Dto.Dtos.QuestDtos;
using Immobilien.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Immobilien.WebUI.Controllers
{
    public class QuestController : Controller
    {
        private readonly IQuestService _questService;
        private readonly IMapper _mapper;

        public QuestController(IQuestService questService, IMapper mapper)
        {
            _questService = questService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var datas = await _questService.TGetListAsync();
            var questList = _mapper.Map<List<ResultQuestDto>>(datas);
            return View(questList);
        }

        public async Task<IActionResult> DeleteQuest(ObjectId id)
        {
            await _questService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateQuest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuest(CreateQuestDto createQuestDto)
        {
            ModelState.Clear();
            var newQuest = _mapper.Map<Quest>(createQuestDto);
            var validator = new QuestionValidator();
            var result = validator.Validate(newQuest);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.TryAddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _questService.TCreateAsync(newQuest);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateQuest(ObjectId id)
        {
            var datas = await _questService.TGetByIdAsync(id);
            var quest = _mapper.Map<UpdateQuestDto>(datas);
            return View(quest);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuest(UpdateQuestDto updateQuestDto)
        {
            var quest = _mapper.Map<Quest>(updateQuestDto);
            await _questService.TUpdateAsync(quest);
            return RedirectToAction("Index");
        }
    }
}
