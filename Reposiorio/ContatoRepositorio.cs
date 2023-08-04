using ControleDeContatos.Data;
using ControleDeContatos.Models.Dtos;
using ControleDeContatos.Models.Entity;

namespace ControleDeContatos.Reposiorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
            
        }


        public List<ContatoModel> Listar()
        {
            return _bancoContext.Contato.ToList();
        }


        public ContatoModel Adicionar(ContatoPost contato)
        {
            ContatoModel contatoModel = new ContatoModel();
            contatoModel.Nome = contato.Nome;
            contatoModel.Email = contato.Email;
            contatoModel.Telefone = contato.Telefone;
            _bancoContext.Contato.Add(contatoModel);
            _bancoContext.SaveChanges();
            return contatoModel;
            
        }

        public ContatoModel buscarId(long id)
        {
            return _bancoContext.Contato.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel EditarContato(ContatoPut contato)
        {
            ContatoModel contatoModel = buscarId(contato.id);
            if(contatoModel == null) { throw new Exception("Erro ao editar contato"); }
          
            contatoModel.Nome = contato.Nome;
            contatoModel.Email = contato.Email;
            contatoModel.Telefone = contato.Telefone;
            _bancoContext.Contato.Update(contatoModel);
            _bancoContext.SaveChanges();

            return contatoModel;
        }

        public bool DeletarContato(long id)
        {
            ContatoModel contatoModel = buscarId(id);
            if (contatoModel == null) { throw new Exception("Erro ao excluir contato"); }
            _bancoContext.Contato.Remove(contatoModel);
            _bancoContext.SaveChanges();
            return true;
            
        }
    }
}
