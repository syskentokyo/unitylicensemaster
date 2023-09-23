using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SyskenTLib.LicenseMaster;
using Unity.Plastic.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

namespace SyskenTLib.LicenseMasterEditor
{
    public class OutputFileFormatManager
    {
        
        private OutputTemplate SearchOutputTemplate()
        {
            OutputTemplateFileManager fileTemplateManager = new OutputTemplateFileManager();

            return fileTemplateManager.SearchOutputTemplate();
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
        
     
        public string GenerateMARKDOWNDetailListForUseGit(List<LicenseConfig> configList)
        {
            OutputTemplate outputTemplate = SearchOutputTemplate();
            string resultText = "";

            //タイトルとスペシャルサンクス
            resultText += "このUnityプロジェクトが利用しているライブラリ一覧(詳細)です。"+"\n";
            resultText += "\n\n更新日時："+DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss") +"\n";
            

            configList.ForEach(config =>
            {
                //境界
                resultText += "\n\n"+outputTemplate._markdownLibSpaceText.Replace(outputTemplate._replaceTargetTextDefine,"");
                
                //ライブラリ名
                resultText += "\n"+outputTemplate._markdownLibTitleText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLibrayName);

                resultText += "\n" + "### メモ１：" + "\n";
                resultText += "\n```\n" + "" + config.GetMemo1+"\n```\n\n\n";
                
                resultText += "\n* " + "追加日：" + config.GetCreatedTimeText;
                resultText += "\n* " + "ライセンス：" + config.GetLicenseType;
                resultText += "\n* " + "料金タイプ：" + config.GetChargeType;
                resultText += "\n* " + "ライセンス表記が必要？：" + config.GetIsMustShowLicense;
                resultText += "\n\n\n* " + "バージョン：" + config.GetLibVersion;
                resultText += "\n\n\n* " + "WebURL1：" + config.GetWebURL1;
                resultText += "\n* " + "WebURL2：" + config.GetWebURL2;
                
                resultText += "\n* " + "使用しているライブラリ";
                config.GetUseLicenseList.ForEach(useLibConfig =>
                {
                    if (useLibConfig != null)
                    {
                        resultText += "\n  * " + "" + useLibConfig.GetLibrayName;
                    }
                });
                
                resultText += "\n\n\n* " + "カスタム１：" + config.GetCustomText1;
                resultText += "\n* " + "カスタム2：" + config.GetCustomText2;

                //ライセンス表示内容
                resultText += "\n\n### ライセンス表記内容：\n\n"+outputTemplate._markdownLibContentText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLicenseShowText);


                resultText += "\n\n"
                              +"---------------------------------------\n"
                              +"---------------------------------------\n"
                              +"---------------------------------------\n";
                
            });
            
            //境界
            resultText += "\n\n"+outputTemplate._markdownLibSpaceText.Replace(outputTemplate._replaceTargetTextDefine,"");
            
            //ファイルの最後
            resultText += "\n"+outputTemplate._markdownBottomTemplateText.Replace(outputTemplate._replaceTargetTextDefine,"");

            
            return resultText;
        }
        
        
        public string GenerateMARKDOWNSimpleListForUseGit(List<LicenseConfig> configList)
        {
            OutputTemplate outputTemplate = SearchOutputTemplate();
            string resultText = "";

            //タイトルとスペシャルサンクス
            resultText += "このUnityプロジェクトが利用しているライブラリ一覧です。"+"\n";
            resultText += "\n\n更新日時："+DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss") +"\n";
            
            
            resultText += "\n" + "| Name  | License Type | Charge Type | URL1 | URL2 | Memo1 | Use Lib | Add Date |" + "\n";
            resultText += "" + "| -------------  | ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | ------------- |" + "\n";

            
            configList.ForEach(config =>
            {
                string validMemo1 = config.GetMemo1.Replace("\n", "<br>");
                
                string useLibTxt = "";
                config.GetUseLicenseList.ForEach(useLibConfig =>
                {
                    if (useLibConfig != null)
                    {
                        useLibTxt += "" + "" + useLibConfig.GetLibrayName + "<br>";
                    }
                });
                
                
                resultText += "" 
                              + "| "+config.GetLibrayName+ " "
                              + "| "+config.GetLicenseType+ " "
                              + "| "+config.GetChargeType+ " "
                              + "| "+config.GetWebURL1+ " "
                              + "| "+config.GetWebURL2+ " "
                              + "| "+validMemo1+ " "
                              
                              + "| "+useLibTxt+ " "
                              
                              + "| "+config.GetCreatedTimeText+ " "
                              + "|"
                              + "\n";
                
            });
            
            
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