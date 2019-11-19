using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropLabel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Text nameText;

    public DropData DropData { get; private set; }

    public void Fill(DropData drop)
    {
        this.DropData = drop;
        this.nameText.text = drop.name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DropManager.Instance.RemoveDrop(DropData);
    }
}
