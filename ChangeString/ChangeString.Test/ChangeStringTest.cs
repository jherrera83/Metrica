using NUnit.Framework;

namespace ChangeString.Test
{
    [TestFixture]
    public class ChangeStringTest
    {
        [Test]
        public void build_abcd_retornabcde()
        {
            var changeString = new ChangeString();
            var resultado = changeString.build("123 abcd*3");
            Assert.That(resultado == "123 bcde*3");
        }

        [Test]
        public void build_Casa_retornaDbtb()
        {
            var changeString = new ChangeString();
            var resultado = changeString.build("Casa 52");
            Assert.That(resultado == "Dbtb 52");
        }
    }
}