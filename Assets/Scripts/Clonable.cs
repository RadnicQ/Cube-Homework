using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clonable : MonoBehaviour 
{
    [SerializeField] private int _divideChance = 100;
    private int _divisionFactor = 2;

    public int GetChance()
    {
        int chance = _divideChance;
        _divideChance /= _divisionFactor;

        return chance;
    }
}