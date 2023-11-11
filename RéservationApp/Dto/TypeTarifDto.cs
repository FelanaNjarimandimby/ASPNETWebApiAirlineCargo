namespace RéservationApp.Dto
{
    public class TypeTarifDto
    {
        public int id { get; set; }
        public string TarifLibelle { get; set; }
        public double TarifValeur { get; set; }
        public double TarifFraisAssurance { get; set; }
        public double TarifAnnexe { get; set; }
    }
}
