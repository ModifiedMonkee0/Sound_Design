using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class AudioManager : MonoBehaviour
{
    
    [SerializeField] float rate;
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playerMovement;

    //eventi ve içindeki parametreyi stringle belirtmem lazým ki, remaining jumpla pitchi birleþtirip her zýplamada sesini kalýnlaþtýrayým.

    private FMOD.Studio.EventInstance TripleJumpInstance; //burda instanceledik
    [SerializeField] FMODUnity.EventReference tripleJumpEvent;

    [SerializeField] [Range(0f,2f)]
    private float pitch;

    private void Start()
    {
        TripleJumpInstance = RuntimeManager.CreateInstance(tripleJumpEvent);
        //TripleJumpInstance.start();
        
    }
    public void PlayTripleJump()
    {
        //RuntimeManager.PlayOneShotAttached(tripleJumpEvent, player);
        TripleJumpInstance.start();
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
        
        
        
    }
}
