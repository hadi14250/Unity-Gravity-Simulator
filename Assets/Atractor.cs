using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Atractor : MonoBehaviour
{
    const float G = 6.674f;

    public static List<Atractor> Atractors;

    public Rigidbody rb;

    void FixedUpdate()
    {
        foreach (Atractor atractor in Atractors)
        {
            if(atractor != this)
                Atract(atractor);
        }
    }

    void OnEnable ()
    {
        if (Atractors == null)
            Atractors = new List<Atractor>();
        Atractors.Add(this);
    }

    void OnDisable()
    {
        Atractors.Remove(this);
    }
    void Atract(Atractor objectToAtract)
    {
        Rigidbody rbToAtract = objectToAtract.rb;

        Vector3 direction = rb.position - rbToAtract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = G * (rb.mass * rbToAtract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAtract.AddForce(force);
    }
}
