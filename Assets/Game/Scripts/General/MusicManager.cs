using UnityEngine.Audio;
using System;
using UnityEngine;

public class MusicManager : MonoBehaviour {
  public Sound[] sounds;

  private int current;

  void Awake(){
    foreach (Sound s in sounds){
      s.source = gameObject.AddComponent<AudioSource>();
      s.source.clip = s.clip;

      s.source.volume = s.volume;
      s.source.pitch = s.pitch;
    }
  }

  public void Play (string name){
    //using system allows us to use Array.Find()
    Sound s = Array.Find(sounds, sound => sound.name == name);
    s.source.Play();
  }

  public void PlayRandom (){
    //Sound s = Array.Find()
    if (current != null){
      sounds[current].source.Pause();
    }
    int randomInt = UnityEngine.Random.Range(0, sounds.Length);
    sounds[randomInt].source.Play();
    current = randomInt;
    //Debug.Log("Hey!");
  }

}
