using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFrame {

	public enum WindowType {
		Window,		// 主窗口，同一时刻，最多拥有一个，位于UI栈的最下层
		Dialog,		// 弹窗，附属于主窗口，当主窗口销毁时，也跟着销毁
	}

	public class WindowInfo {
		public string       name;
		public System.Type  type;
		public string       path;
        public WindowType   windowType;
	}

    public class UIManager : SingletonComp<UIManager> {
        private static Dictionary<string, WindowInfo> windows = new Dictionary<string, WindowInfo>();

        public RectTransform contentTrans;


        // 注册窗口
        public void RegisterWindow(string name, System.Type type, string path, WindowType windowType){

        }

        // 打开窗口
        public void OpenWindow(string name) {

        }


        public void Dump(){
            
        }
    }
}

