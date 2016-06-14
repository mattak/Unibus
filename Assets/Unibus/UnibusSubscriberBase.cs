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
                        Unibus.Bus.Instance.Subscribe(tag, onEvent);
                    }
                    else
                    {
                        Unibus.Bus.Instance.Unsubscribe(tag, onEvent);
                    }
                };

            subscribeCaller(true);
        }
    }
}