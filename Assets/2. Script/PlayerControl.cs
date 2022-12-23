using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animator anim;
    public float speed;
    public int damage;
    public float rate;
    public Transform bulletPos;
    public GameObject bullet;
    float hAxis;
    float vAxis;
    bool mouse;
    bool isfireReady;
    float fireDelay;

    Vector3 moveVec;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("fwd", moveVec != Vector3.zero);
        Vector3 rota = transform.position + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //rota.y = 0;
        transform.LookAt(rota);

        if (Input.GetMouseButtonDown(0))
        {
            Use();
        }
    }
    void Attack()
    {
        fireDelay += Time.deltaTime;
        isfireReady = rate < fireDelay;
        if (mouse && isfireReady)
        {
            Use();
            anim.SetTrigger("attack");
            fireDelay = 0;
        }
    }
    public void Use()
    {
        StartCoroutine("shot");
    }
    IEnumerator shot()
    {
        GameObject intantBullet = Instantiate(bullet, bulletPos.position,bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * 50;
        yield return null;
    }
}