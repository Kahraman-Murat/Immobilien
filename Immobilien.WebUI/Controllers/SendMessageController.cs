using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.MessageDtos;
using Immobilien.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.Controllers
{
    public class SendMessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public SendMessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var newMessage = _mapper.Map<Message>(createMessageDto);
            await _messageService.TCreateAsync(newMessage);
            return RedirectToAction("Index","Default");
        }
    }
}
