using ControleDeContatos.Models.Dtos;
using ControleDeContatos.Models.Entity;

namespace ControleDeContatos.Reposiorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> Listar();
        ContatoModel Adicionar(ContatoPost contato);

        ContatoModel buscarId(long id);

        ContatoModel EditarContato(ContatoPut contato);

        bool DeletarContato(long id);

    }
}
