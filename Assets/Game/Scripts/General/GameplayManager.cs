using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour {

    public Text scoreText;
    public Text HighScore;
    private int currentScore;
    public float restartDelay = 0.01f;
    public GameObject biden;

    public GameObject player1;
    public GameObject player1Cam;
    public GameObject player2;
    public GameObject player2Cam;

    public Slider MySlider;
    //MySlider.value = 0.5f;

    private bool pitchOffset = false;

    bool gameHasEnded = false;

    
    public void Start(){
      if(MySlider != null){
        pitchOffset = false;
        MySlider.value = CentralData.musicVolume;
        ChangeVolume();
      }
    }

    public void FixedUpdate(){
      if (pitchOffset == true){
        offsetPitch();
      }
    }

    public void darkPrince(bool activated){
      AudioSource music = biden.GetComponent<AudioSource>();
      if (activated == true){
        music.pitch = .5f;
      } else {
        music.pitch = 1f;
      }
    }

    public void offsetPitch(){
      AudioSource music = biden.GetComponent<AudioSource>();
      music.pitch -= 0.006f;
    }

    public void UpdateScore(int score){
      currentScore += score;
      if (currentScore > CentralData.HighScore){
        CentralData.HighScore = currentScore;
      }
      scoreText.text = currentScore.ToString();
    }

    public void DisplayHighScore(){
      if (HighScore.text != null){
        HighScore.text = "Highscore: " + CentralData.HighScore.ToString();
      } else {
        HighScore.text = "Highscore: ---";
      }
    }

    public void EndGame (){
      if (gameHasEnded == false){
        pitchOffset = true;

        FindObjectOfType<TimeManager>().SlowDownTime();
        //music.volume
        Invoke("Restart", restartDelay);
        gameHasEnded = true;
        //Restore time if it is changed by the EndGame() function
        //FindObjectOfType<TimeManager>().RestoreTime();

        //Restart(); // Instead of using Restart() directly, Invoke is used, which allows us to restart with a delay.
      }
    }

    public void ChangeVolume(){
      if (MySlider != null){
        AudioSource music = biden.GetComponent<AudioSource>();
        CentralData.musicVolume = (int)MySlider.value;
        music.volume = 0.1f * CentralData.musicVolume;
      }
    }

    public void GameVolume(){
      AudioSource music = biden.GetComponent<AudioSource>();
      music.volume = 0.1f * CentralData.musicVolume;
    }

    public void Restart(){
      FindObjectOfType<TimeManager>().RestoreTime();
      SceneManager.LoadScene("Start Screen");
    }

    public void ReturnMainMenu () {
      SceneManager.LoadScene("Start Screen");
    }

    public void StartGame (){
      SceneManager.LoadScene("Level01");
    }
}
