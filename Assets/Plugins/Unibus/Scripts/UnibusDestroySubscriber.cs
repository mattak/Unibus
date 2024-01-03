using UnityEngine;
using System;
using System.Collections;

namespace UnibusEvent
{
    public class UnibusDestroySubscriber : UnibusSubscriberBase
    {
        private void Awake()
        {
            if (subscribeCaller != null)
            {
                subscribeCaller(true);
            }
        }

        private void OnDestroy()
        {
            if (subscribeCaller != null)
            {
                subscribeCaller(false);
            }
        }
    }
}
