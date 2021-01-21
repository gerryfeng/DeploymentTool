using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConfigBridge
{
    public class Utility
    {
        public static void ToolSaveFile(string filePath, string cityTempSolutionPath)
        {
            try
            {
                filePath = filePath.Replace("/", "\\");

                if (!File.Exists(filePath))
                    return;

                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();

                string functionName = st.GetFrame(1).GetMethod().Name;

                string dirPath = cityTempSolutionPath + @"\OMSFileBackUp\";
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);

                string guid = Guid.NewGuid().ToString();

                File.Copy(filePath, dirPath + guid, true);

                List<SaveFileIndexItem> index = new List<SaveFileIndexItem>();
                string indexFilePath = cityTempSolutionPath + @"\OMSFileBackUp\index.txt";
                if (File.Exists(indexFilePath))
                {
                    index = JsonConvert.DeserializeObject<List<SaveFileIndexItem>>(File.ReadAllText(indexFilePath));
                }

                SaveFileIndexItem item = new SaveFileIndexItem();
                if (index.Count > 0)
                    item.ID = index.Last().ID + 1;
                else
                    item.ID = 1;
                item.saveTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                item.functionName = functionName;
                item.filePath = filePath;
                item.fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                item.guid = guid;

                index.Add(item);

                while (index.Count > 1000)
                {
                    File.Delete(dirPath + index[0].guid);

                    index.RemoveAt(0);
                }

                File.WriteAllText(indexFilePath, JsonConvert.SerializeObject(index, Newtonsoft.Json.Formatting.Indented));
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
