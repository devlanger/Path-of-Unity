using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Ranged")]
public class RangedAbility : Ability
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float speed = 15;   

    [SerializeField]
    private int amount = 1;

    public override void Execute(Human user)
    {
        GameObject inst = Instantiate(projectile, user.transform.position + user.transform.forward, user.transform.rotation);
        Destroy(inst, 3);
        Rigidbody rb = inst.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = user.transform.forward * speed;
    }
}
