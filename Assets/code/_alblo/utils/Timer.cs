//-----------------------------------------------------------------------
// <copyright file="Timer.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using UnityEngine.Events;

namespace Alblo.Utils
{
    public enum TimerModes
    {
        Running,
        Ready,
        Stopped,
    }

    public class Timer
    {
        private float time = 10;
        private float timeCounter = 0;

        public TimerModes Mode { private get; set; } = TimerModes.Running;
        public UnityEvent OnTimeOut { get; } = new UnityEvent();

        public static Timer Create(float time, UnityAction listener, bool actionOnFirstTick = false)
        {
            var timer = new Timer
            {
                time = time,
                timeCounter = actionOnFirstTick ? time : 0,
            };

            timer.OnTimeOut.AddListener(listener);

            return timer;
        }

        public void Tick(float time)
        {
            this.timeCounter += this.IsReady() ? time : 0;

            if (this.IsRunning())
            {
                if (this.timeCounter >= this.time)
                {
                    this.OnTimeOut.Invoke();
                    this.timeCounter = 0;
                }
            }
        }

        private bool IsRunning()
        {
            return this.Mode == TimerModes.Running;
        }

        private bool IsReady()
        {
            return this.Mode == TimerModes.Running || this.Mode == TimerModes.Ready;
        }
    }
}
