using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTestScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.GameTestScene;
        Managers.Sound.Play("MainGameBGM",Define.Sound.Bgm);

        //Managers.UI.ShowSceneUI<UI_Inven>();
        //Dictionary<int, Stat> dict = Managers.Data.StatDict;
    }

    public override void Clear()
    {
        Debug.Log("GameTestScene Clear!");
    }
}
