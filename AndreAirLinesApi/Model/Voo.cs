using System;

namespace AndreAirLinesApi.Model
{
    public class Voo
    {
        #region Propriedades
        public int Id { get; set; }


        public virtual Aeroporto Destino { get; set; }

        public virtual Aeroporto Origem { get; set; }

        public virtual Aeronave Aeronave { get; set; }
        public DateTime HorarioEmbarque { get; set; }

        public DateTime HorarioDesembarque { get; set; }


        
        #endregion 

    }
}
