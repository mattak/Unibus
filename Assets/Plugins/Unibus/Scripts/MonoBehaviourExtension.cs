using UnityEngine;
using System.Collections;

namespace UnibusEvent
{
    public static class MonoBehaviourExtension
    {
        public static void BindUntilDisable<T>(this MonoBehaviour mono, OnEvent<T> onEvent)
        {
            GetOrAddComponent<T, UnibusDisableSubscriber>(mono, UnibusObject.DefaultTag, onEvent);
        }

        public static void BindUntilDisable<T>(this MonoBehaviour mono, object tag, OnEvent<T> onEvent)
        {
            GetOrAddComponent<T, UnibusDisableSubscriber>(mono, tag, onEvent);
        }

        public static void BindUntilDestroy<T>(this MonoBehaviour mono, OnEvent<T> onEvent)
        {
            GetOrAddComponent<T, UnibusDestroySubscriber>(mono, UnibusObject.DefaultTag, onEvent);
        }

        public static void BindUntilDestroy<T>(this MonoBehaviour mono, object tag, OnEvent<T> onEvent)
        {
            GetOrAddComponent<T, UnibusDestroySubscriber>(mono, tag, onEvent);
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
