using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        GameObject inst = Instantiate(effect, transform.position, transform.rotation);
        Destroy(inst, 1);

        Destroy(gameObject);
    }
}
