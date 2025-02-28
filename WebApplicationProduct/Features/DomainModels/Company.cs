using System.Runtime.CompilerServices;
using WebApplicationProduct.Features.DataAccess.EntityConfigurations;

namespace WebApplicationProduct.Features.DomainModels
{
    public class Company
    {
        public Company()
        {
            Branches = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Branch> Branches { get; set; }
        public void AddBranch(string name)
        {
            Branches.Add(BranchFactory.CreateBranch(name, this)); //Factory Method Design Pattern
        }
    }
}
