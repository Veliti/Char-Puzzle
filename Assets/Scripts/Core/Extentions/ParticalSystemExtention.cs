using System.Threading.Tasks;
using UnityEngine;

public static class ParticalSystemExtention
{
    public static async Task AsyncWaitForCompletion(this ParticleSystem particleSystem)
    {
        while(particleSystem && particleSystem.IsAlive())
        {
            await Task.Yield();
        }
    }
}
