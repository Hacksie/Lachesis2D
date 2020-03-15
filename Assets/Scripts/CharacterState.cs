using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HackedDesign
{
    public class CharacterState : MonoBehaviour
    {
        [SerializeField] public float air;
        [SerializeField] public float health;
        [SerializeField] public float stamina;
        [SerializeField] public float happiness;
        [SerializeField] public float hunger;
        [SerializeField] public float thirst;
        [SerializeField] public List<string> injuries;

        [SerializeField] public float airMax = 100.0f;

        [SerializeField] public UnityEvent zeroAirEvent;
        [SerializeField] public UnityEvent zeroHealthEvent;
        [SerializeField] public UnityEvent zeroHappinessEvent;
        [SerializeField] public UnityEvent zeroStaminaEvent;

        private void Update()
        {
            if (!Game.instance.IsPlaying())
                return;

            if (air <= 0)
            {
                zeroAirEvent.Invoke();
            }

            if (health <= 0)
            {
                zeroHealthEvent.Invoke();
            }
            if (stamina <= 0)
            {
                zeroStaminaEvent.Invoke();
            }
            if (happiness <= 0)
            {
                zeroHappinessEvent.Invoke();
            }
        }

    }
}