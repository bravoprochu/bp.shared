using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bp.shared.DTO
{

    public interface IModificationInfo {
        string Modifications { get; set; }
    }

    public class Modification: IModificationInfo
    {
        public string Modifications { get; set; }
        //public string Modifications { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


    public class ModificationInfoDTO: IModificationInfo
    {
        public List<ModificationDTO> ModificationsList
        {
            get
            {
                var res = new List<ModificationDTO>();
                if (!string.IsNullOrWhiteSpace(this.Modifications))
                {
                    var modArr = this.Modifications.Split(ModificationSeparators.GetModificationListSeparationRowSign, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var mod in modArr)
                    {
                        if (!string.IsNullOrWhiteSpace(mod))
                        {
                            var splitedInfo = mod.Split(ModificationSeparators.GetModificationInfoSeparationSign, StringSplitOptions.RemoveEmptyEntries);
                            var dateOut = DateTime.Now;
                            var date = DateTime.TryParse(splitedInfo[0], out dateOut);
                            var modBy = splitedInfo[1];
                            res.Add(new ModificationDTO
                            {
                                ModificationDate = dateOut,
                                ModifyBy = modBy
                            });
                        }
                    }
                }
                return res.OrderByDescending(o => o.ModificationDate).ToList();
            }
        }
        public void AddCreationInfo(string userName)
        {
            //first modification...
            if (string.IsNullOrWhiteSpace(this.Modifications))
            {
                this.Modifications = $"{DateTime.Now}{ModificationSeparators.GetModificationInfoSeparationSign}{userName}";
            }
            else
            {
                //another modification info...
                this.Modifications = $"{this.Modifications}{ModificationSeparators.GetModificationListSeparationRowSign}{DateTime.Now}{ModificationSeparators.GetModificationInfoSeparationSign}{userName}";
            }

        }
        public string Modifications { get; set; }
    }

    public static class ModificationSeparators
    {
        public static string GetModificationListSeparationRowSign => "||";
        public static string GetModificationInfoSeparationSign => "#";
    }

    public class ModificationDTO
    {
        public DateTime ModificationDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
