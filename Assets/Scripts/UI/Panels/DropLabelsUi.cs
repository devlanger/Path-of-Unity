using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLabelsUi : MonoBehaviour
{
    [SerializeField]
    private DropLabel dropLabelPrefab;

    [SerializeField]
    private Transform labelsParent;

    private Dictionary<int, DropLabel> labels = new Dictionary<int, DropLabel>();

    private void Start()
    {
        DropManager.Instance.OnDropAdded += Instance_OnDropAdded;
        DropManager.Instance.OnDropRemoved += Instance_OnDropRemoved;    
    }

    private void OnDestroy()
    {
        if (DropManager.Instance != null)
        {
            DropManager.Instance.OnDropAdded -= Instance_OnDropAdded;
            DropManager.Instance.OnDropRemoved -= Instance_OnDropRemoved;
        }
    }

    private void LateUpdate()
    {
        foreach (var item in labels)
        {
            item.Value.transform.position = Camera.main.WorldToScreenPoint(item.Value.DropData.position);
        }
    }

    private void Instance_OnDropRemoved(DropData obj)
    {
        if(labels.TryGetValue(obj.id, out DropLabel label))
        {
            labels.Remove(obj.id);
            Destroy(label.gameObject);
        }
    }

    private void Instance_OnDropAdded(DropData obj)
    {
        DropLabel labelInst = Instantiate(dropLabelPrefab, labelsParent);
        labelInst.Fill(obj);
        labels.Add(obj.id, labelInst);
    }
}
