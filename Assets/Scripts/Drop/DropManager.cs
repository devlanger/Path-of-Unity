using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public static DropManager Instance { get; private set; }

    public event Action<DropData> OnDropAdded = delegate { };
    public event Action<DropData> OnDropRemoved = delegate { };

    private int lastDropId = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void AddDrop(DropData drop)
    {
        drop.id = lastDropId++;
        OnDropAdded(drop);
    }

    public void RemoveDrop(DropData dropData)
    {
        OnDropRemoved(dropData);
    }
}
