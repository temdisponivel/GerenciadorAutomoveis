using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System;

namespace Api.Models
{
    /// <summary>
    /// Implementação do repositorio de automóveis.
    /// </summary>
    public class AutomoveisRepositorio : IAutomoveisRepositorio
    {
        public AutomoveisContext _context { get; set; }

        public AutomoveisRepositorio()
        {
            _context = new AutomoveisContext();
        }

        public List<Automovel> GetTodos()
        {
            var automoveis = from auto in _context.Automoveis select auto;
            Automovel atual = null;

            var autos = automoveis.ToList();
            foreach (Automovel aut in autos)
            {
                atual = aut;
                _context.GetOpcionais(ref atual);
            }

            return automoveis.ToList();
        }

        public Automovel GetId(int id)
        {
            var automovel = _context.Automoveis.Where(auto => auto.id == id).FirstOrDefault<Automovel>();
            _context.GetOpcionais(ref automovel);
            return automovel;
        }

        public List<Automovel> GetModelo(string modelo)
        {
            var automoveis = _context.Automoveis.Where(auto => auto.modelo.Contains(modelo));
            return automoveis.ToList();
        }

        public List<Automovel> GetAno(int ano)
        {
            var automoveis = _context.Automoveis.Where(auto => auto.ano == ano);
            return automoveis.ToList();
        }

        public List<Automovel> GetMarca(string marca)
        {
            var automoveis = _context.Automoveis.Where(auto => auto.marca.nome.Contains(marca));
            return automoveis.ToList();
        }

        public bool Update(Automovel auto)
        {
            try
            {
                _context.Automoveis.Attach(auto);
                this.RemoveOpcionalRelacao(ref auto);
                this.AdicionaOpcionalRelacao(ref auto);
                _context.Entry<Automovel>(auto).State = EntityState.Modified;
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                this.Revert<Automovel>();
                this.Revert<OpcionaisRelacao>();
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Automovel aut = null;
                _context.Automoveis.Remove(aut = _context.Automoveis.Where(auto => auto.id == id).FirstOrDefault<Automovel>());

                this.RemoveOpcionalRelacao(ref aut);

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                this.Revert<Automovel>();
                this.Revert<OpcionaisRelacao>();
                return false;
            }
        }

        public List<Opcional> GetOpcionais()
        {
            var opcionais = from opc in _context.Opcionais select opc;
            return opcionais.ToList();
        }

        public List<Marca> GetMarcas()
        {
            var marcas = from marca in _context.Marcas select marca;
            return marcas.ToList();
        }

        private void AdicionaOpcionalRelacao(ref Automovel aut)
        {
            if (aut.opcionais != null)
            {
                foreach (Opcional opc in aut.opcionais)
                {
                    OpcionaisRelacao novo = new OpcionaisRelacao();
                    novo.AutomovelId = aut.id;
                    novo.OpcionalId = opc.id;
                    novo.automovel = _context.Automoveis.Where(auto => auto.id == novo.AutomovelId).FirstOrDefault();
                    novo.opcional = _context.Opcionais.Where(o => o.id == novo.OpcionalId).FirstOrDefault();
                    _context.OpcionaisRelacao.Add(novo);
                }
            }
        }

        private void RemoveOpcionalRelacao(ref Automovel aut)
        {
            int id = aut.id;
            var opcionaisAutomovel = _context.OpcionaisRelacao.Where(o => o.AutomovelId == id).ToList();

            foreach (OpcionaisRelacao opcRelac in opcionaisAutomovel)
            {
                _context.OpcionaisRelacao.Remove(opcRelac);
            }
        }

        private void Revert<T>() where T : class
        {
            foreach (var entry in _context.ChangeTracker
                             .Entries<T>()
                             .Where(e => e.State == EntityState.Modified || e.State == EntityState.Deleted))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
            }
        }
    }
}