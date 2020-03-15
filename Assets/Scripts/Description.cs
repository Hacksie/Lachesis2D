using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    [CreateAssetMenu(fileName = "Content", menuName = "Description")]
    public class Description : ScriptableObject
    {
        public string @short;
        public string description;
    }
}