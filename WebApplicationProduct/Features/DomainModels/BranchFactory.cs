namespace WebApplicationProduct.Features.DomainModels
{
    public class BranchFactory
    {
        public static Branch CreateBranch(string name, Company company) //Factory Method
        {
            return new Branch(name, company);
        }
    }
}
