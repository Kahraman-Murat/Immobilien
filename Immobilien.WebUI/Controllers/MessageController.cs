using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.MessageDtos;
using Immobilien.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Immobilien.WebUI.Controllers
{
    public class MessageController : Controller
    {

        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var datas = await _messageService.TGetListAsync();
            var messageList = _mapper.Map<List<ResultMessageDto>>(datas);
            return View(messageList);
        }

        public async Task<IActionResult> DeleteMessage(ObjectId id)
        {
            await _messageService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            var newMessage = _mapper.Map<Message>(createMessageDto);
            await _messageService.TCreateAsync(newMessage);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MessageDetails(ObjectId id)
        {
            var data = await _messageService.TGetByIdAsync(id);
            var message = _mapper.Map<ResultMessageDto>(data);
            return View(message);
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        //{
        //    var message = _mapper.Map<Message>(updateMessageDto);
        //    await _messageService.TUpdateAsync(message);
        //    return RedirectToAction("Index");
        //}
    }
}
