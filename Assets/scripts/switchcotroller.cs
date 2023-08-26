using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class switchcotroller : MonoBehaviour
{
    private enum switchstate
    {
        off,
        on,
        Blink
            
    }

    public Collider bola;
    public Material onmaterial;
    public Material offmaterial;

    private switchstate state;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        set(false);
        StartCoroutine(Blinktimestart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other == bola)
        {
            toggle();
        }
    }
    private void set(bool active)
    {
        if (active == true)
        {
            state = switchstate.on;
            renderer.material = onmaterial;
            StopAllCoroutines();
        }
        else
        {
            state = switchstate.off;
            renderer.material = offmaterial;
            StartCoroutine(Blinktimestart(5));

        }
    }

    private void toggle()
    {
        if (state == switchstate.on)
        {
            set(false);
        }
        else
        {
            set(true);
        }
    }
    private IEnumerator Blink(int times)
    {
        state = switchstate.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onmaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offmaterial;
            yield return new WaitForSeconds(0.5f);
        }
        state = switchstate.off;
        StartCoroutine(Blinktimestart(5));
    }
    private IEnumerator Blinktimestart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));

    }
}
