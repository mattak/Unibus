using UnityEngine;
using System;
using System.Collections;

namespace Unibus
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
