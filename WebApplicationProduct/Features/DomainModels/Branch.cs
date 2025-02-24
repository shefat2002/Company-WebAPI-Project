namespace WebApplicationProduct.Features.DomainModels
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public Branch(string name, Company company)
        {
            Name = name;
            Company = company;
        }
    }
}
