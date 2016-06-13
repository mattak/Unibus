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
        Bus.Instance.Subscribe<int>(OnEvent);
    }

    void OnDisable()
    {
        Bus.Instance.Unsubscribe<int>(OnEvent);
    }

    void OnEvent(int count)
    {
        this.text.text = count.ToString();
    }
}
