using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControler : MonoBehaviour
{
    public ShipControl_Testing shipControl;
    private float initV;
    private Vector3 pRotation;
    private Transform pTrans;
    private Vector3 pVel;
    private float inst_time;

    private void Awake()
    {
        inst_time = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Kinetic Projectile instantiated.");
        pVel = this.GetComponentInParent<Rigidbody>().velocity;
        initV = (pVel.x + pVel.y + pVel.z);
        pTrans = this.GetComponentInParent<Transform>();
        pRotation = new Vector3(pTrans.rotation.x,pTrans.rotation.y,pTrans.rotation.z);
    }
    private void Update()
    {
        if(Time.time-inst_time > 10f)
        {
            Destroy(this);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        this.GetComponent<Rigidbody>().AddForce(pRotation*initV*1.5f,ForceMode.Impulse);
    }
}
