using UnityEngine;

namespace SyskenTLib.LicenseMasterEditor
{
    public class OutputTemplate : ScriptableObject
    {
        [Header("共通")] [SerializeField] public string _specialThanksMessage = "Thanks for the useful library";
        
        [Header("HTML")]         [TextArea(minLines:4,maxLines:100)][SerializeField] public string _htmlTopTemplateText = "";
        [SerializeField] public string _htmlLibTitleText = "";
        [SerializeField] public string _htmlLibSpaceText = "";
        [TextArea(minLines:4,maxLines:100)] [SerializeField] public string _htmlLibContentText = "";
        [TextArea(minLines:4,maxLines:100)] [SerializeField] public string _htmlBottomTemplateText = "";
        
        
        [Header("Markdown")]        [TextArea(minLines:4,maxLines:100)] [SerializeField] public string _markdownTopTemplateText = "";
        [SerializeField] public string _markdownLibTitleText = "## ";
        [SerializeField] public string _markdownLibSpaceText = "";
        [TextArea(minLines:4,maxLines:100)][SerializeField] public string _markdownLibContentText = "";
        [TextArea(minLines:4,maxLines:100)][SerializeField] public string _markdownBottomTemplateText = "";
        
        [Header("RawTxt")]        [TextArea(minLines:4,maxLines:100)] [SerializeField] public string _rawTxtTopTemplateText = "";
        [SerializeField] public string _rawTxtLibTitleText = "";
        [SerializeField] public string _rawTxtLibSpaceText = "";
        [TextArea(minLines:4,maxLines:100)][SerializeField] public string _rawTxtLibContentText = "";
        [TextArea(minLines:4,maxLines:100)][SerializeField] public string _rawTxtBottomTemplateText = "";


        [Header("置換用設定")] public string _replaceTargetTextDefine = "41162zf25871bb0";
        
    }
}