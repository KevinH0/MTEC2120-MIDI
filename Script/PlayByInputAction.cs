using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

sealed class PlayByInputAction : MonoBehaviour
{
    [SerializeField] PlayableDirector _playable = null;
    [SerializeField] InputAction _action = null;

    void OnEnable()
    {
        _action.performed += OnPerformed;
        _action.Enable();
    }

    void OnDisable()
    {
        _action.performed -= OnPerformed;
        _action.Disable();
    }

    void OnPerformed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Context is " + ctx.ReadValue<float>());
        _playable.Play();
    }

}
