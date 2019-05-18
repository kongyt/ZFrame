using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZWindowBase : ZComponentBase {

    protected ZViewBase view;

    public virtual void SetView(ZViewBase view) {
        this.view = view;
    }

    public virtual void OnShow() {

    }

    public virtual void OnClose() {

    }

}
