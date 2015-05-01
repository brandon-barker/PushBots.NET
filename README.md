# PushBots.NET
**Unofficial** .NET Client Library for the [PushBots v1 API](https://pushbots.com/developer/api/1)

*This library is still in early development and is not yet ready for production use!*

### Quick Start

Install the [NuGet package](https://www.nuget.org/packages/PushBots.NET/) from the package manager console:

```powershell
Install-Package PushBots.NET
```

Add a configSection to your Web.config or App.config file

```xml
<configSections>
    <section name="PushBotsServiceSettings" type="PushBots.NET.PushBotsServiceConfiguration, PushBots.NET" />
</configSections>  
```

Create an instance of **PushBotClient** by passing in your ***Application ID*** and ***Secret*** (get this from your App settings page on the PushBots dashboard)

```c#
var client = new PushBotsClient("55165801f85f8b457d", "b03052506824b4f3165ecc0");
```

### Push
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

#### Analytics

[Get Push Analytics for a single application](https://pushbots.com/developer/api/1#getAnalytics)

```c#
var result = await client.GetPushAnalytics();

return result;
```