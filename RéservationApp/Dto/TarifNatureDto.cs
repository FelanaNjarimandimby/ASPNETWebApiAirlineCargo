namespace RéservationApp.Dto
{
    public class TarifNatureDto
    {
        public int IDTarifNature { get; set; }
        public double PoidsTaxable { get; set; }
        public string TypeTarif { get; set; }
        public int IDMarchandise { get; set; }
    }
}
