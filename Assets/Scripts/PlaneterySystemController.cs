using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneterySystem
{
    struct PlanetData
    {
        public MassClassEnum massClass;
        public double mass;
        public float radius;
    }
    public class PlaneterySystemController : MonoBehaviour, IPlaneterySystem
    {
        PlanetsGoList planetsToSpawn;
        public IEnumerable<IPlaneteryObject> planeteryObjects { get => _planeteryObjects; set => _planeteryObjects = value; }

        IEnumerable<IPlaneteryObject> _planeteryObjects;
        
        // Call to update and muve all object inside from outside
        public void UpdateSystem(float deltaTime)
        {
            foreach(IPlaneteryObject planeteryObject in planeteryObjects)
            {
                planeteryObject.piviot.Rotate(Vector3.up, deltaTime);
            }
            
        }

        // Use mass of system to spawn random system
        // T
        public void Init(double massSystem)
        {
            planetsToSpawn = Resources.Load<PlanetsGoList>("Planets");

            double leftMassSystem =  massSystem;
             

            List <PlanetData> planetToSpawn = GetListRandomePlanet(leftMassSystem);
            List<Planet> spawnedPlanet = new List<Planet>();
            for(int i=0; i< planetToSpawn.Count-1; i++)
            {
                GameObject centrOfOrbit = new GameObject();
                centrOfOrbit.transform.parent = transform;//spawn Centr To Rotate
                centrOfOrbit.AddComponent<Planet>();
                centrOfOrbit.name = "planet_" + i;
                centrOfOrbit.transform.Rotate(0, Random.Range(0, 360), 0); // For visul to different possition
                centrOfOrbit.GetComponent<Planet>().planet = Instantiate(planetsToSpawn.planets[Random.Range(0, planetsToSpawn.planets.Count - 1)], centrOfOrbit.transform);
                 
                leftMassSystem -= planetToSpawn[i].mass;
                centrOfOrbit.GetComponent<Planet>().planet.transform.localPosition = new Vector3(0, 0, i !=0 ?i * 25:20 + (planetToSpawn[i].radius * 2));
                
                centrOfOrbit.GetComponent<Planet>().Init(planetToSpawn[i].massClass, planetToSpawn[i].mass, planetToSpawn[i].radius); 

                spawnedPlanet.Add(centrOfOrbit.GetComponent<Planet>());
            }

            planeteryObjects = spawnedPlanet;
        }

        List <PlanetData> GetListRandomePlanet(double leftMass)
        {
            List <PlanetData> pDataList = new List<PlanetData>();
            int planetQuant = Random.Range(1, 10);
            double lm = leftMass;
            PlanetData pData;

            while (planetQuant > 0) 
            {
                planetQuant--;
                pData = new PlanetData();
                
                pData.massClass = GetRandomclassObject();
                pData.mass = GetRandomeMassFromClass(pData.massClass);

                if (lm != 0 && lm - pData.mass < 0) pData.mass = lm;
                
                pData.radius = GetRandomeRadiusFromClass(pData.massClass);
                pDataList.Add(pData);
                lm -= pData.mass;
                 
                if (lm <= 0) break;
            }
            

            Debug.Log(pDataList.Count);

            return pDataList;
        }
        MassClassEnum GetRandomclassObject ()
        {
            int classP = Random.Range(0, 6);
            return (MassClassEnum)classP;
        }
        double GetRandomeMassFromClass(MassClassEnum sizeClaass)
        {
            double mass = 0;

            switch (sizeClaass)
            {
                case MassClassEnum.Asteroidan:
                    mass = Random.Range(0, 0.00001f);
                    break;
                case MassClassEnum.Mercurian:
                    mass = Random.Range(0.00001f, 0.1f);
                    break;
                case MassClassEnum.Subterran:
                    mass = Random.Range(0.00001f, 0.5f);
                    break;
                case MassClassEnum.Terran:
                    mass = Random.Range(0.5f, 2f);
                    break;
                case MassClassEnum.Superterran:
                    mass = Random.Range(2f, 10f);
                    break;
                case MassClassEnum.Neptunian:
                    mass = Random.Range(10f, 50f);
                    break;
                case MassClassEnum.Jovian:
                    mass = Random.Range(50f, 5000f);
                    break;
            }

            return mass;
        }
        float GetRandomeRadiusFromClass(MassClassEnum sizeClaass)
        {
            float rad = 0;

            switch (sizeClaass)
            {
                case MassClassEnum.Asteroidan:
                    rad = Random.Range(0f, 0.03f);
                    break;
                case MassClassEnum.Mercurian:
                    rad = Random.Range(0.03f, 0.7f);
                    break;
                case MassClassEnum.Subterran:
                    rad = Random.Range(0.5f, 1.2f);
                    break;
                case MassClassEnum.Terran:
                    rad = Random.Range(0.8f, 1.9f);
                    break;
                case MassClassEnum.Superterran:
                    rad = Random.Range(1.3f, 3.3f);
                    break;
                case MassClassEnum.Neptunian:
                    rad = Random.Range(2.1f, 5.7f);
                    break;
                case MassClassEnum.Jovian:
                    rad = Random.Range(3.5f, 27f);
                    break;                    
            }

            return rad;
        }
    } 
}
