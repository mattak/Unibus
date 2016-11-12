using UnityEngine;
using UnityEngine.UI;

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
