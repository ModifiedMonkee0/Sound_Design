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

    //Eðer bir sliderla deðiþtirmek istersek
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
        //yeni bir float oluþturduk ve parametre deðerini kalan zýplama hakkýmýza eþitledik.
       int pitchValue = playerMovement.remainingJumps;
        

        //þimdi parametre ismini referans alarak o parametrenin deðerini az once olusturdugumuz floata dönüþtürdük
        TripleJumpInstance.setParameterByName("PitchChanger", pitchValue);


     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space'e bastýn");
            PlayTripleJump();  //burda çalýþtýrmam gerekiyor, çünkü her zýplamada bir kere oynamalý.
            
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
