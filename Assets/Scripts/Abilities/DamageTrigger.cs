using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        Human h = other.GetComponent<Human>();
        if(h != null)
        {
            h.DealDamage(damage);
        }
    }
}
