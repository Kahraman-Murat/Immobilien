using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultContact : ViewComponent
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public _DefaultContact(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = await _contactService.TGetListAsync();
            var contactList = _mapper.Map<List<ResultContactDto>>(datas);
            return View(contactList);
        }
    }
}
