using ControleDeContatos.Models.Dtos;
using ControleDeContatos.Models.Entity;
using ControleDeContatos.Reposiorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
            
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatoModels = _contatoRepositorio.Listar();
            return View(contatoModels);
        }
        public IActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Novo(ContatoPost contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContatoModel contatoModel = _contatoRepositorio.Adicionar(contato);
                    TempData["Exito"] = $"Contato ({contatoModel.Nome}) salvo com sucesso!";
                    return new RedirectResult("/Contato/Index");
                }
                return View("Novo", contato);
            } catch(System.Exception error)
            {
                TempData["Error"] = $"Erro ao salvar contato, tente novamente.Detalhes do erro:!{error.Message}";
                return View("Index");
            }
            
            
        }
        
        public IActionResult Editar(long id)
        {
            ContatoModel contatoModel = _contatoRepositorio.buscarId(id);
            if(contatoModel != null)
            {
                ContatoPut contatoPut = new ContatoPut();
                contatoPut.id = id;
                contatoPut.Nome = contatoModel.Nome;
                contatoPut.Email = contatoModel.Email;
                contatoPut.Telefone = contatoModel.Telefone;
                return View(contatoPut);
            } else
            {
                return new RedirectResult("/Contato/Index");
            }
            
        }

        [HttpPost]
        public IActionResult Editar(ContatoPut contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContatoModel contatoModel = _contatoRepositorio.EditarContato(contato);
                    TempData["Exito"] = $"Contato {contatoModel.Nome} editado com sucesso!";
                    return new RedirectResult("/Contato/Index");
                }
                return View("Editar", contato);
            } catch (System.Exception error)
            {
                TempData["Error"] = $"Erro ao excluir contato, tente novamente.Detalhes do erro:{error.Message}!";
                return View("Index");

            }
            
            
        }

        public IActionResult Remover(long id)
        {
            try
            {
                bool v = _contatoRepositorio.DeletarContato(id);
                if (v)
                {
                    TempData["Exito"] = $"Contato excluido com sucesso!";
                } else
                {
                    TempData["Error"] = $"Erro ao excluir contato! Tente novamente.";
                }
                
                return new RedirectResult("/Contato/Index");
            } catch(System.Exception error)
            {
                TempData["Error"] = $"Erro ao excluir contato, tente novamente.Detalhes do erro:!{error.Message}";
                return View("Index");
            }
            
        }


    }
}
