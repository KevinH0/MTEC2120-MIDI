using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateArticles : MonoBehaviour
{
    [SerializeField] Transform _transform = null;
    [SerializeField] InputAction _action = null;
    [SerializeField] ParticleSystem ps;

    void OnEnable()
    {
        _action.performed += OnActivateParticles;
        _action.Enable();
    }

    void OnDisable()
    {
        _action.performed -= OnPerformed;
        _action.Disable();
    }

    void OnPerformed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Scale context " + ctx.ReadValue<float>());
        _transform.localScale = Vector3.one * ctx.ReadValue<float>();
    }

    void OnActivateParticles(InputAction.CallbackContext ctx)
    {
        Debug.Log("Particle Context is " + ctx.ReadValueAsButton());
        if (ctx.ReadValueAsButton())
        {
            ps.Play();
        }
        else
        {
            ps.Stop();
        }

    }

}