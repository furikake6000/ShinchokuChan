using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using Twity;
using Twity.DataModels.Core;
using Twity.DataModels.StreamMessages;
using Twity.DataModels.Responses;

public class TwitterController : MonoBehaviour {

	Twity.Stream stream;

	void Start () {
		string twitterInfoJson = File.ReadAllText ("Assets/Scripts/twitter.config_secret");
		TwitterAppInfo twitterInfo = TwitterAppInfo.CreateFromJson (twitterInfoJson);
		twitterInfo.SetToTwity ();

		stream = new Twity.Stream(StreamType.User);
		Dictionary<string, string> streamParameters = new Dictionary<string, string>();
		// 特にパラメータはなし
		StartCoroutine(stream.On(streamParameters, OnStream));
	}
	
	void OnStream(string response, StreamMessageType messageType) {
		try
		{
			if(messageType == StreamMessageType.Tweet)
			{
				Tweet tweet = JsonUtility.FromJson<Tweet>(response);
				Debug.Log(tweet.text);
			}
			else if(messageType == StreamMessageType.StreamEvent)
			{
				StreamEvent streamEvent = JsonUtility.FromJson<StreamEvent>(response);
				//Debug.Log(streamEvent.event_name);
				if(streamEvent.event_name == "favorite"){
					Debug.Log("Favorited!: from " + streamEvent.source.name);
				}
			}
		}
		catch (System.Exception e)
		{
			Debug.Log(e);
		}
	}
}

public class TwitterAppInfo{
	public string consumerKey;
	public string consumerSecret;
	public string accessToken;
	public string accessTokenSecret;

	public static TwitterAppInfo CreateFromJson(string json){
		return JsonUtility.FromJson<TwitterAppInfo> (json);
	}

	public void SetToTwity(){
		Twity.Oauth.consumerKey       = this.consumerKey;
		Twity.Oauth.consumerSecret    = this.consumerSecret;
		Twity.Oauth.accessToken       = this.accessToken;
		Twity.Oauth.accessTokenSecret = this.accessTokenSecret;
	}
}