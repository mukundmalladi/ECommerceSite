namespace EcommerceMvc.Helper
{
    public class User
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string FullName
        {
            get { return FirstName + LastName; }
        }

        public string EmailId { get; set; }
    }
}