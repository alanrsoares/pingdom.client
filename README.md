## Pingdom.Client

> C# Strongly Typed Client for Pingdom.com APIs 2.0

### Avaliable resources:
- Actions
- Analysis
- Checks
- Contacts
- Probes
- TraceRoute

## Installation
> NuGet package page - http://www.nuget.org/packages/Pingdom.Client/

```
PM> Install-Package Pingdom.Client
```

## Getting Started

> __Setup credentials and base url__

**Add the following block to your .config file**:

```xml
<appSettings>
	<add key="pingdom:BaseUrl" value="https://api.pingdom.com/api/2.0/" />
	<add key="pingdom:AppKey" value="{enter your appKey}" />
	<add key="pingdom:UserName" value="{enter your userName}" />
	<add key="pingdom:Password" value="{enter your password}" />
</appSettings>
```

> __Examples__

__fetch all checks__

```C#	
var allChecksResponse = await Pingdom.Client.Checks.GetChecksList();
var allChecks = allChecksResponse.Checks;
```

__fetch single detailed check__

```C#
var detailedCheckResponse = await Pingdom.Client.Checks.GetDetailedCheckInformation(797046);
var detailedCheck = detailedCheckResponse.Check;
```
