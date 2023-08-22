using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.PhoneBook;
using PhoneBook.Application.PhoneBook.Commands.CreatePhoneBook;
using PhoneBook.Application.PhoneBook.Commands.EditPhoneBook;
using PhoneBook.Application.PhoneBook.Queries;
using PhoneBook.Application.PhoneBook.Queries.GetAllPhoneBooks;
using PhoneBook.Application.PhoneBook.Queries.GetContactDetailsByPhoneNumber;

namespace PhoneBook.MVC.Controllers
{
    public class PhoneBookController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PhoneBookController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var phoneBookContacts = await _mediator.Send(new GetAllPhoneBooksQuery());
            return View(phoneBookContacts);
        }
        [Route("PhoneBook/{PhoneNumber}/Details")]
        public async Task<IActionResult> Details(string phoneNumber)
        {
            var dto = await _mediator.Send(new GetContactDetailsByPhoneNumberQuery(phoneNumber));
            return View(dto);
        }


        [Route("PhoneBook/{PhoneNumber}/Edit")]
        public async Task<IActionResult> Edit(string phoneNumber)
        {
            var dto =await _mediator.Send( new GetContactDetailsByPhoneNumberQuery(phoneNumber));

            EditPhoneBookCommand model = _mapper.Map<EditPhoneBookCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("PhoneBook/{PhoneNumber}/Edit")]
        public async Task<IActionResult> Edit(string phoneNumber, EditPhoneBookCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreatePhoneBookCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
    }
}
