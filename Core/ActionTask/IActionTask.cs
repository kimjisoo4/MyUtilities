﻿using System;
using UnityEngine;

namespace StudioScor.Utilities
{
    public interface IActionTask
    {
        public bool IsPlaying { get; }
        public GameObject Owner { get; }

        public void Setup(GameObject owner);
        public IActionTask Clone();

        public void OnTask();
        public void EndTask();
    }
    public interface ISubActionTask : IActionTask
    {
        public bool IsFixedUpdate { get; }
        public void UpdateSubTask(float normalizedTime);
    }
    public interface IMainActionTask : IActionTask
    {
        public bool IsFixedUpdate { get; }
        public float NormalizedTime { get; }
        public void UpdateMainTask(float deltaTime);
        public void UpdateFixedTask(float deltaTime);
    }

    [Serializable]
    public abstract class ActionTask : IActionTask
    {
        private GameObject _owner;
        private bool _isPlaying = false;

        public GameObject Owner => _owner;
        public bool IsPlaying => _isPlaying;

        public void Setup(GameObject owner)
        {
            _owner = owner;

            SetupTask();
        }

        public abstract IActionTask Clone();

        public void OnTask()
        {
            if (IsPlaying)
                return;

            _isPlaying = true;

            EnterTask();
        }
        public void EndTask()
        {
            if (!IsPlaying)
                return;

            _isPlaying = false;

            ExitTask();
        }

        protected virtual void SetupTask()
        {

        }
        protected virtual void EnterTask()
        {

        }
        protected virtual void ExitTask()
        {

        }
    }

}
