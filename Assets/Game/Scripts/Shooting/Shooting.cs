
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// 1f gives a steady enough supply to shoot once per obstacle probably
// 0.1f is a nice delay between fires to prevent the gunjam glitch

public class Shooting : MonoBehaviour {

  // Missile Object and Location
  public GameObject missilePrefab;
  public Transform  firePoint;
  public float fireForce = 2f;
  public float missileLifeSpan = 4f;
  public float spinSpeed = 7500f;
  public GameObject player;

  private Vector3 v;

  // Magazine, shooting action, reloading
  private bool gunLocked = false;
  private int ammo = 3;
  private float oldTime;
  public float waitInterval = 1f;

  // UI
  public Image flag1;
  public Image flag2;
  public Image flag3;

  //putin
  private bool putinPlayed = false;

  void Update(){

    ammoUI();
    gunLockHandler();

    if (CentralData.putinMode == false){
      if (gunLocked == false){
        if (Input.GetKeyDown("o")){
            Shoot();
            // Resets Reload Timer
            oldTime = Time.time;
        }
      }

      // Reload Timer
      if (ammo < 3){
        if (oldTime + waitInterval < Time.time){
          ammo = ammo + 1;
          oldTime = Time.time;
        }
      }
    } else {
      if (putinPlayed == false){
        //FindObjectOfType<AudioManager>().PlayPutin();
        //putinPlayed = true;
      }
    }
  }

  void Shoot(){
    if (gunLocked == true){
      return;
    } else if (gunLocked == false){
      //Instantiate projectile
      GameObject missileGameObject = (GameObject)Instantiate(missilePrefab, firePoint.position + new Vector3(0, 0, 36.4f), firePoint.rotation);
      Missile missile = missileGameObject.GetComponent<Missile>();
      v = player.GetComponent<Rigidbody>().velocity * fireForce;
      missile.GetComponent<Rigidbody>().velocity = v;

      // Configure the missile using it's own functions
      missile.Fire(spinSpeed);
      missile.SelfDestruct(missileLifeSpan);

      //lock the gun to prevent a glitch related to creating too many missiles at once, decrement ammo
      gunLocked = true;
      Invoke("Action", 0.1f);
      ammo--;
      
      //Biden changes faces when firing
      FaceSwitch biden = player.GetComponent<FaceSwitch>();
      biden.ChangeFace(2);

      // Biden says something
      FindObjectOfType<AudioManager>().PlayRandom();
    }
  }
  
  void Action(){
    gunLocked = false;
  }

  void gunLockHandler(){ 
    if (ammo >= 1 ){
      gunLocked = false;
    } else if (ammo < 1){
      gunLocked = true;
    }
  }

  void ammoUI(){
    if (ammo == 0){
      flag1.enabled = false;
      flag2.enabled = false;
      flag3.enabled = false;
    }
    
    else if (ammo == 1){
      flag1.enabled = true;
      flag2.enabled = false;
      flag3.enabled = false; 
    }
    
    else if (ammo == 2){
      flag1.enabled = true;
      flag2.enabled = true;
      flag3.enabled = false;
    }
    
    else if (ammo == 3){
      flag1.enabled = true;
      flag2.enabled = true;
      flag3.enabled = true;
    }
  } 
}


/*********** UNITY NOTES **************************************************************************************** /

(1)     Okay so breaking down the instantiation code below:
        It is possibly to simply Instantiate an object like this:
        Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        However, if we do this, we're not creating any way to REFEREnce the thing we just instantiated, which is
        a bit of a problem if we want to do anything with it after creating it. Which, I do.
        So in order to give it a name to reference, we do this:
        GameObject someGameObject = Instantiate(object, position, rotation);
        BUT. There's one last thing we have to do. Apparently, when Unity instantiates things, it just creates an
        'object', as in it is of type 'object'. For some reason, this is not enough. We need it to be of type
        'GameObject' in order to use it in the ways we'll need. So in order to 'cast' it as a game object, we can simply put
        this in front of the Instantiate function:
        (GameObject)
        Yeah, it's weird, isn't it? So, the final line of code will look like this:
        GameObject SomeGameObject = (GameObject)Instantiate(object, position, rotation);

************ END UNITY NOTES ************************************************************************************ */