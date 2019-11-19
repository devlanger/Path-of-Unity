using UnityEngine;

[System.Serializable]
public class DropData
{
    public int id;
    public string name;
    public Vector3 position;
    public Rarity rarity;

    public enum Rarity : byte
    {
        REGULAR = 1,
        RARE = 2,
        LEGENDARY = 3
    }
}
