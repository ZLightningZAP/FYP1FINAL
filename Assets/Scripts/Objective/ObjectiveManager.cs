using UnityEngine;
using System.Collections;

public class ObjectiveManager : MonoBehaviour
{
    public Objectives[] objectives;

    // Use this for initialization
    void Start()
    {
        objectives = GetComponents<Objectives>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
