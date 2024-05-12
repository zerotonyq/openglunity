﻿using System;
using System.Collections.Generic;

namespace Core.Movement.Fsm.Base
{
    public class Fsm
    {
        protected FsmState _currentState;

        protected Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>();


        public void AddState(FsmState state) => _states.Add(state.GetType(), state);

        public void Update() => _currentState?.Update();

        public void SetState<T>() where T : FsmState
        {
            var type = typeof(T);

            if (_currentState != null && _currentState.GetType() == type)
                return;

            if (_states.TryGetValue(type, out var newState))
            {
                _currentState?.Exit();

                _currentState = newState;

                _currentState.Enter();
            }
        }

        public T GetState<T>() where T : FsmState
        {
            var type = typeof(T);
            
            if (_states.TryGetValue(type, out var state))
                return state as T;
            
            throw new NullReferenceException("There is no such state to get " + type);
        }
    }
}