using System;
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
        
        public string GenerateMARKDOWNForUseApp(List<LicenseConfig> configList)
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
        
     
        public string GenerateMARKDOWNForUseGit(List<LicenseConfig> configList)
        {
            OutputTemplate outputTemplate = SearchOutputTemplate();
            string resultText = "";

            //タイトルとスペシャルサンクス
            resultText += "このUnityプロジェクトが利用しているライブラリ一覧です。"+"\n";
            resultText += "\n\n更新日時："+DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss") +"\n";
            

            configList.ForEach(config =>
            {
                //境界
                resultText += "\n\n"+outputTemplate._markdownLibSpaceText.Replace(outputTemplate._replaceTargetTextDefine,"");
                
                //ライブラリ名
                resultText += "\n"+outputTemplate._markdownLibTitleText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLibrayName);

                resultText += "\n" + "* メモ１：" + "\n";
                resultText += "\n```\n" + "" + config.GetMemo1+"\n```\n\n\n";
                
                resultText += "\n* " + "追加日：" + config.GetCreatedTimeText;
                resultText += "\n* " + "ライセンス：" + config.GetLicenseType;
                resultText += "\n* " + "ライセンス表記が必要？：" + config.GetIsMustShowLicense;

                //ライセンス表示内容
                resultText += "\n\n"+outputTemplate._markdownLibContentText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLicenseShowText);


                resultText += "\n\n";
            });
            
            //境界
            resultText += "\n\n"+outputTemplate._markdownLibSpaceText.Replace(outputTemplate._replaceTargetTextDefine,"");
            
            //ファイルの最後
            resultText += "\n"+outputTemplate._markdownBottomTemplateText.Replace(outputTemplate._replaceTargetTextDefine,"");

            
            return resultText;
        }
        
        public string GenerateRawTxtForUseApp(List<LicenseConfig> configList)
        {
            OutputTemplate outputTemplate = SearchOutputTemplate();
            string resultText = "";

            //タイトルとスペシャルサンクス
            resultText += outputTemplate._rawTxtTopTemplateText.Replace(outputTemplate._replaceTargetTextDefine,outputTemplate._specialThanksMessage)+"\n";
            

            configList.ForEach(config =>
            {
                //境界
                resultText += "\n\n"+outputTemplate._rawTxtLibSpaceText.Replace(outputTemplate._replaceTargetTextDefine,"");
                
                //ライブラリ名
                resultText += "\n"+outputTemplate._rawTxtLibTitleText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLibrayName);

                //ライセンス表示内容
                resultText += "\n\n"+outputTemplate._rawTxtLibContentText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLicenseShowText);
                
                
            });
            
            //境界
            resultText += "\n\n"+outputTemplate._rawTxtLibSpaceText.Replace(outputTemplate._replaceTargetTextDefine,"");
            
            //ファイルの最後
            resultText += "\n"+outputTemplate._rawTxtBottomTemplateText.Replace(outputTemplate._replaceTargetTextDefine,"");

            
            return resultText;
        }
        
    }
}