namespace RentalKostumAPI.Model
{
    public class Rental
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public int Costume_Id { get; set; }
        public DateTime Rent_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public string Status { get; set; }
    }
}

