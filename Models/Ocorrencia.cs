using System;
using System.ComponentModel.DataAnnotations;

namespace ApiOcorrenciaApi.Models
{
    public class Ocorrencia
    {
        [Key]
        public int idOcorrencia { get; set; }

        public DateTime dataOcorrencia { get; set; }

        [Required]
        public string tipoOcorrencia { get; set; }

        [Required]
        public string descricaoOcorrencia { get; set; }

        [Required]
        public string situacao { get; set; }

        public Ocorrencia()
        {
            tipoOcorrencia = "";
            descricaoOcorrencia = "";
            situacao = "";
        }
    }
}     
