using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFrame;

public class MainMenuWindow : BaseWindow, IViewController {
	private MainMenuView view;

	public void SetView(BaseView v){
		view = v as MainMenuView;
		view.startButton.onClick.AddListener(OnClickStartButton);
		view.optionButton.onClick.AddListener(OnClickOptionButton);
		view.exitButton.onClick.AddListener(OnClickExitButton);		
	}

	private void OnClickStartButton(){

	}

	private void OnClickOptionButton(){

	}

	private void OnClickExitButton(){

	}

}
