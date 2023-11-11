namespace RéservationApp.Dto
{
    public class AeroportDto
    {
        public int id { get; set; }
        public string AeroportCodeIATA { get; set; }
        public string AeroportCodeOACI { get; set; }
        public string AeroportNom { get; set; }
        public string AeroportContact { get; set; }
        public string AeroportLocalisation { get; set; }
        public int CompagnieID { get; set; }
    }
}
