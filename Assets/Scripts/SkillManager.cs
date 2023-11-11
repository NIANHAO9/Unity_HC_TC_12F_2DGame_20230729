﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;                      // 排序、條件設定
using System.Collections;
using System.Collections.Generic;       // 清單 List 資料結構 相對於陣列彈性

public class SkillManager : MonoBehaviour
{
    [SerializeField, Header("隨機技能面板")]
    private CanvasGroup groupSkill;
    [SerializeField, Header("按鈕技能物件 1 ~ 3")]
    private Transform[] objectSkill;
    [SerializeField, Header("全部的技能資料")]
    private DataSkill[] dataSkills;

    [SerializeField]
    private List<DataSkill> randomSkills = new List<DataSkill>();

    [SerializeField, Header("按鈕技能 1 ~ 3")]
    private Button[] btnSkill;

    private void Awake()
    {
        for (int i = 0; i < btnSkill.Length; i++)
        {
            btnSkill[i].onClick.AddListener(() => { print("按下按鈕"); });
        }
    }

    /// <summary>
    /// 升級後顯示技能介面
    /// </summary>
    public void LevelUpShowSkillUI()
    {
        Time.timeScale = 0;
        RandomSkill();
        StartCoroutine(FadeInSkillUI());
    }

    /// <summary>
    /// 淡入技能介面
    /// </summary>
    private IEnumerator FadeInSkillUI()
    {
        for (int i = 0; i < 10; i++)
        {
            groupSkill.alpha += 0.1f;
            yield return new WaitForSecondsRealtime(0.035f);
        }

        groupSkill.interactable = true;
        groupSkill.blocksRaycasts = true;
    }

    private void RandomSkill()
    {
        randomSkills = dataSkills.Where(x => x.lv < 5).ToList();                        // 從 dataSkills 全部技能 拿出所有 等級 小於 5 的資料
        randomSkills = randomSkills.OrderBy(x => Random.Range(0, 999)).ToList();        // 將技能資料隨機排序

        UpdateSKillUI();
    }

    private void UpdateSKillUI()
    {
        for (int i = 0; i < objectSkill.Length; i++)
        {
            DataSkill dataSkill = randomSkills[i];
            objectSkill[i].Find("技能名稱").GetComponent<TextMeshProUGUI>().text = dataSkill.skillName;
            objectSkill[i].Find("技能描述").GetComponent<TextMeshProUGUI>().text = dataSkill.skillDescription;
            objectSkill[i].Find("技能圖片").GetComponent<Image>().sprite = dataSkill.skillPicture;

            for (int j = 0; j < dataSkill.lv; j++)
            {
                Color colorStar = objectSkill[i].Find("星星群組/星星 " + (j + 1)).GetComponent<Image>().color;
                colorStar.a = 1;
                objectSkill[i].Find("星星群組/星星 " + (j + 1)).GetComponent<Image>().color = colorStar;
            }
        }
    }
}
