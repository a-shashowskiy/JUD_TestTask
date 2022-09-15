using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlaneterySystem
{
    public interface IPlaneterySystem
    { 
        public IEnumerable<IPlaneteryObject> planeteryObjects { get; set; }
        /// <summary>
        /// To control rottation arround of system center all system objects depend of mass this object have
        /// </summary>
        /// <param name="deltaTime"></param>
        public void UpdateSystem(float deltaTime);
    }
}