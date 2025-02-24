namespace WebApplicationProduct.Features.DomainModels
{
    public class BranchFactory
    {
        public static Branch CreateBranch(string name, Company company)
        {
            return new Branch(name, company);
        }
    }
}
