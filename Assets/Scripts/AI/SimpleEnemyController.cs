using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour
{
    [SerializeField]
    private Human target;

    [SerializeField]
    private Vector3 distance;

    [SerializeField]
    private float seekRadius = 5;

    [SerializeField]
    private float distanceFromTarget = 2;

    private Human player;

    private IEnumerator Start()
    {
        Vector3 pos = target.transform.position;

        StartCoroutine(SeekTarget());

        while(true)
        {
            if (player != null)
            {
                float distance = Vector3.Distance(player.transform.position, target.transform.position);
                if(distance < 2)
                {
                    target.Attack(player);
                    yield return new WaitForSeconds(1);
                }
                else
                {
                    Vector3 destination = player.transform.position + ((target.transform.position - player.transform.position).normalized * distanceFromTarget);
                    target.Move(destination);
                    target.Rotate(destination - target.transform.position);
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else
            {
                float rand = UnityEngine.Random.Range(0, 5);
                Vector3 destination = pos + new Vector3(UnityEngine.Random.Range(-distance.x, distance.x), 0, UnityEngine.Random.Range(-distance.z, distance.z));
                target.Move(destination);
                target.Rotate(destination - target.transform.position);
                yield return new WaitUntil(() => Vector3.Distance(target.transform.position, destination) < 1 || player != null);
                if (player == null)
                {
                    yield return new WaitForSeconds(rand);
                }
            }
        }
    }

    private IEnumerator SeekTarget()
    {
        while(true)
        {
            if(player == null)
            {
                foreach (var item in Utils.GetNearby<Human>(transform.position, 5))
                {
                    if (item.tag == "Player")
                    {
                        player = item;
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
