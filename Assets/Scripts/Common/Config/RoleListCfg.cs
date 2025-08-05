
    using System.Collections.Generic;

    public class RoleListItem
    {
        public int id;
        public int unlockId;
        public string name;
        public string path;
        public long sellingPrice;
        public string des;
        public int roleType;
    }

    public class RoleListCfg : ConfigBase<List<RoleListItem>>
    {
        protected override string Path => "RoleListCfg";

        public override void Init()
        {
            defaultValue = "[]";
            base.Init();
            DebugEr.Log($"{_data.Count}");
        }
    }
