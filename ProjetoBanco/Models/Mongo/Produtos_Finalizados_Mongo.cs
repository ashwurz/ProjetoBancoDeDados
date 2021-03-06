﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBanco.Models.Mongo
{
    public class Produtos_Finalizados_Mongo
    {
        [BsonId]
        public int Sequencia_Producao { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonElement("Data_Producao")]
        public DateTime Data_Producao { get; set; }
    }
}