using OWML.Common;
using OWML.ModHelper;
using QSB.Messaging;

namespace QSBAddonUtils;

public class QSBAddonUtils : ModBehaviour
{
	private void Awake() => Patches.Patch();

	private void Start() => ModHelper.Console.WriteLine($"{nameof(QSBAddonUtils)} is loaded!", MessageType.Success);

	/// <summary> Subscribe to an message type. Use this version if you don't need to unsubscribe with a hash. </summary>
	public static void Subscribe<M>(MessageInvokeCondition msgInvokeCondition, System.Action<M> action) where M : QSBMessage =>
		Subscribe<M>(QSBMessageSubscriptionManager.EmptyHashCode, msgInvokeCondition, action);

	/// <summary> Subscribe to an message type. The objHash will be used to retrieve the action if you need to unsubscribe. </summary>
	public static void Subscribe<M>(int objHash, MessageInvokeCondition msgInvokeCondition, System.Action<M> action) where M : QSBMessage =>
		QSBMessageSubscriptionManager.Subscribe<M>(objHash, msgInvokeCondition, action);

	public static void Unsubscribe<M>(int objHash, MessageInvokeCondition msgInvokeCondition) where M : QSBMessage =>
		QSBMessageSubscriptionManager.Unsubscribe<M>(objHash, msgInvokeCondition);
}