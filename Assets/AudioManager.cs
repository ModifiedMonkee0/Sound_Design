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

    private FMOD.Studio.EventInstance IdleSoundInstance; //burda instanceledik
    [SerializeField] FMODUnity.EventReference IdleEvent;

    private FMOD.Studio.EventInstance TireRollingSoundInstance; //burda instanceledik
    [SerializeField] FMODUnity.EventReference TireRollingEvent;

    private FMOD.Studio.EventInstance BackgroundSoundInstance; //burda instanceledik
    [SerializeField] FMODUnity.EventReference BackgroundSoundEvent;

    //Eðer bir sliderla deðiþtirmek istersek
    //[SerializeField] [Range(0f,2f)]
    //private float pitch;



    private void Start()
    {
      
        TripleJumpInstance = RuntimeManager.CreateInstance(tripleJumpEvent);

        DeadSoundInstance = RuntimeManager.CreateInstance(deadEvent);

        GrowSoundInstance = RuntimeManager.CreateInstance(GrowEvent);

        IdleSoundInstance = RuntimeManager.CreateInstance(IdleEvent);

        TireRollingSoundInstance = RuntimeManager.CreateInstance(TireRollingEvent);

        BackgroundSoundInstance = RuntimeManager.CreateInstance(BackgroundSoundEvent);

        BackgroundSoundInstance.start();

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

    public void PlayIdleSound()
    {
        IdleSoundInstance.start();
    }

    public void PlayTireSound()
    {
        TireRollingSoundInstance.start();
    }

    void Update()
    {
       


     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space'e bastýn");
            PlayTripleJump();  //burda çalýþtýrmam gerekiyor, çünkü her zýplamada bir kere oynamalý.
            
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            PlayDeadSound();
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.Alpha2))
        {

            PlayGrowSound();
        }

        if (Mathf.Abs(playerMovement.horizontal) > 0.1f)
        {
            PlayIdleSound();
           
        }

        if (Mathf.Abs(playerMovement.horizontal) < 0.1f)
        {
            PlayTireSound();
           
            
        }


    }
}
