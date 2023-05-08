using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{

    //This is temporary, will be changed to be usable on all Enemy Ships

    //Thrust
    float max_thrust;
    private float thrust;
    public Rigidbody rb;
    private Transform ship;
    private float max_velocity = 20f;
    private float velocity;
    private float abs_vel;

    //Rotation
    float max_rotation;

    //Health
    private float Max_Health;
    private float Health;

    //Armor (armor level & damage reduction)
    private int Armor;
    private float A_redux;

    //Object Refs
    [SerializeField] GameObject PlayerShip;
    [SerializeField] GameObject Gameplay_UI;
    [SerializeField] GameObject Win;

    //Additional Refs
    private Vector3 toPlayer;


    // Start is called before the first frame update
    void Start()
    {
        max_thrust = 20f;
        max_rotation = 10;
        rb = GetComponent<Rigidbody>();
        ship = gameObject.transform;
        Armor = 1;
        A_redux = Armor * .1f;
        Max_Health = 50;
        Health = Max_Health;
    }

    // Update is called once per frame
    void Update()
    {
        toPlayer = PlayerShip.transform.position - gameObject.transform.position;
        //Debug.Log("Dist to player: " + toPlayer.magnitude);
        abs_vel = Math.Abs(rb.velocity.x + rb.velocity.y + rb.velocity.z);
    }
    //LateUpdate is called at hte end of every frame
    //Do physics here
    private void LateUpdate()
    {
        if (toPlayer.magnitude < 500f || abs_vel > 0f)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(toPlayer), (float)max_rotation);
            thrust = Mathf.Lerp(0f, 1f, 0.2f);
            rb.AddRelativeForce(toPlayer.normalized * thrust);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 relativeVel = collision.relativeVelocity;
        float dmgMult = relativeVel.x + relativeVel.y + relativeVel.z;
        float mass = collision.gameObject.GetComponent<Rigidbody>().mass;
    }
    private void Damage(float dmg)
    {
        Health -= dmg - dmg * A_redux;
        if (Health <= 0)
        {
            Time.timeScale = 0f;
            Gameplay_UI.SetActive(false);
            Win.SetActive(true);
        }
    }
}
