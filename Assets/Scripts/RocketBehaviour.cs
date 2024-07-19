using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    private Transform target;
    private float speed = 15.0f;
    private bool homing;

    private float rcoketStrength = 15.0f;
    private float aliveTimer = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checking if homing and target has value or not 
        if(homing && target != null){
            // calluating the distace and direction of enemies and player 
            Vector3 moveDirection = (target.transform.position - transform.position).normalized;
            // moving toward target
            transform.position += moveDirection * speed * Time.deltaTime;
            // rotate project toward the target
            transform.LookAt(target);
        }
    }

   // method to set homing true and target and destory projectile after aliveTimer
    public void Fire(Transform newTarget){
        target = newTarget;
        homing = true;
        Destroy(gameObject, aliveTimer);
    }

    
    private void OnCollisionEnter(Collision col) {
        if(target != null){
            // if collision object is same as target which mean enemy tah
            if(col.gameObject.CompareTag(target.tag)){
                Rigidbody targetRigidbody = col.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -col.contacts[0].normal;
                // move the target object
                targetRigidbody.AddForce(away * rcoketStrength, ForceMode.Impulse);
                // destory the porjectile
                Destroy(gameObject);
            }
        }
    }
}
