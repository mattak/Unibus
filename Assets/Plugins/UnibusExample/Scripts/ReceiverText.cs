using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnibusEvent;

namespace UnibusEvent.Example
{
    public class ReceiverText : MonoBehaviour
    {
        public string Tag = "Count";
        private Text Text;

        void OnEnable()
        {
            this.Text = this.GetComponent<Text>();
            this.BindUntilDisable(Tag, (int count) =>
                {
                    this.Text.text = count.ToString();
                });
        }
    }
}