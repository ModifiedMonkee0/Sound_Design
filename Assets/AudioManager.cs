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


    //Eðer bir sliderla deðiþtirmek istersek
       //[SerializeField] [Range(0f,2f)]
       //private float pitch;



    private void Start()
    {
        //Yukarýda bir instance oluþturduk. Ve bir event referansý oluþturduk.Bunlarý aþaðýdaki kodla birleþtiriyoruz
        //aslýnda hangi eventin bir instancesini(örneðini) oluþturacaðýmýzý seçiyoruz.
        //Ýnstance oluþturmamýzýn sebebi ses parçasýný tüm projede etkilememek.
        TripleJumpInstance = RuntimeManager.CreateInstance(tripleJumpEvent);
        
        
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
