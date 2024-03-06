namespace LoansApp.Server.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public decimal AnnualIncome { get; set; }
        public bool IsHomeOwner { get; set; }
        public string CarRegistration { get; set; }
    }
}
