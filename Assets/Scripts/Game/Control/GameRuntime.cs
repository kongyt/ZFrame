using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuntime : ZGameRuntime {

    protected override void InitAllLogic() {
        AddLogic<GameLogic>();
    }
}
