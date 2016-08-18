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
                    BusObject.Instance.Subscribe(tag, onEvent);
                }
                else
                {
                    if (BusObject.IsExistInstance())
                    {
                        BusObject.Instance.Unsubscribe(tag, onEvent);
                    }
                }
            };

            subscribeCaller(true);
        }
    }
}