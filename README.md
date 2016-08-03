# GladNet.ASP.Client

GladNet2 is a message based networking API library for for Unity3D/.Net developers. Defines an API from which other lowerlevel network libraries can be adapted to.

Come chat: [![https://gitter.im/HelloKitty/GladNet2.0y](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/HelloKitty/GladNet2.0?utm_source=share-link&utm_medium=link&utm_campaign=share-link)

GladNet.ASP.Client is GladNet2 client API implemented for ASP-backed servers over HTTP.

## Implementations

Lidgren's: https://github.com/HelloKitty/GladNet2-Lidgren

Photon Server's: https://github.com/HelloKitty/GladNet.PhotonServer

ASP.Client (Client Only): https://github.com/HelloKitty/GladNet.ASP.Client

## Setup

To use this project you'll first need a couple of things:
  - Visual Studio 2015
  - Add Nuget Feed https://www.myget.org/F/hellokitty/api/v2 in VS (Options -> NuGet -> Package Sources)

## Builds

[TBA]

# How does this Work?

GladNet.ASP.Client isn't really specifically targeting ASP web services. GladNet.ASP.Client communicates with web services/servers through HTTP by sending requests, and receiving responses, from these services/servers. 

You may wonder why ASP is explicitly included in the title of this library. This is because of how GladNet.ASP.Client handles GladNet API requests over HTTP. Simply stated, the HTTP requests can easily fit the routing scheme for ASP Web API/Controllers. The end-point URL for requests in all current GladNet.ASP.Client implementations fits the simple scheme detailed in the below section.

##### Request Scheme

```

HTTP POST to {BaseUrl}/api/{GladNet.Common.PacketPayload Name}

```

Anyone familiar to ASP will recognize that this is a simple routing scheme for Web API controllers. (Fun Fact: Sharing a payload library between client and server allows you compile-time checked routing using nameof in C# 6)

##### What does this mean for non-ASP web services/servers? 

It means only that your HTTP POST handling for these requests should fit the ASP routing scheme laid out above. So long as you respond using the [GladNet Payload API](https://github.com/HelloKitty/GladNet2/tree/master/src/GladNet.Payload) using the same [serialization](https://github.com/HelloKitty/GladNet2/tree/master/src/GladNet.Serializer) scheme this client may communicate with your webserver.

##### Why is there no corresponding server library?

As of right now the concept of utilizing web/HTTP through GladNet2 API is mainly for scalability reasons. HTTP/web is easily scalable and there is no reason to add additional overhead to web services, services that may not be C# and thus unlikely to easily implement the full GladNet2 specification, on the server's end. Servers must only accept and deserialization incoming [GladNet.Payload.PacketPayload](https://github.com/HelloKitty/GladNet2/blob/master/src/GladNet.Payload/Payload/PacketPayload.cs) in the request bodies of the POST requests.

Should a use-case for the full implementation of the GladNet2 specification for web services arise an implementation for ASP [core](https://github.com/aspnet) will be created.


##Tests

#### Linux/Mono - Unit Tests
||Debug x86|Debug x64|Release x86|Release x64|
|:--:|:--:|:--:|:--:|:--:|:--:|
|**master**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/HelloKitty/GladNet.ASP.Client.svg?branch=master)](https://travis-ci.org/HelloKitty/GladNet.ASP.Client) |
|**dev**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/HelloKitty/GladNet.ASP.Client.svg?branch=dev)](https://travis-ci.org/HelloKitty/GladNet.ASP.Client)|

#### Windows - Unit Tests

(Done locally)

##Licensing

This project is licensed under the MIT license.
