using UnityEngine;
using UnityEngine.InputSystem;

sealed class ScaleByInputValue : MonoBehaviour
{
    [SerializeField] Transform _transform = null;
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
        Debug.Log("Scale context " + ctx.ReadValue<float>());
        _transform.localScale = Vector3.one * 2 * ctx.ReadValue<float>();
    }
}
