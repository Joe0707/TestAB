
public enum SexType
{
    m,
    f
}

// //血脉类型 使用全局定义的枚举
// public enum DescentType
// {
//     // none = -1,   //没有类型
//     heerwo = 0,//赫尔沃
//     suolesi = 1//索勒斯
// }

//部件物体类型 按照层级排序 从前到后
public enum EPartObjType
{
    clothes_a,
    hair_a,
    hair_b,
    stigma,
    beard,
    bigbeard,
    hair_c,
    ear_a,
    ear_b,
    hair_d,
    eyebrow,
    wrinkle_a,
    wrinkle_b,
    wrinkle_c,
    nose,
    eye,
    mouth,
    tattoo,
    face,
    ear_c,
    clothes_b,
    hair_e,
    clothes_c,
    body,
    clothes_d,
    hair_f,
}
//血脉影响部件
public enum EDescentPartType
{
    ear,    //耳朵
    eyebrow,//眉毛
    eye,    //眼
    nose,   //鼻子
    mouth,  //嘴
    face,   //脸
    stigma, //圣痕
    skincolor,//皮肤颜色
    haircolor//头发颜色
}

//部件类型 选择部件的大类型
public enum EPartType
{
    hair,   //头发
    ear,    //耳朵
    eyebrow,//眉毛
    eye,    //眼
    nose,   //鼻子
    beard,  //胡子
    mouth,  //嘴
    tattoo, //纹身
    face,   //脸
    clothes,//衣服
    body,    //身体
    scar,    //伤疤
    stigma, //圣痕
    bigbeard  //大胡子
}
//部件颜色类型
public enum EColorPartType
{
    skincolor,//肤色
    haircolor,//发色
    eyebrowcolor,//眉毛颜色
    beardcolor//胡子颜色
}
//配表定义的部件颜色类型
public enum EDefineColorPartType
{
    skin_color,//肤色
    hair_color,//头发颜色
    eyebrow_color,//眉毛颜色
    beard_color//胡子颜色
}

//颜色类型
public enum EColorType
{
    skincolor,  //肤色
    haircolor   //发色
}

/**血脉类型 */
public enum DescentType
{
    /**赫尔沃 */
    heerwo = 1,
    /**索勒斯 */
    suolesi = 2,
    /**赫拉西诺*/
    helaxinuo = 3,
    /**巴拉赞*/
    balazan = 4,
    /**金尼斯暗裔*/
    jinnisi = 5,
    /**雪山遗民*/
    xueshan = 6,
    /**福瑞莫得精灵*/
    jingling = 7,
    /**沃尔家的卓越之子*/
    gaojishouren = 8,
    /**欧塔鲁特贵族*/
    gaojiheiren = 9,
    /**科尼托后裔*/
    gaojikaierte = 10,
    /**艾德勒斯移民*/
    gaojixibanya = 11,
    /**爱斐勒姆*/
    gaojimenggu = 12,
    /**日出之子*/
    riben = 13,
    /**可你托人*/
    kaierte = 14,
    /**我而家的人*/
    shouren = 15,
    /**爱得乐人*/
    xibanya = 16,
    /**爱妃了多人*/
    menggu = 17,
    /**普瑞怕恩人*/
    pingmin = 18,
    /**欧塔路特人*/
    heiren = 19
}
