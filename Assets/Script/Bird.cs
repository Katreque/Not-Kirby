using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float forcaCima = 200f;

    private bool isMorto = false;
    private Rigidbody2D notKirbyRbd2;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        notKirbyRbd2 = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMorto == false) {
            if (Input.GetMouseButtonDown(0)) {
                notKirbyRbd2.velocity = Vector2.zero;
                notKirbyRbd2.AddForce(new Vector2(0, forcaCima));
                anim.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D() {
        isMorto = true;
        anim.SetTrigger("Dead");
        notKirbyRbd2.velocity = Vector2.zero;
        GameControl.instancia.JogadorMorreu();
    }
}
