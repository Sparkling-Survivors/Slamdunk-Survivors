using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameStart : UI_Popup
{
    enum Buttons
    {
        StartButton
    }

    /*enum Texts
    {
        PointText,
        ScoreText,
    }

    enum GameObjects
    {
        TestObject,
    }

    enum Images
    {
        ItemIcon,
    }*/

    private void Start()
    {
        Init();
        Managers.Sound.Play("StartBGM",Define.Sound.Bgm);
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
		/*Bind<Text>(typeof(Texts));
		Bind<GameObject>(typeof(GameObjects));
		Bind<Image>(typeof(Images));*/

		GetButton((int)Buttons.StartButton).gameObject.BindEvent(OnButtonClicked);

		/*GameObject go = GetImage((int)Images.ItemIcon).gameObject;
		BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);*/
	}

    public void OnButtonClicked(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.GameTestScene);
    }

}
