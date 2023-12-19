using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(Player))]
public static class PlayerRepPatch
{
    [HarmonyPostfix]
    [HarmonyPatch("Update")]
    public static void Postfix(Player __instance, ref Vector3 ___Position, ref Quaternion ___Rotation)
    {
        ___Position = __instance.transform.position;
        ___Rotation = __instance.transform.rotation;
    }
}