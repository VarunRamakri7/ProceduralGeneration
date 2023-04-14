using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GenerateWorld : MonoBehaviour
{
    [SerializeField]
    private S_GeneratePlanet generatePlanet;
    [SerializeField]
    private List<GameObject> planets;

    private GameObject world;
    private int numPlanets = 0;

    const int MAX_PLANETS = 20;

    // Start is called before the first frame update
    void Start()
    {
        world = this.gameObject;
        //planets = new List<GameObject>(MAX_PLANETS);
    }

    // Update is called once per frame
    void Update()
    {
        if (numPlanets < MAX_PLANETS)
        {
            MakePlanet();
        }
        //else
        //{
        //    RemoveUnseen();
        //}
    }

    /// <summary>
    /// Make a new planet
    /// </summary>
    public void MakePlanet()
    {
        // Create new planet
        GameObject planet = new GameObject("planet-" + numPlanets);

        planet.AddComponent<S_Planet>(); // Add planet script
        generatePlanet.GeneratePlanet(planet.GetComponent<S_Planet>()); // Generate planet

        planet.transform.parent = transform; // Set parent

        // Set position and instantiate
        Vector3 position = new Vector3(Random.Range(-35.0f, 35.0f),
            Random.Range(Camera.main.transform.position.y - 20.0f, Camera.main.transform.position.y + 20.0f),
            Random.Range(10.0f, 30.0f));
        planet.transform.localPosition = position;

        planets.Add(planet); // Add new planet to list
        numPlanets++; // Increment number of planets
    }

    /// <summary>
    /// Loop through planets and destroy unseen planets
    /// </summary>
    public void RemoveUnseen()
    {
        foreach(GameObject planet in planets)
        {
            if (isSeen(planet.transform.position))
            {
                planets.Remove(planet); // Remove first planet
                Destroy(planet); // Destroy first planet

                numPlanets--;
            }
        }
    }

    /// <summary>
    /// Check if given position is in camera's field of view
    /// </summary>
    /// <param name="position"></param>
    /// <returns>True if object is within Camera FOV, false otherwise</returns>
    public bool isSeen(Vector3 position)
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(position);
        return (screenPoint.z > 0 &&
            screenPoint.x > 0 &&screenPoint.x < 1 &&
            screenPoint.y > 0 && screenPoint.y < 1);
    }
}
