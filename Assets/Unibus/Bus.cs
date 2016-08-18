using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Unibus
{
    public static class Bus
    {
        public static void Subscribe<T>(OnEvent<T> eventCallback)
        {
            BusObject.Instance.Subscribe<T>(eventCallback);
        }

        public static void Subscribe<T>(object tag, OnEvent<T> eventCallback)
        {
            BusObject.Instance.Subscribe<T>(tag, eventCallback);
        }

        public static void Unsubscribe<T>(OnEvent<T> eventCallback)
        {
            BusObject.Instance.Unsubscribe<T>(BusObject.DefaultTag, eventCallback);
        }

        public static void Unsubscribe<T>(object tag, OnEvent<T> eventCallback)
        {
            BusObject.Instance.Unsubscribe<T>(tag, eventCallback);
        }

        public static void Dispatch<T>(T action)
        {
            BusObject.Instance.Dispatch(BusObject.DefaultTag, action);
        }

        public static void Dispatch<T>(object tag, T action)
        {
            BusObject.Instance.Dispatch(tag, action);
        }
    }
}