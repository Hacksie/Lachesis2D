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
        [SerializeField] public EnvironmentManager environment;


        [Header("Settings")]
        [SerializeField] public float rate = 2.0f;

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
                var amount = rate * Time.deltaTime;
                state.air -= amount;

                var area = environment.GetFirstCurrentArea();
                if (area != null)
                {
                    state.air += area.ConsumeAir(amount);
                }
            }
        }
    }

}