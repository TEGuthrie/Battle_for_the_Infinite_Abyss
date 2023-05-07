using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShipControl_Testing : MonoBehaviour
{
    //Pause Menu
    public static bool gamePause = false;

    
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
    private Vector3 shipRotation;
    private Quaternion rotation;
    private float p_cor;
    private float y_cor;
    private float r_cor;

    //Health
    private float Max_Health;
    private float Health;

    //Armor (armor level & damage reduction)
    private int Armor;
    private float A_redux;

    //Weapons
    [SerializeField] Button kinetic_button;
    private float kinetic_timer;
    private float kinetic_available = 3.0f;
    public bool kin_canFire = true;
    public bool kb_pressed = false;

    //Object Refs
    [SerializeField] GameObject controler;
    [SerializeField] GameObject ActiveShip;
    [SerializeField] Slider t;
    [SerializeField] Slider p;
    [SerializeField] Slider y;
    [SerializeField] Slider r;
    [SerializeField] TextMeshProUGUI healthTxt;
    [SerializeField] GameObject Pause_Menu;
    [SerializeField] GameObject Gameplay_UI;
    [SerializeField] TextMeshProUGUI velocityTxt;
    [SerializeField] Slider velocity_slider;


    // Start is called before the first frame update
    void Start()
    {
        max_thrust = 20f;
        max_rotation = 10;
        rb = GetComponent<Rigidbody>();
        ship = ActiveShip.transform;
        Armor = 1;
        A_redux = Armor * .1f;
        Max_Health = 50;
        Health = Max_Health;
        healthTxt.text = ("Health: " + Health);
        velocity_slider.maxValue = max_velocity;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
        thrust = max_thrust * t.value;
        p_cor = (p.value - 2 * p.value) * max_rotation;
        y_cor = y.value * max_rotation;
        r_cor = r.value * max_rotation * 2;
        shipRotation = new Vector3(r_cor, y_cor, p_cor);
        if (kb_pressed || kinetic_timer > 0f && kinetic_timer < kinetic_available) 
        {
            kb_pressed = false;
            kinetic_timer += Time.deltaTime;
            Debug.Log("Kinetic Timer: " + kinetic_timer);
            kinetic_button.interactable = false;
        }
        Kin_Check();
    }
    //LateUpdate is called at the end of every frame
    //DO PHYSICS HERE!!!
    void LateUpdate()
    {
        velocity = (rb.velocity.x + rb.velocity.y + rb.velocity.z);
        abs_vel = Math.Abs(velocity);
        if (abs_vel < max_velocity)
        {
            rb.AddRelativeForce(transform.forward * thrust);
            velocityTxt.text = ("Velocity: " + velocity);
            velocity_slider.value = abs_vel;
        }
        transform.localEulerAngles = transform.localEulerAngles + shipRotation * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //float damage = collision.
    }

    public void Damage(float dmg)
    {
        Health -= dmg - dmg * A_redux;
        if (Health <= 0)
        {
            healthTxt.text = ("Health: 0");
            Destroy(ActiveShip);
            return;
        }
        healthTxt.text = ("Health: " + Health);

    }
    //Weapon Handling
    private void Kin_Check()
    {
         if (kinetic_timer > kinetic_available)
        {
            kinetic_button.interactable = true;
            kinetic_timer = 0f;
        }
    }
    public void Kin_b_pressed()
    {
        kb_pressed = true;
    }



    //PauseMenuSection
    public void PauseMenu()
    {
        if (gamePause)
            Resume();
        else
            Pause();
    }
    public void Resume()
    {
        Pause_Menu.SetActive(false);
        Gameplay_UI.SetActive(true);
        Time.timeScale = 1f;
        gamePause = false;
    }
    void Pause()
    {
        Gameplay_UI.SetActive(false);
        Pause_Menu.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }
    public void PauseInput(int val)
    {
        switch (val)
        {
            case 1:
                Resume();
                break;
            case 2:
                Time.timeScale = 1f;
                SceneManager.LoadScene(0);
                break;
            case 3:
                Application.Quit();
                Debug.Log("Quit");
                break;
        }
    }
}
