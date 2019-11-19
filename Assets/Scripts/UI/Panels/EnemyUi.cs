using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUi : MonoBehaviour
{
    [SerializeField]
    private PlayerController controller;

    [SerializeField]
    private Slider healthBar;

    private Human lastTarget;

    private void Start()
    {
        controller.OnTargetChanged += Controller_OnTargetChanged;    
    }

    private void Controller_OnTargetChanged(Human obj)
    {
        healthBar.gameObject.SetActive(obj != null);

        if(lastTarget != null)
        {
            lastTarget.OnHealthChanged -= Obj_OnHealthChanged;
            lastTarget.OnDied -= LastTarget_OnDied;
        }

        if (obj != null)
        {
            obj.OnHealthChanged += Obj_OnHealthChanged;
            obj.OnDied += LastTarget_OnDied;

            Obj_OnHealthChanged(obj);
        }

        lastTarget = obj;
    }

    private void LastTarget_OnDied(Human obj)
    {
        healthBar.gameObject.SetActive(false);
    }

    private void Obj_OnHealthChanged(Human obj)
    {
        healthBar.value = (float)obj.health / 100f;
    }
}
