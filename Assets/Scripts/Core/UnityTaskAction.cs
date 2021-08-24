using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Events;

[System.Serializable]
public class UnityTaskAction : UnityEvent<List<Task>>
{
    public async Task TaskInvoke()
    {
        var tasks = new List<Task>();
        Invoke(tasks);
        await Task.WhenAll(tasks);
    }
}
