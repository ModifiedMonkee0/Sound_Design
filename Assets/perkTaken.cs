using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perkTaken : MonoBehaviour
{
    public SpriteRenderer tripleJumpPerk;
    [SerializeField] PlayerMovement playerMovement;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("TriggerWorks");
            tripleJumpPerk.enabled = false;
            playerMovement.tripleJumpActive = true;
        }

    }




}
