using Xunit;

namespace BotTempo.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void  TratarStringTeste()
        {
        Assert.Equal("sao paulo", TratarString.getStringNoSpecialChar("são paulo"));

        }
    }
}
