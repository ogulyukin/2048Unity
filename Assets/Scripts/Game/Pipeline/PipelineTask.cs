using System;

namespace Game.Pipeline
{
    public abstract class PipelineTask
    {
        private Action _callback;

        public void Run(Action callback)
        {
            _callback = callback;
            OnRun();
        }

        protected abstract void OnRun();

        protected virtual void OnFinish()
        {
        }

        protected void Finish()
        {
            if (_callback is not null)
            {
                var cashedCallback = _callback;
                _callback = null;
                cashedCallback.Invoke();
            }
            OnFinish();
        }
    }
}
