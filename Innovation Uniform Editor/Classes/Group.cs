using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes
{
    public class Group : MenuItem
    {
        [JsonIgnore]
        public List<Custom> Customs;

        public List<Guid> CustomGuids  //Not used here, only for saving or loading purposes.
        {
            get
            {
                List<Guid> customGuids = new List<Guid>();
                foreach (Custom custom in Customs)
                {
                    customGuids.Add(custom.Guid);
                }
                _customGuids = customGuids;
                return customGuids;
            }
            set
            {
                _customGuids = value;
                foreach (Guid custom in value)
                {
                    Customs.Add(JSONtoUniform.FindCustomFromGuid(custom));
                }
            }
        }

        private List<Guid> _customGuids;

        public void RemoveFromGroup(Guid guid)
        {
            int index = Customs.FindIndex((element) => element.Guid == guid);
            if (index != -1)
            {
                Customs.RemoveAt(index);
            }
        }

        public void AddToGroup(Custom custom)
        {
            Customs.Add(custom);
            //Save to file. (JSONtoUniform?)
        }
        public MenuItem FindInGroupFromGuid(Guid guid)
        {
            return Customs.Find((element) =>
            {
                return element.Guid == guid;
            });
        }
    }
}
