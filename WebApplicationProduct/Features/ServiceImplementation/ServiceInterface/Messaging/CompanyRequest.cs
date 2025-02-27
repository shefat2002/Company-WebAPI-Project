namespace WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.Messaging
{
    public class CompanyRequest
    {
        public CompanyRequest()
        {
            Branches = new();
        }
        public string Name { get; set; }
        public List<string>Branches {  get; set; }
        
    }
}
