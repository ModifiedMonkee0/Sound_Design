using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class AudioManager : MonoBehaviour
{
    

    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playerMovement;

    

    private FMOD.Studio.EventInstance TripleJumpInstance; //burda instanceledik
    [SerializeField] FMODUnity.EventReference tripleJumpEvent;

    private FMOD.Studio.EventInstance DeadSoundInstance; //burda instanceledik
    [SerializeField] FMODUnity.EventReference deadEvent;

    private FMOD.Studio.EventInstance GrowSoundInstance; //burda instanceledik
    [SerializeField] FMODUnity.EventReference GrowEvent;

    //E�er bir sliderla de�i�tirmek istersek
    //[SerializeField] [Range(0f,2f)]
    //private float pitch;



    private void Start()
    {
      
        TripleJumpInstance = RuntimeManager.CreateInstance(tripleJumpEvent);

        DeadSoundInstance = RuntimeManager.CreateInstance(deadEvent);

        GrowSoundInstance = RuntimeManager.CreateInstance(GrowEvent);

       
    }
    public void PlayTripleJump()
    {
        //RuntimeManager.PlayOneShotAttached(tripleJumpEvent, player);
        TripleJumpInstance.start();
    }
    public void PlayDeadSound()
    {
        DeadSoundInstance.start();
    }

    public void PlayGrowSound()
    {
        GrowSoundInstance.start();
    }

    void Update()
    {
        //yeni bir float olu�turduk ve parametre de�erini kalan z�plama hakk�m�za e�itledik.
       int pitchValue = playerMovement.remainingJumps;
        

        //�imdi parametre ismini referans alarak o parametrenin de�erini az once olusturdugumuz floata d�n��t�rd�k
        TripleJumpInstance.setParameterByName("PitchChanger", pitchValue);


     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space'e bast�n");
            PlayTripleJump();  //burda �al��t�rmam gerekiyor, ��nk� her z�plamada bir kere oynamal�.
            
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            PlayDeadSound();
        }


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            PlayGrowSound();
        }




    }
}
