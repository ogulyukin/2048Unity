using System;
using System.Collections.Generic;
using Game.Pipeline;

namespace Assets.Scripts.Game.Pipeline
{
    public class Pipeline
    {
        public event Action OnFinished;
        private readonly List<PipelineTask> _pipelineTasks = new ();
        private int _currentIndex;

        public void AddTask(PipelineTask task)
        {
            _pipelineTasks.Add(task);
        }

        public void Run()
        {
            _currentIndex = 0;
            RunNextTask();
        }

        public void Clear()
        {
            _pipelineTasks.Clear();
        }

        public int GetTasksCount()
        {
            return _pipelineTasks.Count;
        }

        private void RunNextTask()
        {
            if (_currentIndex >= _pipelineTasks.Count)
            {
                OnFinished?.Invoke();
                return;
            }
            _pipelineTasks[_currentIndex].Run(OnTaskFinished);
        }

        private void OnTaskFinished()
        {
            _currentIndex++;
            RunNextTask();
        }
    }
}
