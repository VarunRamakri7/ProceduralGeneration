using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GenerateCrossbow : S_Weapon
{
    [SerializeField]
    private List<GameObject> bodies;
    [SerializeField]
    private List<GameObject> grips;
    [SerializeField]
    private List<GameObject> sights;
    [SerializeField]
    private List<GameObject> stocks;

    private GameObject crossbow;

    // Start is called before the first frame update
    void Start()
    {
        crossbow = null;
        weaponType = Type.CROSSBOW;
    }

    public override GameObject Generate()
    {
        Debug.Log("Generating Crossbow");

        if (crossbow != null)
        {
            Destroy(crossbow);
            crossbow = null;
        }
        // Create new gameobject for crossbow
        crossbow = Instantiate(bodies[Random.Range(0, bodies.Count)]); // Initialize crossbow by randomly selecting a body

        // Get a grip and attach it to the body
        GameObject grip = Instantiate(grips[Random.Range(0, grips.Count)]); // Randomly select a grip
        Transform gripPoint = crossbow.transform.Find("Grip_Point"); // Get grip attach point
        grip.transform.parent = crossbow.transform; // Set the crossbow as the grip's parent
        grip.transform.position = gripPoint.position; // Update the grip's position

        // Get a sight and attach it to the body
        GameObject sight = Instantiate(sights[Random.Range(0, sights.Count)]); // Randomly select a grip
        Transform sightPoint = crossbow.transform.Find("Sight_Point"); // Get sight attach point
        sight.transform.parent = crossbow.transform; // Set the crossbow as the sight's parent
        sight.transform.position = sightPoint.position; // Update the sight's position

        // Get a sight and attach it to the body
        GameObject stock = Instantiate(stocks[Random.Range(0, stocks.Count)]); // Randomly select a stock
        Transform stockPoint = crossbow.transform.Find("Stock_Point"); // Get stock attach point
        stock.transform.parent = crossbow.transform; // Set the crossbow as the stock's parent
        stock.transform.position = stockPoint.position; // Update the stock's position

        return crossbow;
    }
}