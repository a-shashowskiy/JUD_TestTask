using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlaneterySystem
{
    public interface IPlaneterySystemFactor
    {
        //Create planetery system by proper mass
        public IPlaneterySystem Create(double mass);
    }
}