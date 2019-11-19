using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    [SerializeField]
    private Human target;

    private void Start()
    {
        target.OnDied += Target_OnDied;
    }

    private void Target_OnDied(Human obj)
    {
        DropManager.Instance.AddDrop(new DropData()
        {
            name = "Super Drop",
            position = target.transform.position,
            rarity = DropData.Rarity.REGULAR
        });
    }
}
