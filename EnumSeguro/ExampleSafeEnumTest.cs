using System.Linq;
using Xunit;

namespace EnumSeguro
{
    public class ExampleSafeEnumTest
    {
        [Fact]
        public void GetAllTest()
        {
            Assert.Equal(2, ExampleSafeEnum.GetAll().Count());
            Assert.IsType<ExampleSafeEnum>(ExampleSafeEnum.GetAll().First());
        }

        [Fact]
        public void GetByIdTest()
            => Assert.Equal(1, ExampleSafeEnum.GetById(1).Id);

        [Fact]
        public void OperatorTest()
        {
            Assert.True(ExampleSafeEnum.GetById(1) == ExampleSafeEnum.GetById(1));
            Assert.True(ExampleSafeEnum.GetById(1) != ExampleSafeEnum.GetById(2));
            Assert.True(ExampleSafeEnum.GetById(1).Equals(ExampleSafeEnum.GetById(1)));
            Assert.False(ExampleSafeEnum.GetById(1).Equals(ExampleSafeEnum.GetById(2)));
        }
    }
}