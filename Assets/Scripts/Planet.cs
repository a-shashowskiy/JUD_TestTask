using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlaneterySystem
{
    public class Planet : MonoBehaviour, IPlaneteryObject
    {
        public GameObject planet;
        public Transform piviot { get => transform; } 
        public MassClassEnum massClass { get => planetMassClass; set => planetMassClass = value; }
        public double mass { get => planetMass; set => planetMass = value; }


        private MassClassEnum planetMassClass;
        private double planetMass;
        private float radius;
        // Start is called before the first frame update
        public void Init(MassClassEnum classObject, double massObject, float planetRadius)
        {
            radius = planetRadius;
            if (classObject != MassClassEnum.Asteroidan)planet.transform.localScale = new Vector3(radius, radius, radius);
            planetMass = massObject;
            planetMassClass = classObject;
        } 
    }
}