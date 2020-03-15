using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HackedDesign
{
    [System.Serializable]
    public class ShipState
    {

        [SerializeField] public List<Area> currentAreaList;
        [SerializeField] public float air = 10000;
        [SerializeField] public float shield = 24;
        [SerializeField] public float shieldMax = 100;
        [SerializeField] public float airStorage = 10000;
        [SerializeField] public float powerStorage = 10000;
        [SerializeField] public float power = 1000;

    }
}
