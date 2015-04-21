using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {

    public float cycleSpeed;

    //public Transform moon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * cycleSpeed * Time.deltaTime);
        //moon.Rotate(Vector3.right * cycleSpeed * Time.deltaTime);
	}
}
