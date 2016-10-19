using UnityEngine;
using System;
using System.Collections;

namespace UnibusEvent
{
    public class UnibusDestroySubscriber : UnibusSubscriberBase
    {
        void Awake()
        {
            if (subscribeCaller != null)
            {
                subscribeCaller(true);
            }
        }

        void Destroy()
        {
            if (subscribeCaller != null)
            {
                subscribeCaller(false);
            }
        }
    }
}
