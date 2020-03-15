using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(CharacterState))]
    public class AirConsumer : MonoBehaviour
    {
        private CharacterState state;
        [Header("External Game Objects")]
        [SerializeField] public ShipManager environment;


        [Header("Settings")]
        [SerializeField] public float rate = 2.0f;
        [SerializeField] public float inBonus = 2.0f;

        void Awake()
        {
            state = GetComponent<CharacterState>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!Game.instance.IsPlaying())
                return;

            if (state.air > 0)
            {
                var outAmount = rate * Time.deltaTime;
                state.air -= outAmount;

                var area = environment.GetFirstCurrentArea();
                if (area != null)
                {
                    var inAmount = Mathf.Min((rate + inBonus) * Time.deltaTime, state.airMax - state.air);
                    state.air += area.ConsumeAir(inAmount);
                }
            }
        }
    }

}