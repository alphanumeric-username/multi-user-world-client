using System;
using Client.App.Time;
using Microsoft.Xna.Framework;
using Xunit;

namespace Client.Tests
{
    public class TimeCounterTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Tick_20Seconds_DtEq10AndElapsedTimeEq10(int iterations)
        {
            GameTime gameTime = new GameTime();
            TimeCounter timeCounter = new TimeCounter();

            timeCounter.Tick(new GameTime());
            for(int i = 1; i <= iterations; i++) {
                timeCounter.Tick(new GameTime(TimeSpan.FromSeconds(i * 10), TimeSpan.FromSeconds(10)));
            }
            if (iterations > 0) {
                Assert.Equal(10, timeCounter.Dt);
            } else {
                Assert.Equal(0, timeCounter.Dt);
            }
            Assert.Equal(iterations*10, timeCounter.ElapsedTime);
        }
        [Fact]
        public void Reset__DtEq0AndElapsedTimeEq0()
        {
            GameTime gameTime = new GameTime();
            TimeCounter timeCounter = new TimeCounter();

            timeCounter.Tick(new GameTime());
            timeCounter.Tick(new GameTime(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10)));
            timeCounter.Tick(new GameTime(TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(10)));
            timeCounter.Reset();
            Assert.Equal(0, timeCounter.Dt);
            Assert.Equal(0, timeCounter.ElapsedTime);
        }
    }
}