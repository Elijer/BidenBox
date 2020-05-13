using UnityEngine.Audio;
using UnityEngine;

//whenever we make a custom class and we want to be able to view it in the inspector, we have to mark it as serializable
[System.Serializable]
public class Sound {
  public string name;
  public AudioClip clip;

  [Range(0f, 1f)]
  public float volume = .7f;
  [Range(0.1f, 3f)]
  public float pitch;

  [HideInInspector]
  public AudioSource source;
}
