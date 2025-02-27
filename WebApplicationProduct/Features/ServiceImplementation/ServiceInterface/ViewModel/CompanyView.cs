namespace WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewModel
{
    public class CompanyView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BranchView> Branches { get; set; }
    }
}
