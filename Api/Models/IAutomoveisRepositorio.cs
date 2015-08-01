using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    /// <summary>
    /// Interface que define as funções para gerenciamento de automóveis.
    /// </summary>
    public interface IAutomoveisRepositorio
    {
        /// <summary>
        /// Retorna todos os automóveis disponíveis.
        /// </summary>
        /// <returns>Lista com os automóveis.</returns>
        List<Automovel> GetTodos();

        /// <summary>
        /// Retorna um automóvel segundo um ID.
        /// </summary>
        /// <param name="id">ID do automóvel a buscar.</param>
        /// <returns>Automóvel correspondente ao ID.</returns>
        Automovel GetId(int id);

        /// <summary>
        /// Retorna os automóveis do modelo parametrizado.
        /// </summary>
        /// <param name="modelo">Modelo para pesquisar por automóveis.</param>
        /// <returns>Lista com os automóveis deste modelo.</returns>
        List<Automovel> GetModelo(string modelo);

        /// <summary>
        /// Retorna os autmóveis que tem este ano.
        /// </summary>
        /// <param name="ano">Ano para buscar por automóveis.</param>
        /// <returns>Retorna a lista de automóveis deste ano.</returns>
        List<Automovel> GetAno(int ano);
        
        /// <summary>
        /// Retorna a lista de automóveis desta marca.
        /// </summary>
        /// <param name="marca">Marca para buscar automóveis.</param>
        /// <returns>Lista com os automóveis desta marca.</returns>
        List<Automovel> GetMarca(string marca);

        /// <summary>
        /// Atualiza um automóvel.
        /// </summary>
        /// <param name="auto">Automóvel com as informações atualizadas.</param>
        /// <returns>True caso tenha atualizado, false caso contrário.</returns>
        bool Update(Automovel auto);

        /// <summary>
        /// Deleta um automóvel da lista.
        /// </summary>
        /// <param name="id">ID do automóvel a remover.</param>
        /// <returns>True caso tenha removido, false caso contrário.</returns>
        bool Delete(int id);

        /// <summary>
        /// Retorna todos os opcionais.
        /// </summary>
        /// <returns>Opcionais disponíveis.</returns>
        List<Opcional> GetOpcionais();

        /// <summary>
        /// Retorna todas as marcas.
        /// </summary>
        /// <returns>Listas com as marcas disponíveis.</returns>
        List<Marca> GetMarcas();
    }
}
