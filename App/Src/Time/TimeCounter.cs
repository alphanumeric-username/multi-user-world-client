using System;
using Microsoft.Xna.Framework;

namespace Client.App.Time
{
    public class TimeCounter
    {
        private bool _initialized = false;
        public double ElapsedTime { get; private set; } = 0;
        public double Dt { get; private set; } = 0;
        public double LastTickInstant { get; private set; } = 0;
        public void Reset() {
            ElapsedTime = 0;
            Dt = 0;
            LastTickInstant = 0;
            _initialized = false;
        }

        public void Tick(GameTime gameTime) {
            double newTickInstant = gameTime.TotalGameTime.TotalSeconds;
            if (_initialized) {
                Dt = newTickInstant - LastTickInstant;
                ElapsedTime += Dt;
            } else {
                _initialized = true;
            }
            LastTickInstant = newTickInstant;
        }
    }
}