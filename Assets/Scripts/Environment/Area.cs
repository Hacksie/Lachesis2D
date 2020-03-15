using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Area : MonoBehaviour
    {
        [Header("Game Objects")]
        [SerializeField] private ShipManager ship = null;
        [SerializeField] private GameObject propsParent = null;

        [Header("Settings")]
        [SerializeField] public string title;
        [SerializeField] public float airRefillRate = 5.0f;
        [Header("State")]
        [SerializeField] public AreaState state = new AreaState();
        [Header("Props")]
        [SerializeField] public List<PowerCoupling> powerCouplings = new List<PowerCoupling>();
        [SerializeField] public List<AirVent> airVents = new List<AirVent>();

        public float ConsumeAir(float amount)
        {
            if (state.air >= amount)
            {
                state.air -= amount;
                return amount;
            }
            else
            {
                var ret = state.air;
                state.air = 0;
                return ret;
            }
        }

        private void Update()
        {
            UpdateAir();
        }

        private void UpdateAir()
        {
            if (state.air >= state.airCapacity)
                return;
                   
            foreach (var airVent in airVents)
            {
                if (state.air < state.airCapacity)
                {
                    var amount = Mathf.Min(airRefillRate * Time.deltaTime, (state.airCapacity - state.air));
                    state.air += airVent.ConsumeAir(amount);
                }
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ship.AddCurrentArea(this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ship.RemoveCurrentArea(this);
            }
        }

    }

}