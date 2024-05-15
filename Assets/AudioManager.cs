using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class AudioManager : MonoBehaviour
{
    
    [SerializeField] float rate;
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playerMovement;

    //eventi ve i�indeki parametreyi stringle belirtmem laz�m ki, remaining jumpla pitchi birle�tirip her z�plamada sesini kal�nla�t�ray�m.

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
        //yeni bir float olu�turduk ve parametre de�erini kalan z�plama hakk�m�za e�itledik.
       int pitchValue = playerMovement.remainingJumps;
        

        //�imdi parametre ismini referans alarak o parametrenin de�erini az once olusturdugumuz floata d�n��t�rd�k
        TripleJumpInstance.setParameterByName("PitchChanger", pitchValue);


     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space'e bast�n");
            PlayTripleJump();  //burda �al��t�rmam gerekiyor, ��nk� her z�plamada bir kere oynamal�.
            
        }
        
        
        
    }
}
