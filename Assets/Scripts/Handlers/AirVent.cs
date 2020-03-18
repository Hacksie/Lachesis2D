using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class AirVent : MonoBehaviour
    {
        [Header("Game Objects")]
        [SerializeField] private ShipManager ship = null;

        public float ConsumeAir(float amount)
        {
            return ship.ConsumeAir(amount);
        }
    }
}
