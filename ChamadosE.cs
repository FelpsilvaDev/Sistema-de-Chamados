using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ChamadosE
    {
        public int Codigo { get; set; }

        public string Status { get; set; }
        public DateTime DataAbertura { get; set; }
        
        public string Usuario { get; set; }
        public string Responsavel { get; set; }

        public string Prioridade { get; set; }

        public string Departamento { get; set; }

        public string Categoria { get; set; }

        public string Subcategoria { get; set; }
        public string Descricao  { get; set; }

        public string Solucao { get; set; }

        public string Indevido { get; set; }

        public string ObservacoesResponsavel { get; set; }
        public string  DataFechamento { get; set; }

        public int CodigoCategoria { get; set; }

        public int CodigoSubcategoria { get; set; }

        public int CodigoDepartamento { get; set; }
        public string Autorizacao { get; set; }
        public int setor { get; set; }
    }
}
