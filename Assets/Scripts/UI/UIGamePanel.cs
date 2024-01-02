using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace ProjectSurvivor
{
	public class UIGamePanelData : UIPanelData
	{
	}
	public partial class UIGamePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePanelData ?? new UIGamePanelData();
			// please add init code here
			Global.Exp.RegisterWithInitValue(exp =>
			{
				ExpText.text = "经验值:" + exp;
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			Global.Level.RegisterWithInitValue(level =>
			{
				LevelText.text = "等级:" + level;
				
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			Global.Level.Register(level =>
			{
				Time.timeScale = 0;
				BtnUpgrade.Show();
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			Global.Exp.RegisterWithInitValue(exp =>
			{
				if (exp>=5)
				{
					Global.Exp.Value -= 5;
					Global.Level.Value++;
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);


			BtnUpgrade.Hide();
		BtnUpgrade.onClick.AddListener(()=>
		{
			Time.timeScale = 1;
			BtnUpgrade.Hide();
		});	
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
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
