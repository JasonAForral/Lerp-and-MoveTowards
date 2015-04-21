using UnityEngine;
using System.Collections;

public class ClickHandler : MonoBehaviour {

    public bool moving;
    public bool aToB;

    public Vector3 positionA;
    public Vector3 positionB;

    public float moveSpeed = 2f;

    public bool useMoveTowards;

    public bool slerpy;

	// Use this for initialization
	void Start () {
        aToB = false;
        moving = false;
        positionA = transform.position;
        positionB = positionA + Vector3.right * 10F;

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 myPosition = transform.position;
        if (moving)
            if (aToB)
                LerpOrMoveTo(myPosition, positionB);
            else
                LerpOrMoveTo(myPosition, positionA);

        if (moving && !aToB)
            if (Vector3.SqrMagnitude(myPosition - positionA) < 0.01f)
                moving = false;
        if (moving && aToB)
            if (Vector3.SqrMagnitude(myPosition - positionB) < 0.01f)
                moving = false;

        if (Input.GetButtonDown("Fire1"))
        {
            aToB = !aToB;
            moving = true;
        }
	}

    void LerpOrMoveTo (Vector3 start, Vector3 destination)
    {
        if (useMoveTowards)
        {
            transform.position = Vector3.MoveTowards(start, destination, moveSpeed * Time.deltaTime);
        }
        else if (!slerpy)
            transform.position = Vector3.Lerp(start, destination, moveSpeed * Time.deltaTime);
        else
            transform.position = Vector3.Slerp(start, destination, moveSpeed * Time.deltaTime);
    }
}
