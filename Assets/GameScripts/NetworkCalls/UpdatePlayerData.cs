using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
class UpdatePost{
	public string playerID;
	public string playerName;
	public int playerScore;
	public UpdatePost(string id,string name,int score){
		playerID = id;
		playerName = name;
		playerScore = score;
	}
}

public class UpdatePlayerData : MonoBehaviour
{
	public void SetPlayerName(string newName){
    PlayerPrefs.SetString(PrefKeys.playerName,newName);
		NetworkUpdate();
	}

	public void SetPlayerHighScore(int newBestScore){
    PlayerPrefs.SetInt(PrefKeys.bestScore,newBestScore);
		NetworkUpdate();
	}


  public void NetworkUpdate()
  {
    StartCoroutine(RestNetworkUpdate());
  }

  IEnumerator RestNetworkUpdate()
  {
    string playerId = PlayerPrefs.GetString(PrefKeys.playerID);
    int bestScore = PlayerPrefs.GetInt(PrefKeys.bestScore);
    string playerName = PlayerPrefs.GetString(PrefKeys.playerName);
		UpdatePost updateBody = new UpdatePost(playerId,playerName,bestScore);
		string body = JsonUtility.ToJson(updateBody);
    string updateEndpoint = "https://el6rwisdci.execute-api.us-east-1.amazonaws.com/dev/score";
    using (UnityWebRequest webRequest = UnityWebRequest.Post(updateEndpoint,body))
    {
			webRequest.SetRequestHeader("Content-Type", "application/json");
			byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(body);
			webRequest.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
			webRequest.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
			webRequest.SetRequestHeader("Content-Type", "application/json");
      yield return webRequest.SendWebRequest();
			Debug.Log(webRequest.downloadHandler.text);
    }
  }

}
