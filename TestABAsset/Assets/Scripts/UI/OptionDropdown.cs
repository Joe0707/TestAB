using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

//该脚本用于创建不可选择的dropdownList
public class OptionDropdown : Dropdown
{
    protected List<DropdownItem> itemoptions = new List<DropdownItem>();
    static List<int> UnclickOptionNum = new List<int>();
    protected override DropdownItem CreateItem(DropdownItem itemTemplate)
    {
        var item = base.CreateItem(itemTemplate);
        itemoptions.Add(item);
        for (int i = 0; i < UnclickOptionNum.Count; i++)
        {
            if (itemoptions.Count == UnclickOptionNum[i])
            {
                item.GetComponent<Toggle>().interactable = false;
            }
        }

        return item;
    }

    //关闭选项（销毁Item）时清空list
    protected override void DestroyItem(DropdownItem item)
    {
        if (itemoptions.Count != 0)
        {
            itemoptions.Clear();
        }
    }

    //不可选择选项索引的list
    public static void UnclickOption(List<int> unclicklist)
    {
        UnclickOptionNum.Clear();
        UnclickOptionNum = unclicklist;
    }

}