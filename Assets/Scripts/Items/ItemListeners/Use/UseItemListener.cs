public class UseItemListener : AbsItemListener
{
	[UnityEngine.SerializeField] protected ItemData data;
	protected override void OnButtonClicked(int id)
	{
		if (id == this.id)
		{
			bool result = EventSystem.Instance.UseItemInInventory(data);
			EventSystem.Instance.ItemSuccessfullyUsed(id, result);

		}
	}
}



