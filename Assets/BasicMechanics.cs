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
    public Vector3 normalScale = new Vector3(1f, 1f, 1f); // Yeni scale de�eri

    public float scaleDuration = 3f; // Scale de�i�im s�resi
    public GameObject body;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Sol t�klama ile animasyon ve spawn i�lemi
        {
            bodyAnimator.SetBool("Dead", true);
            StopPlayerMovement();

            StartCoroutine(WaitBeforeDead());
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) // Sa� t�klama ile boyut de�i�imi
        {
            StartCoroutine(ChangeScaleOverTime(newScale, scaleDuration));
            objectToInstantiate.transform.localScale = newScale;
        }
    }

    IEnumerator WaitBeforeDead()
    {
        yield return new WaitForSeconds(3.5f);
        InstantiateAtPlayerPosition();
        SpawnPlayer();
        bodyAnimator.SetBool("Dead", false);
        StartPlayerMovement();
    }

    void InstantiateAtPlayerPosition()
    {
        Instantiate(objectToInstantiate, playerTransform.position, playerTransform.rotation);
    }

    IEnumerator ChangeScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 initialScale = body.transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            body.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        body.transform.localScale = targetScale;
    }

    void SpawnPlayer()
    {
        playerPrefab.transform.position = respawnPoint.position;

        objectToInstantiate.transform.localScale = normalScale;
        body.transform.localScale = normalScale;

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
