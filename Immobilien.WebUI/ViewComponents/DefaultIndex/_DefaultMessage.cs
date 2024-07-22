using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultMessage : ViewComponent
    {
        //private readonly IMessageService _messageService;
        //private readonly IMapper _mapper;
        //public _DefaultMessage(IMessageService messageService, IMapper mapper)
        //{
        //    _messageService = messageService;
        //    _mapper = mapper;
        //}

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var datas = await _messageService.TGetListAsync();
        //    var messageList = _mapper.Map<List<ResultMessageDto>>(datas);
        //    return View(messageList);
        //}

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
