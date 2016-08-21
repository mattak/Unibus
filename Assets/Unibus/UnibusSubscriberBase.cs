using UnityEngine;
using System;

namespace Unibus
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
                    UnibusEventObject.Instance.Subscribe(tag, onEvent);
                }
                else
                {
                    if (UnibusEventObject.IsExistInstance())
                    {
                        UnibusEventObject.Instance.Unsubscribe(tag, onEvent);
                    }
                }
            };

            subscribeCaller(true);
        }
    }
}