using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCondition : MonoBehaviour
{

    public BasicMechanics basicMechanics;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            basicMechanics.SpawnPlayer();

        }
    }

    public void DieAndRes()
    {
        basicMechanics.SpawnPlayer();
    }
}
