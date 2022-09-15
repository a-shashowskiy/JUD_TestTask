using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneterySystem
{
    [System.Serializable]
    public enum MassClassEnum
    {
        Asteroidan,
        Mercurian,
        Subterran,
        Terran,
        Superterran,
        Neptunian,
        Jovian
    }
     
    [System.Serializable]
    public enum StarClass
    {
        WhiteDwarf,
        BrownDwarf,
        RedDwarf,
        BlueGiant,
        OrangeGiant,
        RedGiant,
        BlueSupergiant,
        BlueHypergiant,
        RedSupergiant,
        RedHypergiant
    }
}
