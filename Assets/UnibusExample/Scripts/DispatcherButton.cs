using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unibus;

public class DispatcherButton : MonoBehaviour
{
    public string Tag = "Count";

    void Start()
    {
        var count = 0;
        var button = this.GetComponent<Button>();

        button.onClick.AddListener(() => {
            Bus.Instance.Dispatch(Tag, count++);
        });
    }
}
