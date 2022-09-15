using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneterySystem
{
    public class PlaneterySystemCreator : MonoBehaviour, IPlaneterySystemFactor
    {
        public GameObject sunPrefab; 
        public UnityEngine.UI.RawImage travelUIVFX;

        PlaneterySystemController curentSystem;
        GameObject cuentSystemGO;
        public IPlaneterySystem Create(double mass)
        { 
            GameObject system = new GameObject();
            cuentSystemGO = system;
            system.name = "PlaneterySystem_"+ mass;
            system.transform.position = Vector3.zero;
            Instantiate(sunPrefab, system.transform);
            system.AddComponent<PlaneterySystemController>();
            system.GetComponent<PlaneterySystemController>().Init(mass);
            return system.GetComponent<PlaneterySystemController>();
        }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(CreateNextSystem());
        }

        // Update is called once per frame
        void Update()
        {
            if (curentSystem != null) 
            {
                curentSystem.UpdateSystem(Time.deltaTime );
            }
        }

        public void ToNextSystem()
        {
            StartCoroutine(CreateNextSystem());
        }
        IEnumerator CreateNextSystem()
        {
            travelUIVFX.GetComponent<Animator>().Play("ShowTravel");
            GameObject toDestroySystem = cuentSystemGO;
            curentSystem = null; 

            yield return new WaitForSeconds(1);
            Destroy(toDestroySystem);
            double massStartSystem = Random.Range(1000, 10000);

            curentSystem = Create(massStartSystem) as PlaneterySystemController;
            yield return new WaitForSeconds(1);

            travelUIVFX.GetComponent<Animator>().Play("HideTravel");
        }
    }
}
