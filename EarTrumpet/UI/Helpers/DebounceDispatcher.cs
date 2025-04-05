using System;
using System.Windows.Threading;

namespace EarTrumpet.UI.Helpers
{
    /// <summary>
    /// Provides a simple mechanism to debounce rapid actions (e.g., user input) 
    /// by delaying execution until a specified time interval has passed without new triggers.
    /// </summary>
    public class DebounceDispatcher
    {
        private DispatcherTimer _timer;

        /// <summary>
        /// Schedules the specified <paramref name="action"/> to run after the given <paramref name="milliseconds"/> delay.
        /// If called again before the delay expires, the timer resets and waits again.
        /// </summary>
        /// <param name="milliseconds">The delay interval in milliseconds.</param>
        /// <param name="action">The action to execute after the debounce interval.</param>
        public void Debounce(int milliseconds, Action action)
        {
            // Stop any previously running timer 
            _timer?.Stop();

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(milliseconds)
            };

            _timer.Tick += (s, e) =>
            {
                _timer.Stop();     
                action.Invoke();  
            };

            _timer.Start();
        }
    }
}

