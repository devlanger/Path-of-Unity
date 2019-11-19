using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static List<T> GetNearby<T>(Vector3 position, float radius)
    {
        List<T> result = new List<T>();
        Collider[] overlap = Physics.OverlapSphere(position, 5);
        foreach (var item in overlap)
        {
            T component = item.GetComponent<T>();
            if(component != null)
            {
                result.Add(component);
            }
        }

        return result;
    }
}
