using UnityEngine;
using System;
using System.Collections;

namespace UnibusEvent
{
    public class UnibusDisableSubscriber : UnibusSubscriberBase
    {
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
