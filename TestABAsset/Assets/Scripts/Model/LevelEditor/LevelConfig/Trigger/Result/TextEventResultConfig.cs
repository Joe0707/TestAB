namespace Levels.Trigger
{
    public enum ETextType
    {
        Narratage = 0,  //旁白
        Tip = 1,  //提示
        Dialog = 2   //对话
    }
    //文字事件配置
    public class TextEventResultConfig : ResultConfig
    {
        public const string Name = "文字事件";
        public string StringId;//文字表ID
        // public ETextType TextType;//文字事件类型
        public override string GetName { get { return TextEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
            // throw new System.NotImplementedException();
        }

        public override ResultConfig Clone()
        {
            var result = new TextEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.StringId = this.StringId;
            // result.TextType = this.TextType;
            result.TriggerId = this.TriggerId;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is TextEventResultConfig)
            {
                var sourceconfig = source as TextEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.StringId = sourceconfig.StringId;
                // this.TextType = sourceconfig.TextType;
                this.TriggerId = sourceconfig.TriggerId;
            }
        }

    }

}