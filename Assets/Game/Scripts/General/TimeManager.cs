using UnityEngine;

public class TimeManager : MonoBehaviour {

    public float slowdownFactor = .07f;
    public float slowdownLength = 2f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
      //Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
      //Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

    }

    public void SlowDownTime(){
      Time.timeScale = slowdownFactor;
      Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public void RestoreTime(){
      Time.timeScale = 1f;
      Time.fixedDeltaTime = Time.unscaledDeltaTime;
    }
}
