using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControler : MonoBehaviour
{
    public ShipControl_Testing shipControl;
    private Vector3 initV;
    // Start is called before the first frame update
    void Start()
    {
        initV = shipControl.rb.velocity;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
