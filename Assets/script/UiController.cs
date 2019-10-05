using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour {

	private static UiController _instance;

	public Text  scoreText;
	public  int score;

	public Text bestScore;

	public Text lastScore;

    public static UiController Instance
    {
        get
        {
            return _instance;
        }
    } 

	void Awake(){
		_instance=this;
		lastScore.text=""+PlayerPrefs.GetInt("lastScore");
		bestScore.text=""+PlayerPrefs.GetInt("bestScore");
	} 


	public void startGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}

	public void UpdateScore(int s = 100)
    {
        score += s;
        scoreText.text = "score \n" + score;
    }
}
