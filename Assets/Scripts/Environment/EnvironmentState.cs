using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HackedDesign
{
    [System.Serializable]
    public class EnvironmentState
    {

        [SerializeField] public List<Area> currentAreaList;
        [SerializeField] public float oxygenStorage = 0;
        [SerializeField] public float oxygenStorageMax = 100;
        [SerializeField] public float climateControl = 26.0f;
        [SerializeField] public float climateControlEnergy = 20;

    }
}
