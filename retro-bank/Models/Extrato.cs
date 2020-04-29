using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace retro_bank.Models
{
    public class Extrato
    {
        private static DBContext1 _db = new DBContext1();
        public int Id { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public TipoOperacao Tipo { get; set; }
        public DateTime Data { get; set; }
        public int ClienteId { get; set; }

        internal static List<Extrato> Lista()
        {
            return _db.Extratos.ToList();
        }

        internal static List<Extrato> Lista(int ClienteId)
        {
            return _db.Extratos.Where(e => e.ClienteId == ClienteId).ToList();
        }

        internal bool Salvar()
        {
            try
            {
                _db.Extratos.Add(this);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    
        internal static double SaldoPorClienteId(int ClienteId)
        {
            try
            {
                double credito = Extrato.Lista(ClienteId).Where(c => c.Tipo == TipoOperacao.Credito).Sum(c => c.Valor);
                double debito = Extrato.Lista(ClienteId).Where(c => c.Tipo == TipoOperacao.Debito).Sum(c => c.Valor);

                return credito - debito;
            }
            catch
            {
                return 0;
            }
        }

        internal static void EfetuarTransferencia(Transferencia transferencia)
        {
            new Extrato()
            {
                ClienteId = transferencia.ClienteRemetenteId,
                Valor = transferencia.Valor,
                Descricao = $"Transferência para o usuario {transferencia.ClienteDestinatario().Nome} no valor, ID transferencia {transferencia.Id}",
                Tipo = TipoOperacao.Debito,
                Data = DateTime.Now
            }.Salvar();

            new Extrato()
            {
                ClienteId = transferencia.ClienteDestinatarioId,
                Valor = transferencia.Valor,
                Descricao = $"Crédito recebido do usuário {transferencia.ClienteRemetente().Nome} no valor, ID transferencia {transferencia.Id}",
                Tipo = TipoOperacao.Credito,
                Data = DateTime.Now
            }.Salvar();
        }
    }
    public enum TipoOperacao
    {
        Credito, Debito
    }
}