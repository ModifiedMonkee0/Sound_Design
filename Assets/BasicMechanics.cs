using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMechanics : MonoBehaviour
{
    public GameObject objectToInstantiate; // Instantiate etmek istediðiniz prefab
    public Transform playerTransform; // Player'ýn transform'u

    public Transform respawnPoint;
    public GameObject playerPrefab;
    


    public Vector3 newScale = new Vector3(2f, 2f, 2f); // Yeni scale deðeri
    public GameObject body;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Space tuþuna basýldýðýnda instantiate iþlemi yapýlacak
        {
            InstantiateAtPlayerPosition();
            SpawnPlayer();
            
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) // S tuþuna basýldýðýnda scale deðiþecek
        {
            ChangeScale();
        }
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

   
}
