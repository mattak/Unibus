using UnityEngine;
using System.Collections;

namespace Unibus
{
    public static class MonoBehaviourExtension
    {
        public static void BindEnableEvent<T>(this MonoBehaviour mono, OnEvent<T> onEvent)
        {
            GetOrAddComponent<T, UnibusEnableSubscriber>(mono, UnibusEventObject.DefaultTag, onEvent);
        }

        public static void BindEnableEvent<T>(this MonoBehaviour mono, object tag, OnEvent<T> onEvent)
        {
            GetOrAddComponent<T, UnibusEnableSubscriber>(mono, tag, onEvent);
        }

        public static void BindDestroyEvent<T>(this MonoBehaviour mono, OnEvent<T> onEvent)
        {
            GetOrAddComponent<T, UnibusSustainSubscriber>(mono, UnibusEventObject.DefaultTag, onEvent);
        }

        public static void BindDestroyEvent<T>(this MonoBehaviour mono, object tag, OnEvent<T> onEvent)
        {
            GetOrAddComponent<T, UnibusSustainSubscriber>(mono, tag, onEvent);
        }

        private static void GetOrAddComponent<T, S>(MonoBehaviour mono, object tag, OnEvent<T> onEvent) where S : UnibusSubscriberBase
        {
            var component = mono.GetComponent<S>();

            if (null == component)
            {
                component = mono.gameObject.AddComponent<S>();
            }

            component.SetSubscribeCaller(tag, onEvent);
        }
    }
}
