using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBanco.Models.Mongo
{
    public class Produto_Mongo
    {
        [BsonId]
        public string Nome { get; set; }

        [BsonElement("Tempo_Producao")]
        public int Tempo_Producao { get; set; }

        [BsonElement("Nome_Materia_Principal")]
        public List<Materia_Prima> Nome_Materia_Principal { get; set; }

        [BsonElement("Lucro_Producao")]
        public string Lucro_Producao { get; set; }

        [BsonElement("Quantidade_Estoque")]
        public int Quantidade_Estoque { get; set; }
    }
}