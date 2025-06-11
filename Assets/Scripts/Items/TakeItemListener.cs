public class TakeItemListener : AbsItemListener
{

	protected override void OnButtonClicked(int id)
	{
		if (id == this.id)
		{
			EventSystem.Instance.TakeItem(id);
		}
	}
}
