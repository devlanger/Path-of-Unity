using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Human controlledCharacter;

    private Human target;

    public Human Target
    {
        get
        {
            return target;
        }
        private set
        {
            target = value;
        }
    }

    public event Action<Human> OnTargetChanged = delegate { };

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null)
            {
                if (Input.GetMouseButton(0))
                {
                    controlledCharacter.Move(hit.point);
                    controlledCharacter.Rotate(hit.point - controlledCharacter.transform.position, 0.2f);
                }

                if (Input.GetMouseButtonDown(1))
                {
                    controlledCharacter.Move(controlledCharacter.transform.position);
                    controlledCharacter.Rotate(hit.point - controlledCharacter.transform.position);
                    controlledCharacter.UseAbility(0);
                }

                SeekTarget(hit);
            }
        }
    }

    private void SeekTarget(RaycastHit hit)
    {
        Human newTarget = hit.collider.GetComponent<Human>();
        if (Target != newTarget)
        {
            if (newTarget != null && newTarget.tag == "Player")
            {
                Target = null;
            }
            else
            {
                Target = newTarget;
            }

            OnTargetChanged(Target);
        }
    }
}
