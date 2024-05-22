using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCondition : MonoBehaviour
{

    public AudioManager audioManager;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            {
            FinishLevel();
        
            }
    }

    public void FinishLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Bir sonraki sahnenin indeksini hesapla
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        // Bir sonraki sahneyi yükle
        SceneManager.LoadScene(nextSceneIndex);

        audioManager.StopFmod();
        
    }

    
}
