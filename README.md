# GladNet.ASP.Server

GladNet2 is a message based networking API library for for Unity3D/.Net developers. Defines an API from which other lowerlevel network libraries can be adapted to.

Come chat: [![https://gitter.im/HelloKitty/GladNet2.0y](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/HelloKitty/GladNet2.0?utm_source=share-link&utm_medium=link&utm_campaign=share-link)

GladNet2 server library for ASP core servers.

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

GladNet.ASP.Server specifically targets ASP web services. GladNet.ASP.Server is a library that contains formatters and controllers for communication with GladNet web clients overHTTP by sending requests, and receiving responses, from these services/servers. 

The end-point URL for requests in all current GladNet.ASP.Server and client implementations fits the simple scheme detailed in the below section.

##### Request Scheme

```

HTTP POST to {BaseUrl}/api/{GladNet.Common.PacketPayload Name}

```

Anyone familiar to ASP will recognize that this is a simple routing scheme for Web API controllers. (Fun Fact: Sharing a payload library between client and server allows you compile-time checked routing using nameof in C# 6)

##### What does this mean for non-ASP web services/servers? 

It means only that your HTTP POST handling for these requests should fit the ASP routing scheme laid out above. So long as you respond using the [GladNet Payload API](https://github.com/HelloKitty/GladNet2/tree/master/src/GladNet.Payload) using the same [serialization](https://github.com/HelloKitty/GladNet2/tree/master/src/GladNet.Serializer) scheme this client may communicate with your webserver.

##Tests

#### Linux/Mono - Unit Tests
||Debug x86|Debug x64|Release x86|Release x64|
|:--:|:--:|:--:|:--:|:--:|:--:|
|**master**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/HelloKitty/GladNet.ASP.Server.svg?branch=master)](https://travis-ci.org/HelloKitty/GladNet.ASP.Server) |
|**dev**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/HelloKitty/GladNet.ASP.Server.svg?branch=dev)](https://travis-ci.org/HelloKitty/GladNet.ASP.Server)|

#### Windows - Unit Tests

(Done locally)

##Licensing

This project is licensed under the MIT license.
