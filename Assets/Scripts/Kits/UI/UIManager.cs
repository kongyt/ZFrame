using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        public bool         releaseRes;
	}

    public class UIManager : SingletonComp<UIManager> {
        private Dictionary<string, Object> resMap = new Dictionary<string, Object>();
        private Dictionary<string, WindowInfo> windowsInfo = new Dictionary<string, WindowInfo>();

        private List<BaseWindow> windows = new List<BaseWindow>();

        public RectTransform contentTrans;
        public Image mask;


        // 注册窗口
        public void RegisterWindow(string name, System.Type type, string path, WindowType windowType, bool releaseRes = false){
            WindowInfo info = new WindowInfo();
            info.name = name;
            info.type = type;
            info.path = path;
            info.windowType = windowType;
            info.releaseRes = releaseRes;
            windowsInfo.Add(name, info);
        }

        // 打开窗口
        public void PushWindow(string name, bool immediately = false, System.Action onComplete = null) {
            WindowInfo info = null;
            if(windowsInfo.TryGetValue(name, out info)){
                if(info.windowType == WindowType.Window){
                    ShowMask(0.3f, ()=>{
                        ClearWindows();
                        BaseWindow window = LoadWindow(info);
                        AddWindow(window);
                        HideMask(0.3f, null);
                    }); 
                }else{
                    BaseWindow window = LoadWindow(info);
                    AddWindow(window);
                }

            }else{
                Debug.LogError("Can't find window: " + name);
            }
        }

        public void PopWindow(bool immediately, System.Action onComplete){
            int index = windows.Count - 1;
            if(index >= 0){
                BaseWindow window = windows[index];
                windows.Remove(window);
                window.OnPop(immediately, ()=>{
                    DestroyWindow(window); 
                    SafeCall(onComplete);
                });
            }else{
                SafeCall(onComplete);
            }
        }

        private void ClearWindows(){
            while(windows.Count > 0){
                PopWindow(true, null);
            }
        }

        public void DestroyWindow(BaseWindow window){
            WindowInfo info = window.info;

            GameObject.DestroyImmediate(window.gameObject);
            if(info.releaseRes){
                Object res = null;
                if(resMap.TryGetValue(info.name, out res)){
                    Resources.UnloadAsset(res);
                }
            }
        }

        private void AddWindow(BaseWindow window){
            this.windows.Add(window);
            window.OnPush(false, null);
        }

        private BaseWindow LoadWindow(WindowInfo info){
            Object res = null;
            if(resMap.TryGetValue(info.path, out res) == false){
                res = Resources.Load(info.path);
                resMap.Add(info.name, res);
            }
            GameObject windowObj = GameObject.Instantiate(res, Vector3.zero, Quaternion.identity, contentTrans) as GameObject;
            BaseWindow window = (BaseWindow)GameUtils.GetOrAddComponent(windowObj, info.type);
            window.info = info;
            BaseWindowView view = (BaseWindowView)windowObj.GetComponent<BaseWindowView>();
            window.SetView(windowObj.GetComponent<BaseWindowView>());            
            return window;            
        }

        public void ShowMask(float duration, System.Action onComplete){
            mask.gameObject.SetActive(true);
            mask.color = new Color(0, 0, 0, 0);
            mask.DOFade(1, duration).OnComplete(()=>{
                SafeCall(onComplete);
            });
        }

        public void HideMask(float duration, System.Action onComplete){
            mask.gameObject.SetActive(true);
            mask.color = new Color(0, 0, 0, 1);
            mask.DOFade(0, duration).OnComplete(()=>{
                mask.gameObject.SetActive(false);
                SafeCall(onComplete);

            });
        }

        public void Dump(){
            
        }
    }
}

