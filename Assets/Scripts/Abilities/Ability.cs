using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    [SerializeField]
    private int mana = 15;

    public int Mana
    {
        get
        {
            return mana;
        }
    }

    public abstract void Execute(Human user);
}
