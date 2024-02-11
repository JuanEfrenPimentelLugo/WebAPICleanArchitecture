using Bogus;
using Enterprice.Solution.Domain.Entities;
using Enterprice.Solution.Domain.Enums;

namespace Enterprice.Solution.Persistence.Mocks
{
    public class DiscountGetAllWithPaginationAsyncBogusConfig : Faker<Discount>
    {
        public DiscountGetAllWithPaginationAsyncBogusConfig()
        {
            RuleFor(p => p.Id, f => f.IndexFaker + 1);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
            RuleFor(p => p.Percent, f => f.Random.Int(70, 90));
            RuleFor(p => p.Status, f => f.PickRandom<DiscountStatus>());
        }
    }
}
