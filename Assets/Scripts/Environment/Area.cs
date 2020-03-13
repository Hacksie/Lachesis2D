using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Area : MonoBehaviour
    {
        [SerializeField] private EnvironmentManager environment = null;

        [SerializeField] public string title;
        [SerializeField] public AreaState state = new AreaState();

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


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                environment.AddCurrentArea(this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                environment.RemoveCurrentArea(this);
            }
        }

    }

}