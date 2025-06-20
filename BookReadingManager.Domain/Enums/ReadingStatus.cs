using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookReadingManager.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReadingStatus
    {
        Desejado,
        QueroLer,
        Lendo,
        Lido
    }
}