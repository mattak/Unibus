using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unibus;

public class ObserverText : MonoBehaviour
{
    public string Tag = "Count";
    private Text Text;

    void OnEnable()
    {
        this.Text = this.GetComponent<Text>();
        this.BindEnableEvent(Tag, (int count) => { this.Text.text = count.ToString(); });
    }
}
