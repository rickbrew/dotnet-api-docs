﻿using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class Client1
{
    public static void Main(string[] args)
    {
        // Create the channel.
        TcpClientChannel channel = new TcpClientChannel();

        // Register the channel.
        ChannelServices.RegisterChannel(channel);

        // Register as client for remote object.
        WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(
            typeof(RemoteObject),
            "tcp://localhost:9090/RemoteObject.rem");
        RemotingConfiguration.RegisterWellKnownClientType(remoteType);

        // Create an instance of the remote object.
        RemoteObject service = new RemoteObject();

        // Invoke a method on the remote object.
        Console.WriteLine("The client is invoking the remote object.");
        Console.WriteLine("The remote object has been called {0} times.",
            service.GetCount());
    }
}
