using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{

    //newtons (Force to accelerate 1kg 1m/s/s
    float max_thrust;
    Quaternion rotation;

    //Health
    private float Max_Health;
    private float Health;
    //Armor (armor level & damage reduction)
    private float Armor;
    private float A_redux;
    


    //Object References
    public GameObject MissionControler;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //LateUpdate is called at the end of every frame
    //DO PHYSICS HERE!!!
    void LateUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void Damage(float dmg)
    {
        Health -= dmg - dmg * A_redux;
        if(Health <= 0)
        {
            ;
        }
            
    }
}
