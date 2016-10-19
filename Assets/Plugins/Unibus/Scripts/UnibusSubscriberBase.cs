using UnityEngine;
using System;

namespace UnibusEvent
{
    public class UnibusSubscriberBase : MonoBehaviour
    {
        protected Action<bool> subscribeCaller;

        public void SetSubscribeCaller<T>(object tag, OnEvent<T> onEvent)
        {

            subscribeCaller = (bool active) =>
            {
                if (active)
                {
                    UnibusObject.Instance.Subscribe(tag, onEvent);
                }
                else
                {
                    if (UnibusObject.IsExistInstance())
                    {
                        UnibusObject.Instance.Unsubscribe(tag, onEvent);
                    }
                }
            };

            subscribeCaller(true);
        }
    }
}