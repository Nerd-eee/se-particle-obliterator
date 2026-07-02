using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using Sandbox.Game.Multiplayer;
using VRage.Game;
using VRageMath;

namespace ClientPlugin.Patches;

// ReSharper disable once UnusedType.Global
[HarmonyPatch(typeof(MyParticlesManager), "CreateParticleEffect")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class MyParticlesManagerPatch
{
    private static Config Config => Config.Current;

    public static bool Prefix(ref MyParticleEffect __result, string name, ref MatrixD effectMatrix, ref Vector3D worldPosition, uint parentID, bool userDraw = false, int keepXFramesAhead = 0)
    {
        if (!Config.Enable)
            return true;

        __result = null;
        return false;
    }
}
