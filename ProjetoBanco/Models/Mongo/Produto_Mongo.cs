using MongoDB.Bson;
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

        [BsonElement("Tempo_Producao_Minutos")]
        public int Tempo_Producao_Minutos { get; set; }

        [BsonElement("Nome_Materia_Principal")]
        public string Nome_Materia_Principal { get; set; }

        [BsonElement("Lucro_Producao")]
        public string Lucro_Producao { get; set; }

        [BsonElement("Quantidade_Estoque")]
        public int Quantidade_Estoque { get; set; }

        public Materia_Prima_Mongo Materia_Prima_Mongo { get; set; }
    }
}