using Aimp4.Api;
using System;
using System.Diagnostics;

namespace AimpLyrics
{
    public class AimpTask : IAIMPTask
    {
        private readonly Action _action;

        public AimpTask(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public void Execute(IAIMPTaskOwner owner)
        {
            if (owner.IsCanceled())
            {
                Debug.WriteLine("AimpTask was canceled");
                return;
            }

            _action?.Invoke();
        }
    }
}
