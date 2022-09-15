using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneterySystem
{
    [CreateAssetMenu(fileName = "Planets", menuName = "SO_PlanetList", order = 0)]
    public class PlanetsGoList : ScriptableObject
    {
        public List<GameObject> planets;
    }
}
