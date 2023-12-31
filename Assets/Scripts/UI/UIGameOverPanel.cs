using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace ProjectSurvivor
{
	public class UIGameOverPanelData : UIPanelData
	{
	}
	public partial class UIGameOverPanel : UIPanel
	{

		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGameOverPanelData ?? new UIGameOverPanelData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			ActionKit.OnUpdate.Register(() =>
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					this.CloseSelf();
					SceneManager.LoadScene("SampleScene");
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
