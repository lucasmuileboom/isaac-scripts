using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private EnemyMovement EnemyMovement;

    private void Awake()
    {
        EnemyMovement = GetComponent<EnemyMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")//nodig als ik we een nieuw kant op moeten lopen als je tegen de muur komt
        {
            print("wall");
        }
    }
}
