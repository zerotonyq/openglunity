using System;
using System.Collections.Generic;
using Core.Pooling.Base;
using UnityEngine;
using Zenject;

namespace Core.Pooling
{
    public class PoolManager
    {
        public static PoolManager Instance;

        [Inject]
        public PoolManager()
        {
            Instance = this;
        }

        private Dictionary<Type, Queue<Poolable>> Pool = new();

        public T Get<T>() where T : Poolable
        {
            if (!Pool.ContainsKey(typeof(T))) 
                Pool.Add(typeof(T), new Queue<Poolable>());
            
            if (!Pool[typeof(T)].TryDequeue(out Poolable obj))
                return null;
            
            return obj as T;
        }

        public void Put<T>(T obj) where T : Poolable
        {
            if (!Pool.ContainsKey(typeof(T))) 
                Pool.Add(typeof(T), new Queue<Poolable>());
            
            Pool[typeof(T)].Enqueue(obj);
        }
    }
}