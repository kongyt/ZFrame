using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFrame;

public class UIDefine {

	private static readonly string PATH_PREFIX = "Windows/";

	public static void Init(){		
		// 注册所有窗口
		DefineWindow<MainMenuWindow>("Main_Menu_Window", WindowType.Window);
	}

	public static void DefineWindow<T>(string name, WindowType windowType){
		UIManager.Instance.RegisterWindow(name, typeof(T), PATH_PREFIX + name, windowType);
	}

}