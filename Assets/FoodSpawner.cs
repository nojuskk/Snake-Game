using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {

    public GameObject foodPrefab;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectsWithTag("Food").Length == 0)
        {
            double x = Random.Range(borderLeft.position.x, borderRight.position.x);
            double y = Random.Range(borderBottom.position.y, borderTop.position.y);
            x = System.Math.Round(x, 1);
            y = System.Math.Round(y, 1);

            if (x > 0)
                x -= 0.1;
            else if (x < 0)
                x += 0.1;
            if (y > 0)
                y -= 0.1;
            else if(y < 0)
                y += 0.1;

            Instantiate(foodPrefab, new Vector2((float)x, (float)y), Quaternion.identity);
        }
	}
}
