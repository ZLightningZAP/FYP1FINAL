using UnityEngine;
using System.Collections;

public class TankWheelAnimation : MonoBehaviour
{

    public float BaseRotationSpeed; //Speed at which wheels will animate

    public GameObject TankToAnimate; //Enemy reference

    public Vector3 RotationAxis;   //Axis at which rotation will occur

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Only animate when reference object is moving
        if (TankToAnimate.GetComponent<Enemy>().GetMovingState() == true)
        {
            transform.Rotate(RotationAxis, (BaseRotationSpeed + TankToAnimate.GetComponent<Enemy>().MovementSpeed) * Time.deltaTime);
        }
    }
}
