﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class EnvironmentManager : MonoBehaviour
    {
        [SerializeField] EnvironmentState state = new EnvironmentState();

        [SerializeField] GameObject level1 = null;
        [SerializeField] GameObject level2 = null;
        // Start is called before the first frame update

        private void Start()
        {
            level1.SetActive(true);
            level2.SetActive(false);
        }

        public void AddCurrentArea(Area area)
        {
            if(!state.currentAreaList.Contains(area))
            {
                state.currentAreaList.Add(area);
            }
        }

        public void RemoveCurrentArea(Area area)
        {
            if (state.currentAreaList.Contains(area))
            {
                state.currentAreaList.Remove(area);
            }
        }

        public Area GetLastCurrentArea() => state.currentAreaList.Count <= 0 ? null : state.currentAreaList[state.currentAreaList.Count - 1];
        public Area GetFirstCurrentArea() => state.currentAreaList.Count <= 0 ? null : state.currentAreaList[0];

        public void TransitionUp()
        {
            Logger.Log(name, "Transition up");
            level1.SetActive(true);
            level2.SetActive(false);
        }

        public void TransitionDown()
        {
            Logger.Log(name, "Transition down");
            level1.SetActive(false);
            level2.SetActive(true);
        }

    }
}