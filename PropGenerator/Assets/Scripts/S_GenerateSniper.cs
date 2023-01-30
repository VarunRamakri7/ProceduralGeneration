using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GenerateSniper : S_Weapon
{
    [SerializeField]
    private List<GameObject> barrels;
    [SerializeField]
    private List<GameObject> bodies;
    [SerializeField]
    private List<GameObject> frontBodies;
    [SerializeField]
    private List<GameObject> grips;
    [SerializeField]
    private List<GameObject> scopes;
    [SerializeField]
    private List<GameObject> stocks;

    private GameObject sniper;

    // Start is called before the first frame update
    void Start()
    {
        sniper = null;
        weaponType = Type.SNIPER;
    }

    public override GameObject Generate()
    {
        Debug.Log("Generating Sniper");

        if (sniper != null)
        {
            Destroy(sniper);
            sniper = null;
        }

        // Create new gameobject for AR
        sniper = Instantiate(bodies[Random.Range(0, bodies.Count)]); // Initialize AR by randomly selecting a body

        // Get a front body and attach it to the body
        GameObject front = Instantiate(frontBodies[Random.Range(0, frontBodies.Count)]); // Randomly select a front body
        Transform frontPoint = sniper.transform.Find("Front_Point"); // Get front body attach point
        front.transform.parent = frontPoint.transform; // Set the AR as the front body's parent
        front.transform.position = frontPoint.position; // Update the front body's position

        // Get a barrel and attach it to the body
        GameObject barrel = Instantiate(barrels[Random.Range(0, barrels.Count)]); // Randomly select a grip
        Transform barrelPoint = sniper.transform.Find("Barrel_Point"); // Get grip attach point
        barrel.transform.parent = barrelPoint.transform; // Set the AR as the grip's parent
        barrel.transform.position = barrelPoint.position; // Update the grip's position

        // Get a scope and attach it to the body
        GameObject scope = Instantiate(scopes[Random.Range(0, scopes.Count)]); // Randomly select a grip
        Transform scopePoint = sniper.transform.Find("Scope_Point"); // Get grip attach point
        scope.transform.parent = scopePoint.transform; // Set the AR as the grip's parent
        scope.transform.position = scopePoint.position; // Update the grip's position

        // Get a grip and attach it to the body
        GameObject grip = Instantiate(grips[Random.Range(0, grips.Count)]); // Randomly select a grip
        Transform gripPoint = sniper.transform.Find("Grip_Point"); // Get grip attach point
        grip.transform.parent = gripPoint.transform; // Set the AR as the grip's parent
        grip.transform.position = gripPoint.position; // Update the grip's position

        // Get a stock and attach it to the body
        GameObject stock = Instantiate(stocks[Random.Range(0, stocks.Count)]); // Randomly select a stock
        Transform stockPoint = sniper.transform.Find("Stock_Point"); // Get stock attach point
        stock.transform.parent = stockPoint.transform; // Set the AR as the stock's parent
        stock.transform.position = stockPoint.position; // Update the stock's position
        return sniper;
    }
}
