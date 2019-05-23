using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBanco.Models.Mongo
{
    public class Materia_Prima_Mongo
    {
        [BsonId]
        public string Nome { get; set; }

        [BsonElement("Custo")]
        public string Custo { get; set; }

        [BsonElement("Quantidade_Estoque")]
        public int Quantidade_Estoque { get; set; }

        public List<Produto_Mongo> Produtos_Mongo { get; set; }
    }
}