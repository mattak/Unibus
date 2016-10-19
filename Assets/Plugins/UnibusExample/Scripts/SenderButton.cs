using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnibusEvent;

namespace UnibusEvent.Example
{
    public class SenderButton : MonoBehaviour
    {
        public string Tag = "Count";

        void Start()
        {
            var count = 0;
            var button = this.GetComponent<Button>();

            button.onClick.AddListener(() => Unibus.Dispatch(Tag, ++count));

            // Initial rendering
            Unibus.Dispatch(Tag, count);
        }
    }
}