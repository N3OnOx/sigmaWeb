using System;

namespace SigmaWeb.Models
{
    public class Inventario
    {
        public byte? Digitalizado { get; set; }
        public string IDCM { get; set; }
        public string num_obra { get; set; }
        public string cod_CM_Cliente { get; set; }
        public string CalleCM { get; set; }
        public long? NumCM { get; set; }
        public string Situacion { get; set; }
        public string IDTipoGobierno { get; set; }
        public string IDTipoCaja { get; set; }
        public double? PotenciaCM { get; set; }
        public byte? EntSal16 { get; set; }
        public DateTime? FechaAltaCM { get; set; }
        public DateTime? FechaBajaCM { get; set; }

        
    }
}