# Unibus

![Unibus](./art/unibus.png)

Unibus is event passing system for Unity3D.

It is inspired by EventBus.

# Why Unibus?

Unity is great framework for creating game, but there is no standard event passing system.

For example in GameJam, there is no time to implement and need to write so many singleton.

So I create instant event passing system.

It's easy to use, thin dependency, flexible to fit any type of message.

# Architecture

![Unibus](./art/unibus_message_passing.png)

Unibus is singleton GameObject.

It manages receivers and delivers messages. 

The message is classified by tag and type.

For example, if you dispatch with `HP` tag and `int` type, then receivers subscribing `HP` tag and `int` type can only receives the dispatched value.

# Install

Download [Unibus-v1.0.0.unitypackage](https://github.com/mattak/Unibus/releases/download/1.0.0/Unibus-v1.0.0.unitypackage)

# Usage

## 1. Place Unibus object

Place `Unibus` prefab object into your scene.
It will be singleton to handle event.

![Place Unibus prefab](./art/place_unibus_prefab.png)

Then it's ready to use.

## 2. Implement event sender

Send any event what you want such as `SampleEventSender.cs` .

```csharp
using Unibus;

public class SampleEventSender : MonoBehaviour
{
    void OnClick()
    {
        // Send string message
        UnibusEvent.Dispatch("message");
    }
}
```

## 3. Implement event receiver

Receive sent message such as `SampleEventReceiver.cs` .

```csharp
using Unibus;

public class SampleEventReceiver : MonoBehavour
{
    void OnEnable()
    {
        UnibusEvent.Subscribe<string>(OnEvent);
    }

    void OnDisable()
    {
        UnibusEvent.Unsubscribe<string>(OnEvent);
    }

    // This is receiver
    void OnEvent(string message)
    {
        var text = this.GetComponent<Text>();
        text.text = message;
    }
}
```

Or you can use simple style subscriber.
`BindUntilDisable()` is shortcut to unsubscribe automatically when gameobject reach `onDisable()`.

```csharp
using Unibus;

public class SampleEventReceiver : MonoBehavour
{
    void OnEnable()
    {
        UnibusEvent.BindUntilDisable((string message) => { this.GetComponent<Text>().text = message; });
    }
}
```

## Sending Object

It's able to send any type of object.

```csharp
// Subscribe
UnibusEvent.BindUntilDisable((int value) => {});
UnibusEvent.BindUntilDisable((string value) => {});
UnibusEvent.BindUntilDisable((Person value) => {});

// Dispatch
UnibusEvent.Dispatch(0);
UnibusEvent.Dispatch("message");
UnibusEvent.Dispatch(new Person("john", "due"));
```

## Tagging

Divide same type of object event by attaching tag.

```csharp
// Subscribe
UnibusEvent.BindUntilDisable("HP", (int value) => {});
UnibusEvent.BindUntilDisable("MP", (int value) => {});

// Dispatch
UnibusEvent.Dispatch("HP", 100);
UnibusEvent.Dispatch("MP", 200);
```

# License

[MIT](./LICENSE.md)
