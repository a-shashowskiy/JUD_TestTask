using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlaneterySystem
{
    public interface IPlaneteryObject
    {
        /// <summary>
        /// To return calass of planetary Object
        /// </summary> 
        public MassClassEnum massClass { get; set; }
        /// <summary>
        /// To returm mass of object
        /// </summary>
        /// <returns></returns>
        public double mass { get; set; }

        public Transform piviot { get; }
    }
}
