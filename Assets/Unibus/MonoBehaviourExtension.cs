using UnityEngine;
using System.Collections;

namespace Unibus
{
    public static class MonoBehaviourExtension
    {
        public static void BindEnableEvent<T>(this MonoBehaviour mono, OnEvent<T> onEvent)
        {
            GetOrAddComponent<T, UnibusEnableSubscriber>(mono, onEvent);
        }

        public static void BindDestroyEvent<T>(this MonoBehaviour mono, OnEvent<T> onEvent)
        {
            GetOrAddComponent<T, UnibusSustainSubscriber>(mono, onEvent);
        }

        private static void GetOrAddComponent<T, S>(MonoBehaviour mono, OnEvent<T> onEvent) where S : UnibusSubscriberBase
        {
            var component = mono.GetComponent<S>();

            if (null == component)
            {
                component = mono.gameObject.AddComponent<S>();
            }

            component.SetSubscribeCaller(onEvent);
        }
    }
}
