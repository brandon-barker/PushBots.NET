# PushBots.NET

[![Join the chat at https://gitter.im/brandon-barker/PushBots.NET](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/brandon-barker/PushBots.NET?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
**Unofficial** .NET Client Library for the [PushBots v1 API](https://pushbots.com/developer/api/1)

Table of Contents
-----------------
* [Quick Start](#quick-start)
* [Push](#push)
  * [Single Push](#single-push)
  * [Batch Push](#batch-push)
  * [Badge](#badge)
  * [Analytics](#analytics)
* [Devices](#devices)
  * [Get Devices](#get-devices)
  * [Get Device by Alias](#get-device-by-alias)
  * [Register Device](#register-device)
  * [Register Multiple Devices](#register-multiple-devices)
  * [Unregister Device](#unregister-device)
  * [Alias](#alias)
  * [Tag Device](#tag-device)
  * [Untag Device](#untag-device)
  * [Device Location](#device-location)

Quick Start
-----------

Install the [NuGet package](https://www.nuget.org/packages/PushBots.NET/) from the package manager console:

```powershell
Install-Package PushBots.NET
```

Create an instance of **PushBotsClient** by passing in your ***Application ID*** and ***Secret*** (get this from your App settings page on the PushBots dashboard)

```c#
var client = new PushBotsClient("55165801f85f8b457d", "b03052506824b4f3165ecc0");
```

**[back to top](#pushbotsnet)**

Push
----
#### Single Push

[Push a notification to a single device](https://pushbots.com/developer/api/1#PushOne)

```c#
var pushMessageSingle = new SinglePush()
            {
                Message = "Test from API",
                Token =
                    "APA91bGE09bhztuOZyFxI2txOOAXrELuVQ38WWC-yrX6MpgNgjylVdXLygkbGbIU9x6aToJl3C5nVGJtdteAyGVbY19TSBWYnYip0-Arjv3-6KRDq9sDobbpc17yxb3OpFO_nxxxxxxxxxxx",
                Platform = Platform.Android,
                Badge = "+1",
                Sound = "",
                Payload = JObject.Parse(@"{ 'openURL': 'http://www.google.com/' }")
            };

            await client.Push(pushMessageSingle);
```

**[back to top](#pushbotsnet)**

#### Batch Push

[Push a notification to Devices under certain conditions](https://pushbots.com/developer/api/1#batch_push)

```c#
var pushMessage = new BatchPush()
            {
                Message = "Test from API",
                Badge = "+1",
                Platforms = new[] { Platform.Android, Platform.iOS }
            };

            var result = await client.Push(pushMessage);
```

**[back to top](#pushbotsnet)**

#### Badge

[Update device Badge](https://pushbots.com/developer/api/1#badge)

```c#
var result =
    await
        client.Badge(
            "APA91x9bhzxxZC88kxxAXrELuVQ38WWC-yrX6MpgNgjylVdXLygkbGbIU9x6aToJl3C5nVGJtdteAyGVbY19TSBWYnYip0-Arjv3-6xxxxxx",
            "0", 1);

return result;
```

**NOTE: Currently only supports iOS platform, if you pass through a "1" for Android it will return an error**

**[back to top](#pushbotsnet)**

#### Analytics

[Get Push Analytics for a single application](https://pushbots.com/developer/api/1#getAnalytics)

```c#
var result = await client.GetPushAnalytics();

return result;
```

**[back to top](#pushbotsnet)**

Devices
-------

#### Get Devices

Utility function to retrieve all devices registered with PushBots along with their device token

```c#
var devices = client.GetDevices();
```

**[back to top](#pushbotsnet)**

#### Get Device by Alias

Get device information by it's registered Alias

```c#
var device = await client.GetDeviceByAlias("TestUser");
```

**[back to top](#pushbotsnet)**

#### Register Device

[Register device token of the app in the database for the first time and update it with every launch of the app, device data will be updated if registered already](https://pushbots.com/developer/api/1#register)

```c#
var device = new Device
    {
        Token = "xxxxxxxxxxx",
        Platform = Platform.Android,
        Latitude = "33.7489", // Optional
        Longitude = "-84.3789", // Optional
        Types = new[] {"Subscriptions", "Followers"}, // Optional
        Tags = new[] {"Culture", "Egypt"}, // Optional
        Alias = "test@example.com"
    };

    var response = await client.RegisterDevice(device);
```

**[back to top](#pushbotsnet)**

#### Register Multiple Devices

[Register multiple devices up to 500 Device per request](https://pushbots.com/developer/api/1#batchtoken)

```c#
var response = await client.RegisterDevice(
    new [] {"xxxxx"}, // Array of Tokens
    Platform.Android,
    new[] { "Culture", "USA" } // Optional array of Tags
    );
```

**[back to top](#pushbotsnet)**

#### Unregister Device

[unRegister device token of the app from the database](https://pushbots.com/developer/api/1#unregister)

**[back to top](#pushbotsnet)**

#### Alias
[Add/update alias of a device](https://pushbots.com/developer/api/1#alias)

**[back to top](#pushbotsnet)**

#### Tag Device

[Tag a device with its token through SDK or Alias through your backend](https://pushbots.com/developer/api/1#tag)

**[back to top](#pushbotsnet)**

#### Untag Device

[unTag a device its token through SDK or Alias through your backend](https://pushbots.com/developer/api/1#deltag)

**[back to top](#pushbotsnet)**

#### Device Location

[Add/update location of a device](https://pushbots.com/developer/api/1#geo)

**[back to top](#pushbotsnet)**
