namespace LiveEFCoreTeste.Entities
{
    public class ContactInformation
    {
        protected ContactInformation() { }
        public ContactInformation(string fullAddress, string phoneNumber)
        {
            FullAddress = fullAddress;
            PhoneNumber = phoneNumber;
        }
        
        public int Id { get; private set; }
        public string FullAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public int SchoolId { get; set; }
    }
}
