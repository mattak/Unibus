using UnityEngine;
using System;
using System.Collections;

namespace Unibus
{
    public class UnibusEnableScriber : MonoBehaviour
    {
        private Action<bool> subscribeCaller;

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

        void OnEnable()
        {
            if (subscribeCaller != null)
            {
                subscribeCaller(true);
            }
        }

        void OnDisable()
        {
            if (subscribeCaller != null)
            {
                subscribeCaller(false);
            }
        }
    }
}