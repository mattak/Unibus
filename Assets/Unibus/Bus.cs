using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Unibus
{
    public delegate void OnEvent<T>(T action);
    public delegate void OnEventWrapper(object _object);

    public class Bus : SingletonMonoBehaviour<Bus>
    {
        private Dictionary<Type, Dictionary<int, OnEventWrapper>> observerDictionary = new Dictionary<Type, Dictionary<int, OnEventWrapper>>();

        public void Subscribe<T>(OnEvent<T> eventCallback)
        {
            Type type = typeof(T);

            if (!observerDictionary.ContainsKey(type))
            {
                observerDictionary[type] = new Dictionary<int, OnEventWrapper>();
            }

            observerDictionary[type][eventCallback.GetHashCode()] = (object _object) => {
                eventCallback((T)_object);
            };
        }

        public void Unsubscribe<T>(OnEvent<T> eventCallback)
        {
            Type type = typeof(T);

            if (observerDictionary[type] != null)
            {
                observerDictionary[type].Remove(eventCallback.GetHashCode());
            }
        }

        public void Dispatch<T>(T action)
        {
            Type type = typeof(T);

            if (observerDictionary.ContainsKey(type))
            {
                foreach(var caller in observerDictionary[type].Values)
                {
                    caller(action);
                }
            }
        }
    }
}