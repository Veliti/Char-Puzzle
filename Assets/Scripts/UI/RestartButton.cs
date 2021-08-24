using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Collections.Generic;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    private Button _button;
    private bool _wasPressed = false;

    private void Awake() => _button = GetComponent<Button>();

    public void AwaitButtonPress(List<Task> tasks)
    {
        tasks.Add(AwaitButton());
    }
    public async Task AwaitButton()
    {
        while(!_wasPressed && this && this.enabled)
        {
            await Task.Yield();
        }
        _wasPressed = false;
    }
    public void EnableButton() => gameObject.SetActive(true);
    public void DisableButton() => gameObject.SetActive(false);
    public void SetPressed() => _wasPressed = true;

    private void OnEnable() => _button.onClick.AddListener(SetPressed);
    private void OnDisable() => _button.onClick.RemoveListener(SetPressed);
}
