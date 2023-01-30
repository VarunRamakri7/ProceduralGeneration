using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GenerateAR : S_Weapon
{
    [SerializeField]
    private List<GameObject> barrels;
    [SerializeField]
    private List<GameObject> bodies;
    [SerializeField]
    private List<GameObject> grips;
    [SerializeField]
    private List<GameObject> scopes;
    [SerializeField]
    private List<GameObject> sights;
    [SerializeField]
    private List<GameObject> stocks;

    private GameObject ar;

    // Start is called before the first frame update
    void Start()
    {
        ar = null;
        weaponType = Type.AR;
    }

    public override GameObject Generate()
    {
        Debug.Log("Generating AR");

        if (ar != null)
        {
            Destroy(ar);
            ar = null;
        }

        // Create new gameobject for AR
        ar = Instantiate(bodies[Random.Range(0, bodies.Count)]); // Initialize AR by randomly selecting a body

        // Get a barrel and attach it to the body
        GameObject barrel = Instantiate(barrels[Random.Range(0, barrels.Count)]); // Randomly select a grip
        Transform barrelPoint = ar.transform.Find("Barrel_Point"); // Get grip attach point
        barrel.transform.parent = barrelPoint.transform; // Set the AR as the grip's parent
        barrel.transform.position = barrelPoint.position; // Update the grip's position

        // Get a scope and attach it to the body
        GameObject scope = Instantiate(scopes[Random.Range(0, scopes.Count)]); // Randomly select a grip
        Transform scopePoint = ar.transform.Find("Scope_Point"); // Get grip attach point
        scope.transform.parent = scopePoint.transform; // Set the AR as the grip's parent
        scope.transform.position = scopePoint.position; // Update the grip's position

        // Get a grip and attach it to the body
        GameObject grip = Instantiate(grips[Random.Range(0, grips.Count)]); // Randomly select a grip
        Transform gripPoint = ar.transform.Find("Grip_Point"); // Get grip attach point
        grip.transform.parent = gripPoint.transform; // Set the AR as the grip's parent
        grip.transform.position = gripPoint.position; // Update the grip's position

        // Get a sight and attach it to the body
        GameObject sight = Instantiate(sights[Random.Range(0, sights.Count)]); // Randomly select a grip
        Transform sightPoint = ar.transform.Find("Sight_Point"); // Get sight attach point
        sight.transform.parent = sightPoint.transform; // Set the AR as the sight's parent
        sight.transform.position = sightPoint.position; // Update the sight's position

        // Get a stock and attach it to the body
        GameObject stock = Instantiate(stocks[Random.Range(0, stocks.Count)]); // Randomly select a stock
        Transform stockPoint = ar.transform.Find("Stock_Point"); // Get stock attach point
        stock.transform.parent = stockPoint.transform; // Set the AR as the stock's parent
        stock.transform.position = stockPoint.position; // Update the stock's position

        return ar;
    }
}
