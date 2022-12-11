using System.Reflection;
using HarmonyLib;
using QSB.Messaging;

namespace QSBAddonUtils;

[HarmonyPatch]
internal class Patches
{
	internal static void Patch()
	{
		Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
	}

	[HarmonyPrefix]
	[HarmonyPatch(typeof(QSBMessage), nameof(QSBMessage.OnReceiveRemote))]
	private static void QSBMessageOnReceiveRemotePrefix(QSBMessage __instance)
	{
		QSBMessageSubscriptionManager.InvokeSubscribers(__instance, MessageInvokeCondition.OnReceiveRemote);
	}

	[HarmonyPrefix]
	[HarmonyPatch(typeof(QSBMessage), nameof(QSBMessage.OnReceiveLocal))]
	private static void QSBMessageOnReceiveLocalPrefix(QSBMessage __instance)
	{
		QSBMessageSubscriptionManager.InvokeSubscribers(__instance, MessageInvokeCondition.OnReceiveLocal);
	}
}
