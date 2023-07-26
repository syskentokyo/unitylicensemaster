using System.Linq;
using UnityEditor;

namespace SyskenTLib.LicenseMasterEditor
{
    public class OutputTemplateFileManager
    {
        public OutputTemplate SearchOutputTemplate()
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
    }
}