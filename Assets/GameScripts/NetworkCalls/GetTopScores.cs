using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
class TopScoresResponse
{
  public Scores[] scores = null;

  public static TopScoresResponse CreateFromJSON(string jsonString)
  {
    return JsonUtility.FromJson<TopScoresResponse>(jsonString);
  }

}

[System.Serializable]
class Scores
{
  public string playerName = "";
  public int score = 0;
  public int position = 0;
}

public class GetTopScores : MonoBehaviour
{
  [SerializeField] GameObject loadingObject;
  [SerializeField] ScorePopulator scorePopulator;
  void Start()
  {
    StartCoroutine(GetRequest("https://el6rwisdci.execute-api.us-east-1.amazonaws.com/dev/score/"+PlayerPrefs.GetString(PrefKeys.playerID)));
  }

  IEnumerator GetRequest(string uri)
  {
    Debug.Log("Starting network call");
    Debug.Log(uri);
    using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
    {
      yield return webRequest.SendWebRequest();
      if (webRequest.isNetworkError || webRequest.responseCode != 200)
      {
        Debug.Log("A network error occurred");
      }
      else
      {
        loadingObject.SetActive(false);
        scorePopulator.gameObject.SetActive(true);
        Debug.Log(webRequest.downloadHandler.text);
				TopScoresResponse tsr = TopScoresResponse.CreateFromJSON(webRequest.downloadHandler.text);
				Debug.Log(tsr.scores[0].playerName);
        foreach(Scores score in tsr.scores){
          scorePopulator.AddNewScore(score.position,score.playerName,score.score);
        }
      }
    }
  }
}
