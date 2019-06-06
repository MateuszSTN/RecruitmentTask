using RecruitmentTask.Core;
using RecruitmentTask.Data;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RecruitmentTask.Tests
{
    public class ProductRepositoryTests : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture _fixture;
        public ProductRepositoryTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAll_Should_Return_All_Products()
        {
            using (var context = new AppDbContext(_fixture.options))
            {
                var productRepository = new ProductRepository(context);

                var result = (await productRepository.GetAll()).ToArray();

                Assert.NotEmpty(result);
                Assert.Equal(3, result.Count());
                Assert.Equal("name1", result[0].Name);
                Assert.Equal("name2", result[1].Name);
                Assert.Equal("name3", result[2].Name);
            }
        }

        [Fact]
        public async Task GetAll_WithToyCategory_Should_Return_All_Toys()
        {
            using (var context = new AppDbContext(_fixture.options))
            {
                var toyCategory = Category.Toy;
                var productRepository = new ProductRepository(context);

                var result = (await productRepository.GetAll(category: toyCategory)).ToArray();

                Assert.NotEmpty(result);
                Assert.Equal(2, result.Count());
                Assert.Equal(Category.Toy, result[0].Category);
                Assert.Equal(Category.Toy, result[1].Category);
            }
        }

        [Fact]
        public async Task GetAll_WithSearchName_Should_Return_All_ProductsWithName()
        {
            using (var context = new AppDbContext(_fixture.options))
            {
                var name = "name2";
                var productRepository = new ProductRepository(context);

                var result = (await productRepository.GetAll(name)).ToArray();

                Assert.NotEmpty(result);
                Assert.Equal(name, result[0].Name);
            }
        }

        [Fact]
        public async Task GetById_Should_Return_ProjectWithId()
        {
            using (var context = new AppDbContext(_fixture.options))
            {
                int id = 1;
                var productRepository = new ProductRepository(context);

                var result = await productRepository.GetById(id);

                Assert.NotNull(result);
                Assert.Equal(id, result.Id);
            }
        }

        [Fact]
        public async Task GetById_WithNotExistingId_Should_Return_Null()
        {
            using (var context = new AppDbContext(_fixture.options))
            {
                int id = 4;
                var productRepository = new ProductRepository(context);

                var result = await productRepository.GetById(id);

                Assert.Null(result);
            }
        }
    }
}
