using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class ObjectClicker : MonoBehaviour
{
    private bool _isInabaled = false;
    private Camera _camera;
    private void Awake() => _camera = GetComponent<Camera>();

    public void EnableClicker() => _isInabaled = true;
    public void DisableClicker() => _isInabaled = false;

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame && _isInabaled)
            Click();
    }

    private void Click()
    {
        var mousePosition = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit)
        {
            if (hit.transform.TryGetComponent<IClickable>(out IClickable clickable))
                clickable.Click();
        }
    }
}
