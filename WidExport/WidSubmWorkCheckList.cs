using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WidExport.UcWidSubmWorkNames;
using static WidExport.UcWidSubmWorkPerformers;
using static WidExport.UcWidSubmWorkShares;

namespace WidExport
{
    public class WidSubmWorkCheckList
    {
        public class RoleMapEntry
        {
            public int RhType { get; set; }
            public int RhRole { get; set; }
            public string WidRole { get; set; }
            public bool IsAuthor { get; set; }
        }

        public static Dictionary<int, string> RhType = new Dictionary<int, string>
        {
            {0, ""},
            {1, "Пвл"},
            {2, "Тов"},
            {3, "Вдв"},
        };

        public static Dictionary<int, string> RhRole = new Dictionary<int, string>
        {
            {1, "Авт Тек"},
            {2, "Комп"},
            {3, "Виконавець"},
            {4, "Хореограф"},
            {5, "Перекладач"},
            {6, "Автор лібрето"},
            {7, "Аранжувальник"},
            {8, "Пвл"},
            {9, "Правовласник"},
            {10, "Комп/авт тек"},
            {11, "Автор лібрето до танцю"},
            {12, "Автор обробки"},
            {13, "Автор сценарію"},
            {14, "Автор хореографії та лібрето"},
            {15, "Режисер"},
            {60001, "Автор інсценізації"},
            {60002, "Автор лібрето"},
            {60003, "Автор літературного твору"},
            {60005, "Композитор"},
            {60006, "Драматург (автор п'єси)"},
            {60007, "Автор проміжного перекладу"},
            {60009, "Перекладач"},
            {60010, "Перекладач інсценізації"},
            {60011, "Перекладач лібрето"},
            {60012, "Перекладач літературного твору"},
            {60014, "Режисер"},
            {60015, "Хореограф"},
            {60016, "Художник-сценограф"},
            {60017, "Художник з ляльок"},
            {60018, "Художник по костюмах"},
        };

        public bool HasOwnAuthor        { get; set; }
        public bool RolesDefined        { get; set; }
        public bool HasNonPublisher     { get; set; }
        public bool AllInIpi            { get; set; }
        public bool PubShare0or100      { get; set; }
        public bool MecShare0or100      { get; set; }
        public bool HasShare            { get; set; }
        public bool NamesApproved       { get; set; }
        public bool PerformersApproved  { get; set; }
        public bool AllIpiCodesValid    { get; set; }

        public void Refresh(int groupId, int objId)
        {
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = "select * from WidSubmGroupWorkCheckList where WidSubmGroupId = @groupId and ObjId = @objId";
                cmd.Parameters.AddWithValue("@groupId", groupId);
                cmd.Parameters.AddWithValue("@objId", objId);
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    int idx = 3;
                    HasOwnAuthor        = r.GetBoolean(idx++);
                    RolesDefined        = r.GetBoolean(idx++);
                    HasNonPublisher     = r.GetBoolean(idx++);
                    AllInIpi            = r.GetBoolean(idx++);
                    PubShare0or100      = r.GetBoolean(idx++);
                    MecShare0or100      = r.GetBoolean(idx++);
                    HasShare            = r.GetBoolean(idx++);
                    NamesApproved       = r.GetBoolean(idx++);
                    PerformersApproved  = r.GetBoolean(idx++);
                    AllIpiCodesValid    = r.GetBoolean(idx++);
                }
            });
        }

        public bool HasErrors()
        {
            return !(HasOwnAuthor && RolesDefined && AllInIpi && HasNonPublisher &&
                HasShare && MecShare0or100 && PubShare0or100 &&
                NamesApproved && PerformersApproved && AllIpiCodesValid);
        }

        public bool HasShareErrors()
        {
            return !(HasOwnAuthor && RolesDefined && AllInIpi && HasNonPublisher &&
                HasShare && MecShare0or100 && PubShare0or100 &&
                AllIpiCodesValid);
        }

        public bool HasNameErrors()
        {
            return !NamesApproved;
        }

        public bool HasPerformerErrors()
        {
            return !PerformersApproved;
        }
    }
}
