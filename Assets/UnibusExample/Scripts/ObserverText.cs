using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unibus;

public class ObserverText : MonoBehaviour
{
    private Text text;

    void OnEnable()
    {
        this.text = this.GetComponent<Text>();
        this.BindEnableEvent((int count) => { this.text.text = count.ToString(); });
    }
}
