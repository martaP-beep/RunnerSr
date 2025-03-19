using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPowerupStats", menuName = "Powerup/Powerup Stats")]
public class PowerupStats : ScriptableObject
{
    [SerializeField]
    private float[] value;

    public float GetValue(int level=1)
    {
        if (level < 0)
            return value[0];
        else if (level >= value.Length)
            return value[value.Length - 1];
        else
            return value[level - 1];
    }
}
