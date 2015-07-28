using GerenciadorAutomoveis.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Configuration;
using System.Text;

namespace GerenciadorAutomoveis.Controllers
{
    public class AutomovelController : ApiController
    {
        readonly IAutomoveisRepositorio repositorio = new AutomoveisRepositorio();

        public IEnumerable<Automovel> Get()
        {
            List<Automovel> automoveis = repositorio.GetTodos();

            if (automoveis == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
                yield break;
            }

            foreach (Automovel auto in automoveis)
                yield return auto;
        }

        public Automovel Get(int id)
        {
            Automovel auto = repositorio.GetId(id);

            if (auto == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));

            return auto;
        }

        public IEnumerable<Automovel> Get(int tipo, string termo)
        {
            List<Automovel> automoveis = null;
            int ano = 0;

            if (tipo == 0)
            {
                automoveis = repositorio.GetModelo(termo);
            }
            else if (tipo == 1)
            {
                automoveis = repositorio.GetMarca(termo);
            }
            else if (tipo == 2)
            {
                int.TryParse(termo, out ano);
                automoveis = repositorio.GetAno(ano);
            }

            if (automoveis == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));

            foreach (Automovel auto in automoveis)
                yield return auto;
        }

        public HttpResponseMessage Put([FromBody]Automovel value)
        {
            if (!repositorio.Update(value))
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            else
                return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            if (!repositorio.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            else
                return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}