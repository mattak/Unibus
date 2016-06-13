using UnityEngine;
using System.Collections;

namespace Unibus
{
    public static class MonoBehaviourExtension
    {
        public static void BindEnableTo<T>(this MonoBehaviour mono, OnEvent<T> onEvent)
        {
            var component = mono.GetComponent<UnibusEnableScriber>();

            if (null == component)
            {
                component = mono.gameObject.AddComponent<UnibusEnableScriber>();
            }

            component.SetSubscribeCaller(onEvent);
        }
    }
}