using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public float score;

    public audiomanager audiomanager;
    public VFXManager vfxmanager;
    public Scoremanager scoremanager;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolarig = bola.GetComponent<Rigidbody>(); 
            bolarig.velocity *= multiplier;

            animator.SetTrigger("hit");

            audiomanager.playSFX(collision.transform.position);

            vfxmanager.playVFX(collision.transform.position);

            //
            scoremanager.addScore(score);
        }
    }
}