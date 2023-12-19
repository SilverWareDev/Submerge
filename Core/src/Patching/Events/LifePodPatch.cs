using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(EscapePod))]
public static class LifePodPatch
{
    [HarmonyPostfix]
    [HarmonyPatch("Awake")]
    public static void Postfix(EscapePod __instance)
    {
        Vector3 position = __instance.transform.position;
        Quaternion rotation = __instance.transform.rotation;
        if (EscapePod.main != null)
        {
            EscapePod.main.transform.position = position;
            EscapePod.main.transform.rotation = rotation;
        }
    }
}