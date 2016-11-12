# Unibus

![Unibus](./art/unibus.png)

Unibus is event passing system for Unity3D.

It is inspired by EventBus.

# Why Unibus?

Unity is great framework for creating game, but there is no standard event passing system.

For example in GameJam, there is no time to solve GameObject dependencies and create so many callback.

So I create instant event passing system.

It's easy to use, thin dependency, flexible to fit any type of message.

# Architecture

![Unibus](./art/unibus_message_passing.png)

Unibus is singleton GameObject.

It manages receivers and delivers to handle message. 

The message is classified by tag and type.

For example, if you dispatch message with `HP` tag and `int` type, then receivers subscribing `HP` tag and `int` type can only receives the dispatched value.

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
using UnibusEvent;

public class SampleEventSender : MonoBehaviour
{
    void OnClick()
    {
        // Send string message
        Unibus.Dispatch("message");
    }
}
```

## 3. Implement event receiver

Receive sent message such as `SampleEventReceiver.cs` .

```csharp
using UnibusEvent;

public class SampleEventReceiver : MonoBehavour
{
    void OnEnable()
    {
        Unibus.Subscribe<string>(OnEvent);
    }

    void OnDisable()
    {
        Unibus.Unsubscribe<string>(OnEvent);
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
using UnibusEvent;

public class SampleEventReceiver : MonoBehavour
{
    void OnEnable()
    {
        this.BindUntilDisable((string message) => { this.GetComponent<Text>().text = message; });
    }
}
```

## Sending Object

It's able to send any type of object.

```csharp
// Subscribe
this.BindUntilDisable((int value) => {});
this.BindUntilDisable((string value) => {});
this.BindUntilDisable((Person value) => {});

// Dispatch
Unibus.Dispatch(0);
Unibus.Dispatch("message");
Unibus.Dispatch(new Person("john", "due"));
```

## Tagging

Divide same type of object event by attaching tag.

```csharp
// Subscribe
this.BindUntilDisable("HP", (int value) => {});
this.BindUntilDisable("MP", (int value) => {});

// Dispatch
Unibus.Dispatch("HP", 100);
Unibus.Dispatch("MP", 200);
```

# License

[MIT](./LICENSE.md)
