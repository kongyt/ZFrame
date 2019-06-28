using UnityEngine;

namespace ZFrame {
    public class BaseWindowView : BaseView {
        private const string OPEN_ANIM_KEY_WORD = "appear";
        private const string CLOSE_ANIM_KEY_WORD = "disappear";

        public bool InitAnimation(out string openAnimName, out string closeAnimName){
            openAnimName = "";
            closeAnimName = "";

            var anims = GetComponent<Animation>();

            if (anims == null)
            {
                return false;
            }

            foreach (AnimationState anim in anims)
            {
                Debug.Log(anim.name);
                if (anim.name.EndsWith(CLOSE_ANIM_KEY_WORD))
                {
                    closeAnimName = anim.name;
                }
                else if (anim.name.EndsWith(OPEN_ANIM_KEY_WORD))
                {
                    openAnimName = anim.name;
                }
            }

            if (openAnimName == "" && closeAnimName == "")
            {
                Debug.LogWarningFormat("[WindowView]{0} 缺少动画 0-appear，1-disappear", name);
                return false;
            }

            return true;
        }
    }

}
