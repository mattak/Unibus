using UnityEngine;
using System;
using System.Collections;

namespace Unibus
{
    public class UnibusSustainSubscriber : UnibusSubscriberBase
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
