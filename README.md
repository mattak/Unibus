# Unibus

Unibus is event passing system for Unity3D.
It is inspired by EventBus.

# Usage

Implement two class, receiver and sender.

EventSender.cs

```
using Unibus;

public class EventSender : MonoBehaviour
{
    void OnClick()
    {
        // Send string Event
        Bus.Instance.Dispatch("message");
    }
}
```

EventReceiver.cs

```
using Unibus;

public class EventReceiver : MonoBehavour
{
    void OnEnable()
    {
        Bus.Instance.Subscribe(OnEvent);
    }

    void OnDisable()
    {
        Bus.Instance.Unsubscribe(OnEvent);
    }

    // This is receiver 
    void OnEvent(string message)
    {
        var text = this.GetComponent<Text>();
        text.text = message;
    }
}
```

# License

[MIT](./LICENSE.md)

