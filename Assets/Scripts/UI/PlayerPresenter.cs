using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private CharacterState characterState = null;
        [SerializeField] Text charAir = null;
        [SerializeField] Text charHealth = null;
        [SerializeField] Text charHappiness = null;
        [SerializeField] Text charStamina = null;
        [SerializeField] Text charHunger = null;
        [SerializeField] Text charThirst = null;

        // Update is called once per frame
        void LateUpdate()
        {
            charAir.text = Mathf.RoundToInt(characterState.air).ToString();
            charHealth.text = Mathf.RoundToInt(characterState.health).ToString();
            charHappiness.text = Mathf.RoundToInt(characterState.happiness).ToString();
            charStamina.text = Mathf.RoundToInt(characterState.stamina).ToString();
            charHunger.text = Mathf.RoundToInt(characterState.hunger).ToString();
            charThirst.text = Mathf.RoundToInt(characterState.thirst).ToString();
        }
    }

}