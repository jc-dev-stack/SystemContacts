using Microsoft.AspNetCore.Mvc;
using SystemContacts.Models;
using SystemContacts.Repositories;

namespace SystemContacts.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.GetAll();
            return View(contacts);
        }
        public IActionResult Criar()
        { 
            return View();
        } 
        public IActionResult Editar(int id)
        {   ContactModel? contact = _contactRepository.GetById(id);
            if (contact == null) throw new Exception($"User not found");
            return View(contact);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContactModel? contact = _contactRepository.GetById(id);
            if (contact == null) throw new Exception("User not found");
            return View(contact);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool deleted = _contactRepository.Delete(id);
                if (deleted)
                {
                    TempData["MessageSuccess"] = "Contato apagado com sucesso!";
                }
                else
                {
                    throw new Exception("Não deleteado");
                }
                return RedirectToAction("Index");
            }
            catch (Exception error) {
                TempData["MessageError"] = $"Ops não conseguimos apagar o contatato, tente novamente\nDetalhe do error:{error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Add(contact);
                    TempData["MessageSuccess"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contact);
            }catch (Exception error)
            {
                TempData["MessageError"] = $"Ops não conseguimos cadastrar o contatato, tente novamente\nDetalhe do error:{error.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Update(contact);
                    TempData["MessageSuccess"] = "Contato editado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            catch (Exception error)
            {
                TempData["MessageError"] = $"Ops não conseguimos editar o contatato, tente novamente\\nDetalhe do error:{error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
