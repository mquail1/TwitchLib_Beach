using System.Collections;
using System.Collections.Generic;
using TwitchLib.Client.Models;
using TwitchLib.Unity;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

// Script to connect to TwitchClient

public class TwitchClient : MonoBehaviour
{
	[Header("Client Reference")]
    [SerializeField] private Client client;
	// Instance variable
    private string channel_name = "bathinjan";

    void Start()
    {
		// To keep the Unity application active in the background, you can enable "Run In Background" in the player settings:
		// Unity Editor --> Edit --> Project Settings --> Player --> Resolution and Presentation --> Resolution --> Run In Background
		// Debug in case the Editor functionality doesn't work:
		// Application.runInBackground = true;

        // Initialize ConnectionCredentials
        ConnectionCredentials credentials = new ConnectionCredentials("bathybot", Secrets.bot_access_token);
        
        // Create new instance of Client
        client = new Client();

        // Initialize client with credentials instance, set to instance channel
        client.Initialize(credentials, channel_name);

		// Bind callbacks to events
		client.OnConnected += OnConnected;
		client.OnJoinedChannel += OnJoinedChannel;
		client.OnMessageReceived += OnMessageReceived;
		client.OnChatCommandReceived += OnChatCommandReceived;

        // subscribe to EVENTS we want the bot to listen for
        // ***THIS FUNCTIONALITY HAS MOVED TO PUBSUB CLASS***
        // client.OnMessageReceived += Client_OnMessageReceived;

        client.Connect();
    }

	private void OnConnected(object sender, TwitchLib.Client.Events.OnConnectedArgs e)
	{
		// Debug.Log($"The client {e.BotUsername} succesfully connected to Twitch.");

		// if (!string.IsNullOrWhiteSpace(e.AutoJoinChannel))
			// Debug.Log($"The client will now attempt to automatically join the channel provided when the Initialize method was called: {e.AutoJoinChannel}");
	}

	private void OnJoinedChannel(object sender, TwitchLib.Client.Events.OnJoinedChannelArgs e)
	{
		// Debug.Log($"The client {e.BotUsername} just joined the channel: {e.Channel}");
		client.SendMessage(e.Channel, "TwitchClient login successful!");
	}

	private void OnMessageReceived(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
	{
		// Debug.Log($"Message received from {e.ChatMessage.Username}: {e.ChatMessage.Message}");
	}

    // Bot currently has command handles with the same prefix '!' through Replit
    // recommended that this functionality is disabled in one location or another
	private void OnChatCommandReceived(object sender, TwitchLib.Client.Events.OnChatCommandReceivedArgs e)
	{
		switch (e.Command.CommandText)
		{
			//case "hello":
				//client.SendMessage(e.Command.ChatMessage.Channel, $"Hello {e.Command.ChatMessage.DisplayName}!");
				//break;
			case "listening":
				client.SendMessage(e.Command.ChatMessage.Channel, "Successfully listening through TwitchClient class bathinLancer");
				break;
			//default:
				//client.SendMessage(e.Command.ChatMessage.Channel, $"Unknown chat command: {e.Command.CommandIdentifier}{e.Command.CommandText}");
				//break;
		}
	}

	/*
    void Update()
    {
        // Debug function checking Client connection was successful
        // This will show as a message from the bot in the client channel chat if hotkey 1 is pressed
        if(Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            client.SendMessage(client.JoinedChannels[0], "Client connection via Unity successful (pressed 1)");
        }
    }
	*/
}