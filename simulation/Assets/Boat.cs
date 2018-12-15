using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

    public Rigidbody rb;

    public int windAngle = 270;
    public int boatAngle = 0;

    double[,] headingSpeed = new double[,]
        {
            {0, 0},
            {10, 0},
            {20, 0},
            {30, 5},
            {40, 7.5},
            {50, 10},
            {60, 11.5},
            {70, 12.5},
            {80, 14},
            {90, 14.5},
            {100, 14.5},
            {110, 14},
            {120, 12.5},
            {130, 10},
            {140, 7.5},
            {150, 6.5},
            {160, 5},
            {170, 5},
            {180, 4},
            {190, 5},
            {200, 5},
            {210, 6.5},
            {220, 7.5},
            {230, 10},
            {240, 12.5},
            {250, 14},
            {260, 14.5},
            {270, 14.5},
            {280, 14},
            {290, 12.5},
            {300, 11.5},
            {310, 10},
            {320, 7.5},
            {330, 5},
            {340, 0},
            {350, 0},
            {360, 0},
        };

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = rb.velocity;
        v.z = 1;
        rb.velocity = v;
        // v = (headingSpeed[(windAngle - boatAngle) % 180, 1] / 15) * speedFactor
    }
}
