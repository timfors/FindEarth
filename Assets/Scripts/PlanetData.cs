using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Planet" , menuName = "SciptableObjects/Planets")]
public class Planets : ScriptableObject
{
    [SerializeField]
    private int speed;

    [SerializeField]
    private Sprite icon;


    public int Speed
    {
        get
        {
            return speed;
        }
    }

    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }
}
