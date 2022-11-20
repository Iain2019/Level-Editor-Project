using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CT4027___Tools___Level_Editor_Project{ 
    class SaverLoader{
        public void Save(List<LevelGridData> data, string path){
            string jsonData = JsonConvert.SerializeObject(data);

            System.IO.File.WriteAllText(path, jsonData);
        }

        public List<LevelGridData> Load(string path){
            string jsonData = System.IO.File.ReadAllText(path);

            List<LevelGridData> data = JsonConvert.DeserializeObject<List<LevelGridData>>(jsonData);

            return data;
        }
    }
}
