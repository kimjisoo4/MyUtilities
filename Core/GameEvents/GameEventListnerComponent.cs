﻿using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

namespace StudioScor.Utilities
{
    public class GameEventListnerComponent : BaseMonoBehaviour
    {
        [Header(" [ GameEvent Listner Component ] ")]
        [SerializeField] private GameEvent _GameEvent;
        [SerializeField] private UnityEvent _Event;

        private GameEventListner _GameEventListner;

        private void Awake()
        {
            _GameEventListner = new GameEventListner(_GameEvent);

            _GameEventListner.OnEvent += GameEventListner_OnEvent;
        }

        private void GameEventListner_OnEvent()
        {
            Log("Invoke");

            _Event.Invoke();
        }

        private void OnEnable()
        {
            _GameEventListner.OnListner();
        }
        private void OnDisable()
        {
            _GameEventListner.Endlistner();
        }
    }

}
