using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMechanics : MonoBehaviour
{
    public GameObject objectToInstantiate; // Instantiate etmek istedi�iniz prefab
    public Transform playerTransform; // Player'�n transform'u

    public Transform respawnPoint;
    public GameObject playerPrefab;
    public Animator bodyAnimator;

    public Rigidbody2D rb2d;


    public Vector3 newScale = new Vector3(2f, 2f, 2f); // Yeni scale de�eri
    public GameObject body;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Space tu�una bas�ld���nda instantiate i�lemi yap�lacak
        {
            bodyAnimator.SetBool("Dead", true);
            StopPlayerMovement();
            
            WaitBeforeDead();
            StartCoroutine(WaitBeforeDead());


        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) // S tu�una bas�ld���nda scale de�i�ecek
        {
            ChangeScale();
        }
    }

    IEnumerator WaitBeforeDead()
    {
        yield return new WaitForSeconds(2);
        InstantiateAtPlayerPosition();
        SpawnPlayer();
        bodyAnimator.SetBool("Dead", false);
        StartPlayerMovement();
    }
    void InstantiateAtPlayerPosition()
    {
        
        Instantiate(objectToInstantiate, playerTransform.position, playerTransform.rotation);
    }
    void ChangeScale()
    {
        
        body.transform.localScale = newScale;
        objectToInstantiate.transform.localScale = newScale;
        
    }

    void SpawnPlayer()
    {
        playerPrefab.transform.position = respawnPoint.position;
    }

   void StopPlayerMovement()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void StartPlayerMovement()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}
