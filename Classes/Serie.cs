using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.series
{
    public class Serie: EntidadeBase
    {
        //atributos
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido { get; set; }

        //Metodos

        //construtor
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
            return retorno;
        }
        
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaID()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
         
    }
}