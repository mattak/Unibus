using UnityEngine;
using System;

namespace Unibus
{
    public class UnibusSubscriberBase : MonoBehaviour
    {
        protected Action<bool> subscribeCaller;

        public void SetSubscribeCaller<T>(OnEvent<T> onEvent)
        {
            subscribeCaller = (bool active) =>
                {
                    if (active)
                    {
                        Unibus.Bus.Instance.Subscribe(onEvent);
                    }
                    else
                    {
                        Unibus.Bus.Instance.Unsubscribe(onEvent);
                    }
                };

            subscribeCaller(true);
        }
    }
}
