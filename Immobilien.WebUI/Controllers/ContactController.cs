﻿using AutoMapper;
using Immobilien.Business.Abstract;
using Immobilien.Dto.Dtos.ContactDtos;
using Immobilien.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Immobilien.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var datas = await _contactService.TGetListAsync();
            var contactList = _mapper.Map<List<ResultContactDto>>(datas);
            return View(contactList);
        }

        public async Task<IActionResult> DeleteContact(ObjectId id)
        {
            await _contactService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateContact(ObjectId id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var newContact = _mapper.Map<Contact>(createContactDto);
            await _contactService.TCreateAsync(newContact);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateContact(ObjectId id)
        {
            var datas = await _contactService.TGetByIdAsync(id);
            var contact = _mapper.Map<UpdateContactDto>(datas);
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var contact = _mapper.Map<Contact>(updateContactDto);
            await _contactService.TUpdateAsync(contact);
            return RedirectToAction("Index");
        }
    }
}