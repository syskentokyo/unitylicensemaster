using System.Collections.Generic;
using System.Linq;
using SyskenTLib.LicenseMaster;
using UnityEditor;
using UnityEngine;

namespace SyskenTLib.LicenseMasterEditor
{
    public class OutputFileFormatManager
    {
        
        private OutputTemplate SearchOutputTemplate()
        {
            string[] guids = AssetDatabase.FindAssets("t:OutputTemplate");
            OutputTemplate outputTemplate = null; 
            
            guids.ToList().ForEach(nextGUID =>
            {
                string filePath = AssetDatabase.GUIDToAssetPath(nextGUID);
                outputTemplate= AssetDatabase.LoadAssetAtPath<OutputTemplate> (filePath);
                
            });
            
            return outputTemplate;
        }

        public string GenerateHTML(List<LicenseConfig> configList)
        {
            OutputTemplate outputTemplate = SearchOutputTemplate();
            string resultText = "";

            //タイトルとスペシャルサンクス
            resultText += outputTemplate._htmlTopTemplateText.Replace(outputTemplate._replaceTargetTextDefine,outputTemplate._specialThanksMessage)+"\n";
            

            configList.ForEach(config =>
            {
                //境界
                resultText += "\n\n"+outputTemplate._htmlLibSpaceText.Replace(outputTemplate._replaceTargetTextDefine,"");
                
                //ライブラリ名
                resultText += "\n"+outputTemplate._htmlLibTitleText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLibrayName);

                //ライセンス表示内容
                resultText += "\n\n"+outputTemplate._htmlLibContentText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLicenseShowText);
                
            });
            
                            
            //境界
            resultText += "\n\n"+outputTemplate._htmlLibSpaceText.Replace(outputTemplate._replaceTargetTextDefine,"");
            
            //ファイルの最後
            resultText += "\n"+outputTemplate._htmlBottomTemplateText.Replace(outputTemplate._replaceTargetTextDefine,"");

            
            return resultText;
        }
        
        public string GenerateMARKDOWN(List<LicenseConfig> configList)
        {
            OutputTemplate outputTemplate = SearchOutputTemplate();
            string resultText = "";

            //タイトルとスペシャルサンクス
            resultText += outputTemplate._markdownTopTemplateText.Replace(outputTemplate._replaceTargetTextDefine,outputTemplate._specialThanksMessage)+"\n";
            

            configList.ForEach(config =>
            {
                //境界
                resultText += "\n\n"+outputTemplate._markdownLibSpaceText.Replace(outputTemplate._replaceTargetTextDefine,"");
                
                //ライブラリ名
                resultText += "\n"+outputTemplate._markdownLibTitleText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLibrayName);

                //ライセンス表示内容
                resultText += "\n\n"+outputTemplate._markdownLibContentText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLicenseShowText);
                
                
            });
            
            //境界
            resultText += "\n\n"+outputTemplate._markdownLibSpaceText.Replace(outputTemplate._replaceTargetTextDefine,"");
            
            //ファイルの最後
            resultText += "\n"+outputTemplate._markdownBottomTemplateText.Replace(outputTemplate._replaceTargetTextDefine,"");

            
            return resultText;
        }
        
        
    }
}