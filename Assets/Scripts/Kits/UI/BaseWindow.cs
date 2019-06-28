using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFrame {
    public class BaseWindow : BaseComponent, IViewController{
        public WindowInfo info;

        private BaseWindowView view;

        public void SetView(BaseView view){
            this.view = view as BaseWindowView;
        }

        public virtual void OnPush(bool immediately, System.Action onComplete) {
            if(immediately){
                SafeCall(onComplete);
            }else{
                float time = DoAppearAnim();
                this.ScheduleOnce(time, onComplete);
            }
        }

        public virtual void OnPop(bool immediately, System.Action onComplete) {
            if(immediately){
                SafeCall(onComplete);
            }else{
                float time = DoDisappearAnim();
                this.ScheduleOnce(time, onComplete);
            }
        }

        public virtual float DoAppearAnim(){
            return 0;
        }

        public virtual float DoDisappearAnim(){
            return 0;
        }

    }
}


