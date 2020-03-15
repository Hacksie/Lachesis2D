using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class ShipPresenter : MonoBehaviour
    {
        [Header("Game Objects")]
        [SerializeField] private ShipManager environment = null;
        [SerializeField] private Description ship;
        [Header("UI")]
        [SerializeField] Text shipTitle = null;
        [SerializeField] Text shipAir = null;
        [SerializeField] Text shipPower = null;
        [SerializeField] Text shipShield = null;

        void Start()
        {
            shipTitle.text = ship.@short;
        }

        public void LateUpdate()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            
            shipAir.text = Mathf.RoundToInt(environment.state.air).ToString();
            shipShield.text = Mathf.RoundToInt(environment.state.shield).ToString();
            shipPower.text = Mathf.RoundToInt(environment.state.power).ToString();
        }

    }
}