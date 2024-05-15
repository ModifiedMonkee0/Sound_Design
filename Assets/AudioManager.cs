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


    //E�er bir sliderla de�i�tirmek istersek
       //[SerializeField] [Range(0f,2f)]
       //private float pitch;



    private void Start()
    {
        //Yukar�da bir instance olu�turduk. Ve bir event referans� olu�turduk.Bunlar� a�a��daki kodla birle�tiriyoruz
        //asl�nda hangi eventin bir instancesini(�rne�ini) olu�turaca��m�z� se�iyoruz.
        //�nstance olu�turmam�z�n sebebi ses par�as�n� t�m projede etkilememek.
        TripleJumpInstance = RuntimeManager.CreateInstance(tripleJumpEvent);
        
        
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
