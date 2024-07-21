using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.QuestDtos;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultQuest : ViewComponent
    {
        private readonly IQuestService _questService;
        private readonly IMapper _mapper;

        public _DefaultQuest(IMapper mapper, IQuestService questService)
        {
            _mapper = mapper;
            _questService = questService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = await _questService.TGetListAsync();
            var questList = _mapper.Map<List<ResultQuestDto>>(datas);
            return View(questList);
        }
    }
}
