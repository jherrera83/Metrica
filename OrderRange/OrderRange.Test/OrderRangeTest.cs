using NUnit.Framework;

namespace OrderRange.Test
{
    [TestFixture]
    public class OrderRangeTest
    {
        [Test]
        public void build_2145_retorna1524()
        {
            var orderRange = new OrderRange();
            var resultado = orderRange.build(new int[] { 2, 1, 4, 5 });
            Assert.That(resultado == "[1,5][2,4]");
        }

        [Test]
        public void build_42936_retorna24639()
        {
            var orderRange = new OrderRange();
            var resultado = orderRange.build(new int[] { 4, 2, 9, 3, 6 });
            Assert.That(resultado == "[2,4,6][3,9]");
        }

        [Test]
        public void build_586055485773_retorna485860555773()
        {
            var orderRange = new OrderRange();
            var resultado = orderRange.build(new int[] { 58, 60, 55, 48, 57, 73 });
            Assert.That(resultado == "[48,58,60][55,57,73]");
        }
    }
}
